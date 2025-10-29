using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MenuSystem
{
    //ConsoleMenuItem
    //Implements Menu Item Interface
    //
    //Acts as the main container for menu items and provides the interface for selecting menu items
    //Internally contains a stack structure for storing the contained menu items.
    internal class ConsoleMenuItem<T> : IMenuItem<T> where T : class
    {
        MenuItemStack<T> menuItems; //Stores the current menu Items
        string currentMenuContext = ""; //Stores the menu "Context" this is a value used when displaying what submenu the user is in.
        string displayValue = ""; //What should be outputted if this menu is used as a submenu
        bool exitOnComplete = false; //If a menu item returns true when ran should this menu return to the previous menu.


        //Constructor Chaining to simplify structure
        public ConsoleMenuItem() : this(MenuItemStack<T>.DefaultMaxItems, "", "", false) { } //Constructor with no arguments takes default value of Menu Item Stack size (4)

        public ConsoleMenuItem(int size) : this(size, "", "", false) { } //Constructer with specific size paramater for allowing a change in the size of the stored amount of menu items

        public ConsoleMenuItem(int size, string context, string displayValue) : this(size, context, displayValue, false) { } //Constructor Specifying the size of stored menu items; setting context and displayed menu value

        public ConsoleMenuItem(int size, string context, string displayValue, bool exitOnComplete) //Full Constructor 
        {
            menuItems = new MenuItemStack<T>(size); //creates new object for menu item stack
            currentMenuContext = context; 
            this.displayValue = displayValue;
            this.exitOnComplete = exitOnComplete;
        } 

        public bool AddMenuItem(IMenuItem<T> menuItem) //Adds a menu item to the internal stack (returns false if could not add to stack)
        {
            return menuItems.AddMenuItem(menuItem); //Add menu item to internal stack
        }

        public void AddMenuItemThrow(IMenuItem<T> menuItem) //Adds a menu item to the internal stack throws an exception when the item could not be added
        {
            if(!menuItems.AddMenuItem(menuItem)) //Check if menu item could be added
            {
                throw new Exception(String.Format("Could not add menu item \"{0}\" to menu please check size of internal stack on menu \"{1}\"",menuItem.GetMenuDisplayValue(), currentMenuContext));
            }
        }

        public string GetMenuDisplayValue() //Gets the display value for this menu if it is used in a submenu
        {
            return displayValue;
        }

        private void OutputMenu() //Outputs the current menu
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("Please Select From the Options Below:"); //Add preamble
            for (int i = 0; i < menuItems.Count; i++) //Loop for getting menu options
            {
                if(menuItems[i] != null)
                {
                    //Menu options are added in the format "<Selectable Int> ) <Display of menu item>"
                    stringBuilder.AppendLine(String.Format("{0}) {1}",i.ToString(),menuItems[i].GetMenuDisplayValue()));
                }
            }
            //Add last option for getting out of the subMenu or exiting from the menu entirely (this uses the count of how many items are in the current menu stack)
            stringBuilder.AppendLine(String.Format("{0}) Exit",menuItems.Count.ToString()));
            Console.Write(stringBuilder.ToString());
        }

        private void OutputContext(string contextIn) //Ouput the current context with previous context value
        {
            string preContext = ""; //If the context paramater into this method is not empty then add a slash to denote a new submenu
            if (contextIn != "")
            {
                if (contextIn.Length > 10)
                {
                    preContext = ".../"; //Add functionality to reduce clutter when context is too long
                }
                else
                {
                    preContext = contextIn + "/"; //Default running operation get previous context and prepend to current context value
                }
            }

            if (preContext != "")
            {
                Console.Write(String.Format("{0}{1}>",preContext,currentMenuContext)); //If contextIn has a value then we are in a submenu and should output the context
            }
            else
            {
                Console.Write(String.Format("{0}>", currentMenuContext)); //Context in is empty we are in a new context.
            }
        }

        private bool GetUserInput(out int intValue,out string stringValue) //Get user input and validate that it is 
        {
            stringValue = Console.ReadLine();
            intValue = -1;
            return int.TryParse(stringValue, out intValue); //Try to parse the int returns false on failure.
        }

        public bool Run(T menuContextItem, string context = "")
        {
            while (true)
            {
                OutputMenu(); //Output the Menu
                OutputContext(context); //Output Context Specifier
                string stringMenuValue = "";
                int menuItemSelected = -1;
                if (!GetUserInput(out menuItemSelected, out stringMenuValue)) //Get user input returns false if value could not be obtained in correct format
                {
                    Console.WriteLine("Menu Item {0} Not Found please use [0-{1}]", stringMenuValue, menuItems.Count); //Tell user what range the input should be in
                    continue;
                }

                if ((menuItemSelected < 0) && (menuItemSelected) > menuItems.Count) //Check if menu item should exist no negative values or larger than the menu item count (equal is used for exit value)
                {
                    Console.WriteLine("Menu Item {0} Could not be run please use [0-{1}]", menuItemSelected, menuItems.Count); 
                    continue;
                }

                if (menuItemSelected == menuItems.Count) //Check if selected menu item is the exit item
                {
                    Console.WriteLine("Exiting");
                    break; //break out of the loop
                }

                string preContext = ""; //If the context paramater into this method is not empty then add a slash to denote a new submenu
                if (context != "")
                {
                    if (context.Length > 10)
                    {
                        preContext = ".../"; //Add functionality to reduce clutter when context is too long
                    }
                    else
                    {
                        preContext = context + "/"; //Default running operation get previous context and prepend to current context value
                    }
                }
                Console.WriteLine("Running:" + menuItems[menuItemSelected].GetMenuDisplayValue()); //Tell the user which menu item is being ran
                bool exitArgument = menuItems[menuItemSelected].Run(menuContextItem, preContext + currentMenuContext); //Run the menu item and get exit value

                if (exitArgument && exitOnComplete) //If we exit on success of the ran menu item break out of the loop
                {
                    break;
                }
            }
            return true; //Menu list returns true regardless
        }
    }
}
