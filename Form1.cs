using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public partial class Form1 : Form
    {
        Person[] People = new Person[3];
        Greyhound[] racers = new Greyhound[4];
        public Form1()
        {
            InitializeComponent();
            //Create an array for the three people and the four dogs
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    People[i] = new Person()
                    {
                        Name = "Joe",
                        MyLabel = label5,
                        MyRadiobutton = radioButton1,
                        MyBet = new Bet{Amount = 0, Dog = -1, Bettor = People[i]},
                        cash = 50
                    };
                }
                else if (i == 1)
                {
                    People[i] = new Person()
                    {
                        Name = "Bob",
                        MyLabel = label6,
                        MyRadiobutton = radioButton2,
                        MyBet = new Bet{Amount = 0, Dog = -1, Bettor = People[i]},
                        cash = 75
                    };
                }
                else if (i == 2)
                {
                    People[i] = new Person()
                    {
                        Name = "Al",
                        MyLabel = label7,
                        MyRadiobutton = radioButton3,
                        MyBet = new Bet{Amount = 0, Dog = -1, Bettor = People[i]},
                        cash = 45
                    };
                }
                else MessageBox.Show("Loading error in people array creation");
            }
            for (int i = 0; i < 4; i++)
            {
                System.Threading.Thread.Sleep(2);
                if (i == 0)
                {
                    racers[i] = new Greyhound()
                    {
                        MyPictureBox = pictureBox2,
                        StartingLocation = pictureBox2.Location.X,
                        RacetrackLength = pictureBox1.Size.Width,
                        Location = pictureBox2.Location.X,
                        MyRandom = new Random()
                    };
                }
                else if (i == 1)
                {
                    racers[i] = new Greyhound()
                    {
                        MyPictureBox = pictureBox3,
                        StartingLocation = pictureBox3.Location.X,
                        RacetrackLength = pictureBox1.Size.Width,
                        Location = pictureBox2.Location.X,
                        MyRandom = new Random()
                    };
                }
                else if (i == 2)
                {
                    racers[i] = new Greyhound()
                    {
                        MyPictureBox = pictureBox4,
                        StartingLocation = pictureBox4.Location.X,
                        RacetrackLength = pictureBox1.Size.Width,
                        Location = pictureBox2.Location.X,
                        MyRandom = new Random()
                    };
                }
                else if (i == 3)
                {
                    racers[i] = new Greyhound()
                    {
                        MyPictureBox = pictureBox5,
                        StartingLocation = pictureBox5.Location.X,
                        RacetrackLength = pictureBox1.Size.Width,
                        Location = pictureBox2.Location.X,
                        MyRandom = new Random()
                    };
                }
                else MessageBox.Show("Error in racers array creation");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Joe";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Bob";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Al";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDown1.Value;
            int dog = (int)numericUpDown2.Value;
            MessageBox.Show(label2.Text + " bets $" + amount + " on dog #" + dog);
            if (label2.Text == "Joe")
            {
                People[0].PlaceBet(amount, dog-1);
            }
            else if (label2.Text == "Bob")
            {
                People[1].PlaceBet(amount, dog-1);
            }
            else if (label2.Text == "Al")
            {
                People[2].PlaceBet(amount, dog-1);
            }
            else MessageBox.Show("Bet setting error");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool raceWon = false;
            int dogWinner = -1;
            MessageBox.Show("The race is now starting!");
            while(!raceWon)
            {
                for (int i = 0; i < 4; i++)
                {
                    raceWon = racers[i].Run();
                    System.Threading.Thread.Sleep(1);
                    if (raceWon)
                    {
                        dogWinner = i;
                        break;
                    }
                }
            }
            MessageBox.Show("Dog #" + (dogWinner+1) + " has won!");
            for (int i = 0; i < 3; i++)
            {
                People[i].Collect(dogWinner);
                People[i].UpdateLabels();
            }
            for (int i = 0; i < 4; i++)
            {
                racers[i].TakeStartingPosition();
            }
        }
    }
}
