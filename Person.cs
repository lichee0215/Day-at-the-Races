using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    class Person
    {
        //variables
        public string Name; //entitys name
        public Bet MyBet; //instance of Bet
        public int cash; //current cash
        //GUI control container variables
        public RadioButton MyRadiobutton; //reference
        public Label MyLabel; //reference

        //methods
        public void UpdateLabels()
        {
            //Set label to bet description, 
            //and the label on my radio button to show my cash
            //i.e. "Joe has 43 bucks"
            this.MyRadiobutton.Text = Name + " has $" + cash + " bucks";
            this.MyLabel.Text = MyBet.GetDescription();
        }
        public void ClearBet()
        { 
            //reset the bet to zero
            MyBet = new Bet() { Amount = 0, Dog = -1, Bettor = this};
        }
        public bool PlaceBet(int Amount, int Dog)
        {
            //Place new bet and store it in the bet field
            //return true if the person has enough money to bet
            if (Amount <= cash)
            {
                MyBet.Amount = Amount;
                MyBet.Dog = Dog;
                MyBet.Bettor = this;
                UpdateLabels();
                return true;
            }
            else
            {
                UpdateLabels();
                return false;
            }
        }
        public void Collect(int winner)
        {
            //ask my bet to pay out
            cash += MyBet.PayOut(winner);
            MessageBox.Show(this.Name + " wins/loses $" + MyBet.Amount);
            ClearBet();
        }

    }
}
