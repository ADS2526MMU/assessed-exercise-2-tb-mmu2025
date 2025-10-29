using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSystem
{
    //Menu Item Stack Class
    //Used for storing menu items in a convinent way.
    internal class MenuItemStack<T>
    {
        public const int DefaultMaxItems = 4; //Constant value for storing default Max Items value
        int maxItems = 0;
        int index = 0;
        IMenuItem<T>[] menuItems;

        public int MaxItems //Property for accessing max items variable with a public getter and private setter.
        {
            get { return maxItems; }
            private set { if (value < 1) throw new Exception("Items must be at least 1"); maxItems = value; } //Bounds checking to make sure that the value of max items cannot be less than 1
        }

        public int Count //Property for getting the number of items stored in this container
        {
            get { return index; }
        }

        public MenuItemStack() : this(DefaultMaxItems) { } //Default constructor implementing constructor chaining and specifying the default maximum size of the internal array

        public MenuItemStack(int size) //Constructor with paramater allowing for the number of items stored to be set.
        {
            MaxItems = size;
            menuItems = new IMenuItem<T>[maxItems]; //Initialise the internal array of objects implementing the IMenuItem Interface
            index = 0; //Set Index to 0
        }

        public bool AddMenuItem(IMenuItem<T> menuItem) //Method for adding Items
        {
            if (index >= maxItems) //Check if the Container is full
                return false; //Could not add the menu Item return false
            menuItems[index++] = menuItem; //Set the current index in the menuItems array to the new item and increment the index
            return true; //Could add the menu item return false
        }

        public bool RemoveMenuItem(int indexOfItem) //Method for removing Items takes in the index of the item needing removal
        {
            if (index <= 0) return false; //Check if the Container is Empty
            if (indexOfItem < 0) //Check if provided index is out of the lower bound
                return false; //Could not remove the item return false
            if (indexOfItem >= index) //Check if the provided index is above the upper bound (index) 
                return false; //Could not remove the item return false

            for (int i = indexOfItem; i < index; i++) //For all items above the removed index to the top of the stack
            {
                menuItems[i] = menuItems[i + 1]; //Shift the items down changing item[i] to the next value of item[i+1] (this removes the item at the specified index and overwrites it)
            }
            menuItems[--index] = null; //Remove the trailing value decreasing the index first then setting the value to null this cleans up the last element in the stack 
            return true; //Could remove item return true
        }

        public IMenuItem<T> this[int index] //Array Access with bounds checking
        {
            get 
            { 
                if ((index >= this.index) || (index < 0)) //Check if value is within the range of the currently stored Items 
                { 
                    throw new IndexOutOfRangeException(); //Throw Exception if out of Range
                }
                else 
                { 
                    return menuItems[index]; //Return value if index is within range
                } 
            }
            set
            {
                if ((index >= this.index) || (index < 0)) //Check if value is within the range of the currently stored Items 
                { 
                    throw new IndexOutOfRangeException(); //Throw Exception if out of Range
                } 
                else 
                { 
                    menuItems[index] = value; //Set value at index to value if index is within range
                }
            }
        }
    }
}
