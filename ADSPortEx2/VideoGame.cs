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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Developer
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int Releaseyear
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }// End of class
}
