using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Binary Search Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 5
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation.

    class BSTree<T> : BinTree<T> where T : IComparable
    {

        public BSTree()
        {
            root = null;
        }

        //Functions for EX.2A
        public void InsertItem(T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                InsertItemRecursive(root, item);
            }
        }

        public int Height()
        {
            throw new NotImplementedException();
        }

        public T EarlieseGame()
        {
            throw new NotImplementedException();
        }

        //Functions for EX.2B

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        //Free space, use as necessary to address task requirements... 


        private void InsertItemRecursive(Node<T> node, T item)
        {
            int compareValue = node.Data.CompareTo(item);
            if (compareValue == 0)
            {
                throw new Exception("Could not insert item, value already exists in tree");
            }
            else if (compareValue == 1) {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(item);
                    return;
                }
                InsertItemRecursive(node.Right, item);
            } 
            else 
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(item);
                    return;
                }
                InsertItemRecursive(node.Left, item);
            }
        }


    }// End of class
}
