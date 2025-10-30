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
            buffer = "[";
            InOrderRecursive(root, ref buffer);
            buffer += "]";
        }

        public void PreOrder(ref string buffer)
        {
            buffer = "[";
            PreOrderRecursive(root, ref buffer);
            buffer += "]";
        }

        public void PostOrder(ref string buffer)
        {
            PostOrderRecursive(root, ref buffer);
        }

        //Free space, use as necessary to address task requirements... 

        private void InOrderRecursive(Node<T> node,ref string buffer)
        {
            if (node == null) { return; }
            buffer += "[";
            if (node.IsLeaf()) 
            { 
                buffer += node.ToString(); 
            }
            else
            {
                if(node.Left != null)
                {
                    InOrderRecursive(node.Left, ref buffer);
                }
                buffer += "[";
                buffer += node.ToString();
                buffer += "]";
                if(node.Right != null)
                {
                    InOrderRecursive(node.Right, ref buffer);
                }
            }
            buffer += "]";
        }

        private void PreOrderRecursive(Node<T> node, ref string buffer)
        {
            if (node == null) { return; }
            buffer += "[";
            if (node.IsLeaf())
            {
                buffer += node.ToString();
            }
            else
            {
                buffer += "[";
                buffer += node.ToString();
                buffer += "]";

                if (node.Left != null)
                {
                    PreOrderRecursive(node.Left, ref buffer);
                }
                
                if (node.Right != null)
                {
                    PreOrderRecursive(node.Right, ref buffer);
                }
            }
            buffer += "]";
        }

        private void PostOrderRecursive(Node<T> node, ref string buffer)
        {
            throw new NotImplementedException();
        }



    } // End of class
}
