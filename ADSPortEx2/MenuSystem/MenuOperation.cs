using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuSystem
{
    //Menu Operation Class
    //Implements IMenuItem
    //
    //Represents an option in the menu system when an operation needs to take place rather than some menu option such as a submenu.
    class MenuOperation<T> : IMenuItem<T> where T : class
    {
        string displayValue = string.Empty; //Display value for menu item (used to display operation name in list)
        Func<T, bool> action; //Function argument provides functionality for the menu operation without needing to implement specific classes for each operation.
        //Takes in the Generic as a paramater and outputs a bool.

        public MenuOperation(string displayValue) //Constructor with no additional function to run specified just a name.
        {
            //Set internal Values
            this.displayValue = displayValue;
            this.action = null;
        }

        public MenuOperation(string displayValue, Func<T, bool> function) //Constructor with function specified
        {
            //Set internal Values
            this.displayValue = displayValue;
            this.action = function;
        }

        public string GetMenuDisplayValue() //Gets what should be displayed as a menu item when outputted
        {
            return displayValue; //Output just the name of this operation
        }

        public bool Run(T menuContextItem, string context = "") //When this menu Item needs to be ran (selected) this function is run
        {
            if (action == null) //If action is null then we dont need to do anything just return false
            {
                return false;
            }
            return action.Invoke(menuContextItem); //If action is not null then we have a function we can invoke, providing the generic as a paramater.
        }
    }
}
