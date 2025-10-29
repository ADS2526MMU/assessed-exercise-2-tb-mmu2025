using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSystem
{
    //Menu Item Interface
    //
    //Provides an interface for menu Items to specify their display values and what to do when ran
    //
    internal interface IMenuItem<T>
    {
        string GetMenuDisplayValue(); //Function used to get the display value for this menu Item
        bool Run(T menuContextItem, string context=""); //Function used when this menu item is selected (or "Run")  
    }
}
