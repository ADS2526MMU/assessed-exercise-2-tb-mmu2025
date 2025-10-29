using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Node (tree) implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 4B
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation.

    class Node<T> where T : IComparable
    {
        T data;
        Node<T> left, right;

        public Node(T item)
        {
            data = item;
            left = null;
            right = null;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node<T> Right
        {
            get { return right; }   
            set { right = value; }
        }

        public bool IsLeaf()
        {
            return left != null && right != null;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    } // End of class
}
