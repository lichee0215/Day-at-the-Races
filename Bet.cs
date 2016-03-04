using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    class Bet
    {
        //variables
        public int Amount = 0; //cash amount betted
        public int Dog = -1; //reference to the dog that was bet on
        public Person Bettor; //reference to who placed the bet

        //methods
        public string GetDescription()
        {
            //Return string that says who placed the bet, how much was bet,
            //and which dog was bet on. If the amount is zero no bet was placed.
            //i.e. Joe bets $8 on dog 4 or Joe hasn't placed a bet.
            int temp = Dog + 1;
            if (Amount > 0) return (Bettor.Name + " bets $" + Amount + " on dog #" + temp.ToString());
            else return (Bettor.Name+" has not placed a bet.");
        }
        public int PayOut(int winner)
        {
            //the parameter is the winner of the race. if the dog won,
            //return the amount bet. Otherwise, return the negative of the amount bet.
            if (Dog == winner && winner != -1) return Amount;
            else if (winner != -1) return (0 - Amount);
            else
            {
                MessageBox.Show("Error in PayOut winner");
                return 0;
            }
        }
    }
}
