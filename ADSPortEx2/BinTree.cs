using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Binary Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 4B
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation...

    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;

        public BinTree()
        {
            root = null;
        }

        public BinTree(Node<T> node)
        {
            root = node;
        }


        //Functions for EX.2A
        public void InOrder(ref string buffer)
        {
            InOrderRecursive(root, ref buffer);
        }

        public void PreOrder(ref string buffer)
        {
            PreOrderRecursive(root, ref buffer);
        }

        public void PostOrder(ref string buffer)
        {
            PostOrderRecursive(root, ref buffer);
        }

        //Free space, use as necessary to address task requirements... 

        private void InOrderRecursive(Node<T> node,ref string buffer)
        {
            if (node == null)
            {
                return;
            }
            if (node.IsLeaf())
            {
                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";
            }
            else
            {
                InOrderRecursive(node.Left, ref buffer);

                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";

                InOrderRecursive(node.Right, ref buffer);

            }
        }

        private void PreOrderRecursive(Node<T> node, ref string buffer)
        {
            if (node == null)
            {
                return;
            }
            if (node.IsLeaf())
            {
                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";
            }
            else
            {
                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";

                PreOrderRecursive(node.Left, ref buffer);

                PreOrderRecursive(node.Right, ref buffer);
            }
        }

        private void PostOrderRecursive(Node<T> node, ref string buffer)
        {
            if (node == null)
            {
                return;
            }
            if (node.IsLeaf())
            {
                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";
            }
            else
            {
                PostOrderRecursive(node.Left, ref buffer);

                PostOrderRecursive(node.Right, ref buffer);

                buffer += "[";
                buffer += node.ToString();
                buffer += "]\n";
            }
        }



    } // End of class
}
