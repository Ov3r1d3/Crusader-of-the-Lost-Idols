using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Crusader_of_the_Lost_Idols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }

        #region Area Where Variables are Declared

        int[] Talent_Counter = new int[23];
        public Label[] Talent_Counter_Labels;
        public Label[] Talent_Cost_Labels;
        public Button[] Talent_Button;

        double Idols_Counter;
        double Talent_Cost;
        //double Mult;
        double Crit;
        double Cooldown;
        double Ench, Ench1;
        double CurrentDps;
        double NextLevelDps;
        double PercentImprovement;
        double RemainingIdolsNum;

        private void Form1_Load(object sender, EventArgs e)
        {
            Talent_Cost_Labels = new Label[] {
                null, TimeORama_Cost, Endurance_Training_Cost, Passive_Criticals_Cost, OverEnchanted_Cost,
                Surplus_Cooldown_Cost, Set_Bonus_Cost, Sharing_Is_Caring_Cost, Spend_It_All_Cost, Speed_Looter_Cost, Scavenger_Cost,
                Massive_Criticals_Cost, Ride_the_Storm_Cost, Storms_Building_Cost, GoldOSplosion_Cost, Fast_Learners_Cost,
                Well_Equipped_Cost, Swap_Day_Cost, Upgrade_Them_All_Cost, Doing_It_Again_Cost, Efficient_Crusading_Cost,
                Deep_Idol_Scavenger_Cost, Triple_Tier_Trouble_Cost };
            Talent_Counter_Labels = new Label[] {
                null, TimeORama_Counter, Endurance_Training_Counter, Passive_Criticals_Counter, OverEnchanted_Counter,
                Surplus_Cooldown_Counter, Set_Bonus_Counter, Sharing_Is_Caring_Counter, Spend_It_All_Counter, Speed_Looter_Counter, Scavenger_Counter ,
                Massive_Criticals_Counter, Ride_the_Storm_Counter, Storms_Building_Counter, GoldOSplosion_Counter, Fast_Learners_Counter,
                Well_Equipped_Counter, Swap_Day_Counter, Upgrade_Them_All_Counter, Doing_It_Again_Counter, Efficient_Crusading_Counter,
                Deep_Idol_Scavenger_Counter, Triple_Tier_Trouble_Counter };
            Talent_Button = new Button[] {
                null, TimeORama_Button, Endurance_Training_Button, Passive_Criticals_Button, OverEnchanted_Button,
                Surplus_Cooldown_Button, Set_Bonus_Button, Sharing_Is_Caring_Button, Spend_It_All_Button, Speed_Looter_Button, Scavenger_Button,
                Massive_Criticals_Button, Ride_the_Storm_Button, Storms_Building_Button, GoldOSplosion_Button, Fast_Learners_Button,
                Well_Equipped_Button, Swap_Day_Button, Upgrade_Them_All_Button, Doing_It_Again_Button, Efficient_Crusading_Button,
                Deep_Idol_Scavenger_Button, Triple_Tier_Trouble_Button };
        }
        #endregion

        #region Code for Making Window Draggable 
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        #endregion

        #region Talent Button Clicks
        private void button1_Click(object sender, EventArgs e)
        {
            Button_Action(1, 1.25, 25, 20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button_Action(2, 1.25, 50, 20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button_Action(3, 1.1, 10, 50);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button_Action(4, 1.1, 100, 50);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button_Action(5, 1.1, 25, 50);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button_Action(6, 1.1, 100, 50);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button_Action(7, 1.25, 500, 14);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button_Action(8, 1, 25, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button_Action(9, 1, 100, 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button_Action(10, 1.1, 25, 50);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Button_Action(11, 1.25, 50, 25);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Button_Action(12, 1.15, 100, 25);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Button_Action(13, 1.33, 100, 15);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Button_Action(14, 1.15, 500, 25);
        }

        private void button15_Click_2(object sender, EventArgs e)
        {
            Button_Action(15, 1.2, 250, 18);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Button_Action(16, 1.075, 500, 50);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button_Action(17, 1.075, 500, 50);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button_Action(18, 1, 50, 1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button_Action(19, 1, 1000, 1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button_Action(20, 1.1, 50, 25);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button_Action(21, 1.15, 500, 25);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button_Action(22, 1, 5000, 1);
        }
        #endregion

        private void PlayerIdols_TextChanged(object sender, EventArgs e)
        {
            Idols_Counter = int.Parse(PlayerIdols.Text);
            RemainingIdols.Text = Idols_Counter.ToString();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            if (NumberCheck() == 0) { return; }
            CalculateBestScore();
        }



        private void button13_Click(object sender, EventArgs e)
        {
            if(NumberCheck() == 0) { return; }         
            ClickBestTalent();
            CalculateBestScore();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (IdolCheck() == 0) { return; }
            if (NumberCheck() == 0) { return; }
            RemainingIdolsNum = int.Parse(RemainingIdols.Text);
            while(RemainingIdolsNum > 0 && (RemainingIdolsNum - CalculateBestScoreCost()) > 0)
            {
                ClickBestTalent();
            }
        }




        #region Exit Button
        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        private void button15_Click(object sender, EventArgs e)
        {
            NumberCheck();
        }



        #region Reset Button
        private void button12_Click(object sender, EventArgs e)
        {
            for(int i=1; i<23; i++)
            {
                Talent_Counter[i] = 0;
                Talent_Counter_Labels[i].Text = "0";
                Talent_Button[i].Enabled = true; 
            }
            Talent_Cost_Labels[1].Text = "25";
            Talent_Cost_Labels[2].Text = "50";
            Talent_Cost_Labels[3].Text = "10";
            Talent_Cost_Labels[4].Text = "100";
            Talent_Cost_Labels[5].Text = "25";
            Talent_Cost_Labels[6].Text = "100";
            Talent_Cost_Labels[7].Text = "500";
            Talent_Cost_Labels[8].Text = "25";
            Talent_Cost_Labels[9].Text = "100";
            Talent_Cost_Labels[10].Text = "25";
            Talent_Cost_Labels[11].Text = "50";
            Talent_Cost_Labels[12].Text = "100";
            Talent_Cost_Labels[13].Text = "100";
            Talent_Cost_Labels[14].Text = "500";
            Talent_Cost_Labels[15].Text = "250";
            Talent_Cost_Labels[16].Text = "500";
            Talent_Cost_Labels[17].Text = "500";
            Talent_Cost_Labels[18].Text = "50";
            Talent_Cost_Labels[19].Text = "1000";
            Talent_Cost_Labels[20].Text = "50";
            Talent_Cost_Labels[21].Text = "500";
            Talent_Cost_Labels[22].Text = "5000";
            RemainingIdolsNum = 0;
            Idols_Counter = 0;
            RemainingIdols.Text = RemainingIdolsNum.ToString();
        }
        #endregion

        private void button16_Click(object sender, EventArgs e)
        {
            Thread Lbt = new Thread(WriteLog);
            Lbt.Start("Scanning to Find BushWhacker \r\n");
            Thread.Sleep((new Random()).Next(20, 30));
            Bitmap bmpScreenshot = Pixel_Detect.Screenshot();
            Point location;           
            bool success = Pixel_Detect.FindBitmap(Properties.Resources.bushwhacker, bmpScreenshot, out location);
            label13.Text = success.ToString();
            
            if (!success)
            {
                Log.Text += ("Bush Whacker not Found.Please go to first page of the crusaders\r\n");
            }
            else
            {
                Log.Text += ("Bush Whacker Found!\r\n");
                Log.Text += ("Appending the Correct Coordinates. Do not move the Crusaders of the lost Idols Window\r\n");
            }
            #region Setting Coords To Every Item
            Point[] Buttons = new Point[6];
            Buttons[0] = new Point(location.X + 250, location.Y + 15);
            Buttons[1] = new Point(location.X + 565, location.Y + 15);
            Buttons[2] = new Point(location.X + 880, location.Y + 15);
            Buttons[3] = new Point(location.X + 250, location.Y + 100);
            Buttons[4] = new Point(location.X + 565, location.Y + 100);
            Buttons[5] = new Point(location.X + 880, location.Y + 100);
            label14.Text = Buttons[0].ToString();
            Point[] SpellsTop = new Point[21];
            Point[] SpellsBottom = new Point[21];
            SpellsTop[0] = new Point(location.X + 9, location.Y + 60);
            SpellsTop[7] = new Point(location.X + 325, location.Y + 60);
            SpellsTop[14] = new Point(location.X + 641, location.Y + 60);
            for (int i = 0; i < 6; i++)
            {
                SpellsTop[i+1] = new Point(SpellsTop[i].X + 30, location.Y + 60);
                SpellsTop[i+8] = new Point(SpellsTop[i + 7].X + 30, location.Y + 60);
                SpellsTop[i+15] = new Point(SpellsTop[i + 14].X + 30, location.Y + 60);
            }
            SpellsBottom[0] = new Point(location.X + 9, location.Y + 145);
            SpellsBottom[7] = new Point(location.X + 325, location.Y + 145);
            SpellsBottom[14] = new Point(location.X + 641, location.Y + 145);
            for (int i = 0; i < 6; i++)
            {
                SpellsBottom[i + 1] = new Point(SpellsBottom[i].X + 30, location.Y + 145);
                SpellsBottom[i + 8] = new Point(SpellsBottom[i + 7].X + 30, location.Y + 145);
                SpellsBottom[i + 15] = new Point(SpellsBottom[i + 14].X + 30, location.Y + 145);
            }
            var LeftArrow = new Point(location.X - 22, location.Y +79);
            var RightArrow = new Point(location.X + 949, location.Y + 79);
            var LevelAll = new Point(location.X + 949, location.Y + 120);
            var AcceptLevelAll = new Point(location.X + 379, location.Y -143);
            var RedResetButton = new Point(location.X + 473, location.Y + 30);
            var AcceptResetButton = new Point(location.X + 1215, location.Y - 45);
            var ContinueButton = new Point(location.X + 465, location.Y + 44);
            var Saved2Formation = new Point(location.X + 170, location.Y - 34);
            var ClickArea = new Point(location.X + 696, location.Y - 212);
            label15.Text = AcceptResetButton.ToString();
            label16.Text = RedResetButton.ToString();
            #endregion
            /*for (int i = 0; i < 21; i++)
            {
                Cursor.Position = SpellsTop[i];
                MouseOp.DoMouseClick();
            }
            for (int i = 0; i < 21; i++)
            {
                Cursor.Position = SpellsBottom[i];
                MouseOp.DoMouseClick();
            }
            for (int i = 0; i < 6; i++)
            {
                Cursor.Position = Buttons[i];
                MouseOp.DoMouseClick();
            }*/
            //var BushWhackerPoint = new Point(location.X + 252, location.Y + 16);
            
            for (int i = 0; i < 7; i++)
            {
                Cursor.Position = RightArrow;
                MouseOp.DoMouseClick();
                Thread.Sleep((new Random()).Next(60, 90));
            }
            Cursor.Position = LevelAll;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(1500, 2000));
            Cursor.Position = AcceptLevelAll;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(3000, 5000));
            Cursor.Position = SpellsBottom[19];
            MouseOp.DoMouseClick();
            Cursor.Position = AcceptResetButton;
            Thread.Sleep((new Random()).Next(5000, 7000));
            Cursor.Position = AcceptResetButton;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(3000, 5000));
            Cursor.Position = RedResetButton;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(9000, 10000));
            Cursor.Position = ContinueButton;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(9000, 10000));

            Bitmap bmpScreenshot1 = Pixel_Detect.Screenshot();
            Point location1;
            bool success1 = Pixel_Detect.FindBitmap(Properties.Resources.worlds, bmpScreenshot, out location1);
            var FreePlayWorldWake = new Point(location.X + 445, location.Y + 44);
            var StartNewRun = new Point(location.X + 693, location.Y + 233);
            Cursor.Position = FreePlayWorldWake;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(9000, 10000));
            Cursor.Position = StartNewRun;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(15000, 20000));
            for (int i = 0; i < 10; i++)
            {
                Cursor.Position = ClickArea;
                MouseOp.DoMouseClick();
                Thread.Sleep((new Random()).Next(500, 600));
            }
            Thread.Sleep((new Random()).Next(2000, 3000));
            Cursor.Position = Saved2Formation;
            MouseOp.DoMouseClick();
            Thread.Sleep((new Random()).Next(1000, 2000));
            
            for (int i = 0; i < 10; i++)
            {
                Cursor.Position = Buttons[3];
                MouseOp.DoMouseClick();
                Thread.Sleep((new Random()).Next(500, 600));
            }
            
            

            //Cursor.Position = BushWhackerPoint;
            //MouseOp.DoMouseClick();

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            
        }

        #region Calculation Top Dps FOr Each Talent

        private void CalculateBestScore()
        {
            test.Text = Math.Round(CalculatePassiveCriticalsScore(), 2).ToString();
            test1.Text = Math.Round(CalculateSurplusCooldownScore(), 2).ToString();
            test2.Text = Math.Round(CalculateOverEchantedScore(), 2).ToString();
            test3.Text = Math.Round(CalculateSetBonusScore(), 2).ToString();
            test4.Text = Math.Round(CalculateSharingIsCaringScore(), 2).ToString();
        }

        private double CalculateBestScoreCost()
        {
            double a, b, c, d, e;
            if (Passive_Criticals_Button.Enabled == true)
            {
                a = CalculatePassiveCriticalsScore();
            }
            else { a = 0; };
            if (Surplus_Cooldown_Button.Enabled == true)
            {
                b = CalculateSurplusCooldownScore();
            }
            else { b = 0; };
            if (OverEnchanted_Button.Enabled == true)
            {
                c = CalculateOverEchantedScore();
            }
            else { c = 0; };
            if (Set_Bonus_Button.Enabled == true)
            {
                d = CalculateSetBonusScore();
            }
            else { d = 0; };
            if (Sharing_Is_Caring_Button.Enabled == true)
            {
                e = CalculateSharingIsCaringScore();
            }
            else { e = 0; };

            double[] Scores = { a, b, c, d, e };
            double MaxScore = Scores.Max();

            if (MaxScore == a)
            {
                return CalculateCost(10, 1.1, Talent_Counter[3]);
            }
            else if (MaxScore == b)
            {
                return CalculateCost(25, 1.1, Talent_Counter[5]);
            }
            else if (MaxScore == c)
            {
                return CalculateCost(100, 1.1, Talent_Counter[4]);
            }
            else if (MaxScore == d)
            {
                return CalculateCost(100, 1.1, Talent_Counter[6]);
            }
            else
            {
                return CalculateCost(500, 1.25, Talent_Counter[7]);
            }
        }

        private double CalculatePassiveCriticalsScore()
        {
            Crit = double.Parse(CritChance.Text);
            CurrentDps = Crit * Talent_Counter[3] / 100;
            NextLevelDps = Crit * (Talent_Counter[3] + 1) / 100;
            PercentImprovement = ((NextLevelDps + 1) - (CurrentDps + 1)) / (CurrentDps + 1);
            return PercentImprovement / CalculateCost(10, 1.1, Talent_Counter[3] + 1) * 100000;
        }

        private double CalculateSurplusCooldownScore()
        {
            Cooldown = int.Parse(AbilityCooldown.Text);
            CurrentDps = (Cooldown-50) * Talent_Counter[5] / 4 / 100;
            NextLevelDps = (Cooldown - 50) * (Talent_Counter[5] + 1) / 4 / 100;
            PercentImprovement = ((NextLevelDps + 1) - (CurrentDps + 1)) / (CurrentDps + 1);
            return PercentImprovement / CalculateCost(25, 1.1, Talent_Counter[5] + 1) * 100000;
        }

        private double CalculateOverEchantedScore()
        {
            Ench = int.Parse(Ench_Main.Text);
            CurrentDps = ((Talent_Counter[4] * 0.2) + 1) * (0.25) * Ench;
            NextLevelDps = (((Talent_Counter[4] + 1) * 0.2) + 1) * (0.25) * Ench;
            PercentImprovement = ((NextLevelDps + 1) - (CurrentDps + 1)) / (CurrentDps + 1);
            return PercentImprovement / CalculateCost(100, 1.1, Talent_Counter[4] + 1) * 100000;
        }

        private double CalculateSetBonusScore()
        {
            CurrentDps = Talent_Counter[6] * 0.2;
            NextLevelDps = (Talent_Counter[6] + 1) * 0.2;
            PercentImprovement = ((NextLevelDps + 1) - (CurrentDps + 1)) / (CurrentDps + 1);
            return PercentImprovement / CalculateCost(100, 1.1, Talent_Counter[6] + 1) * 100000;
        }

        private double CalculateSharingIsCaringScore()
        {
            Ench = int.Parse(Ench_Main.Text);
            Ench1 = int.Parse(Ench_Main1.Text);
            CurrentDps = (Math.Round(Ench + ( Ench1*( Talent_Counter[7] + 6)*0.05))) * ((Talent_Counter[4] * 0.2) + 1) * (0.25);
            NextLevelDps = (Math.Round(Ench + (Ench1 * ( Talent_Counter[7] + 7) * 0.05))) * ((Talent_Counter[4] * 0.2) + 1) * (0.25);
            PercentImprovement = ((NextLevelDps + 1) - (CurrentDps + 1)) / (CurrentDps + 1);
            return PercentImprovement / CalculateCost(500, 1.25, Talent_Counter[7] + 1) * 100000;
        }

        private void ClickBestTalent()
        {
            double a, b, c, d, e;
            if (Passive_Criticals_Button.Enabled == true)
            {
                a = CalculatePassiveCriticalsScore();
            }
            else{a = 0;};
            if (Surplus_Cooldown_Button.Enabled == true)
            {
                b = CalculateSurplusCooldownScore();
            }
            else { b = 0; };
            if (OverEnchanted_Button.Enabled == true)
            {
                c = CalculateOverEchantedScore();
            }
            else { c = 0; };
            if (Set_Bonus_Button.Enabled == true)
            {
                d = CalculateSetBonusScore();
            }
            else { d = 0; };
            if (Sharing_Is_Caring_Button.Enabled == true)
            {
                e = CalculateSharingIsCaringScore();
            }
            else { e = 0; };

            double[] Scores = {a, b, c, d, e};
            double MaxScore = Scores.Max();

            if(MaxScore == a)
            {
                Passive_Criticals_Button.PerformClick();
            }
            else if( MaxScore == b) 
            {
                Surplus_Cooldown_Button.PerformClick();
            }
            else if (MaxScore == c)
            {
                OverEnchanted_Button.PerformClick();
            }
            else if (MaxScore == d)
            {
                Set_Bonus_Button.PerformClick();
            }
            else
            {
                Sharing_Is_Caring_Button.PerformClick();
            }
        }
        #endregion


        #region Checking if the Fields are Empty and Asking For Input
        private int NumberCheck()
        {
            double number = 0;
            int number1 = 0;
            if (!(double.TryParse(CritChance.Text.Trim(), out number)))
            {
                MessageBox.Show("Please Enter Critical Chance Correctly");
                return 0;
            }
            if (!(int.TryParse(AbilityCooldown.Text.Trim(), out number1)))
            {
                MessageBox.Show("Please Enter Ability Cooldown Correctly");
                return 0;
            }
            if (!(int.TryParse(Ench_Main.Text.Trim(), out number1)))
            {
                MessageBox.Show("Please Enter Enchantment Points on Main Correctly");
                return 0;
            }
            if (!(int.TryParse(Ench_Main1.Text.Trim(), out number1)))
            {
                MessageBox.Show("Please Enter Enchantment Points on Alt Correctly");
                return 0;
            }
            return 1;
        }

        private int IdolCheck()
        {
            int number = 0;
            if (!(int.TryParse(PlayerIdols.Text.Trim(), out number)))
            {
                MessageBox.Show("Please Enter Your Idols Correctly");
                return 0;
            }
            return 1;
        }

        #endregion

        private void WriteLog(object messageObj)
        {
            string message = (string)messageObj; // Casting Object
            Log.Text += (message);
        }

        #region Usable Functions Button_Action(Button_Counter,Multiplier,Base_Cost,Max_Talent) & CalculateCost(BaseCost,Multiplier,level)
        private void Button_Action(int Button_Counter, double Multiplier, int Base_Cost, int Max_Talent)
        {
            Talent_Counter[Button_Counter]++;
            Talent_Counter_Labels[Button_Counter].Text = Talent_Counter[Button_Counter].ToString();
            Talent_Cost = CalculateCost( Base_Cost, Multiplier, Talent_Counter[Button_Counter]);
            Idols_Counter -= Talent_Cost;
            Talent_Cost_Labels[Button_Counter].Text = CalculateCost( Base_Cost, Multiplier, Talent_Counter[Button_Counter] + 1).ToString();
            RemainingIdols.Text = Idols_Counter.ToString();
            RemainingIdolsNum = Idols_Counter;
            if (Talent_Counter[Button_Counter] == Max_Talent)
            {
                Talent_Button[Button_Counter].Enabled = false;
                Talent_Cost_Labels[Button_Counter].Text = "Max";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private double CalculateCost(int BaseCost, double Multiplier, double level)
        {
            return Math.Ceiling(BaseCost * Math.Pow(Multiplier, level - 1));
        }
        #endregion
    }
}
