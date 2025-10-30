using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            return HeightRecursive(root);
        }

        public T EarlieseGame()
        {
            Node<T> tempNode = null;
            int value = OldestGameRecursive(root, ref tempNode);
            if (tempNode == null)
            {
                throw new Exception("Could not find earliest game");
            }
            return tempNode.Data;
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

        private int HeightRecursive(Node<T> node, int depth = 0)
        {
            if(node == null)
            {
                return 0;
            }

            if (node.IsLeaf())
            {
                return depth+1;
            }
            else
            {
                int leftHeight = HeightRecursive(node.Left, depth + 1);
                int rightHeight = HeightRecursive(node.Right, depth + 1);
                return (leftHeight > rightHeight) ? leftHeight : rightHeight;
            }
        }

        private int OldestGameRecursive(Node<T> node, ref Node<T> oldestGameNode, int oldest = int.MaxValue)
        {
            if (node == null)
            {
                return oldest;
            }

            if(node.Data is VideoGame gameData)
            {
                if(gameData.Releaseyear < oldest)
                {
                    oldest = gameData.Releaseyear;
                    oldestGameNode = node;
                }

                oldest = OldestGameRecursive(node.Left,ref oldestGameNode, oldest);
                oldest = OldestGameRecursive(node.Right,ref oldestGameNode, oldest);
                return oldest;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }// End of class
}
