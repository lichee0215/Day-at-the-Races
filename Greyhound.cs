using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DayAtTheRaces
{
    public class Greyhound
    {
        //variables
        public int StartingLocation;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        //Methods
        public bool Run()
        {
            //Move forward either 1,2,3, or 4 spaces at random
            //update the picturebox postion on the form
            // Return true if this won the race
            int x = 0;
            x= this.MyRandom.Next(1, 5);
           // MessageBox.Show("Random number is "+x);
            Location += x;
            //You have to pass a point to location
            Point p = new Point(Location, MyPictureBox.Location.Y);
            MyPictureBox.Location = p;
            if (Location >= RacetrackLength) return true;
            else return false;
        }
        public void TakeStartingPosition()
        {
            //resets starting location
            Point p = new Point(StartingLocation, MyPictureBox.Location.Y);
            MyPictureBox.Location = p;
            Location = StartingLocation;
        }
    }
}
