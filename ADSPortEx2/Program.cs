using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuSystem;

namespace ADSPortEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BSTree<VideoGame> tree = new BSTree<VideoGame>();
            ConsoleMenuItem<BSTree<VideoGame>> consoleMenu = new ConsoleMenuItem<BSTree<VideoGame>>(10,"Main","Main");
            ConsoleMenuItem<BSTree<VideoGame>> consoleMenuDisplay = new ConsoleMenuItem<BSTree<VideoGame>>(10, "Display", "Display Tree", true);

            consoleMenuDisplay.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("Pre Order"));
            consoleMenuDisplay.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("In Order"));
            consoleMenuDisplay.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("Post Order"));
            

            consoleMenu.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("Insert New Game"));
            consoleMenu.AddMenuItemThrow(consoleMenuDisplay);
            consoleMenu.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("Get Earliest Release"));
            consoleMenu.AddMenuItemThrow(new MenuOperation<BSTree<VideoGame>>("Get Tree Height"));


            consoleMenu.Run(tree);

            Console.ReadLine();

        }
    }
}
