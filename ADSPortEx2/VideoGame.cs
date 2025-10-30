using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Film class implementation for Assessed Exercise 2

    class VideoGame : IComparable
    {
        private string title;
        private string developer;
        private int releaseYear;

        public VideoGame()
        {
            Title = "DEFAULT TITLE";
            Developer = "DEFAULT DEVELOPER";
            Releaseyear = 0;
        }

        public VideoGame(string title, string developer, int releaseyear)
        {
            Title = title;
            Developer = developer;
            Releaseyear = releaseyear;
        }

        public string Title
        {
            get 
            { 
                return title; 
            }

            set 
            {
                if ((value == null)||(value == ""))
                {
                    throw new ArgumentException("Title Cannot be Null or Empty");
                }
                title = value; 
            }
        }

        public string Developer
        {
            get 
            { 
                return developer; 
            }

            set
            {
                if ((value == null) || (value == ""))
                {
                    throw new ArgumentException("Developer Cannot be Null or Empty");
                }
                developer = value;
            }
        }

        public int Releaseyear
        {
            get 
            { 
                return releaseYear; 
            }

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Year Cannot be less than 0");
                }
                releaseYear = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is VideoGame other)
            {
                return Title.CompareTo(other.Title);
            }
            throw new ArgumentException("Paramater Must be of type VideoGame");
        }

        public override string ToString()
        {
            return String.Format("Title:{0} Developer:{1} Year of Release:{2}", Title, Developer, Releaseyear);
        } 

    }// End of class
}
