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

        //public Stats_Form Stats_Form = null;
        //public Talent_Calculator Talent_Calculator = null;
        //Stats_Form frm2 = new Stats_Form();
        //Talent_Calculator frm = new Talent_Calculator();


        public Form1()
        {
            InitializeComponent();
        }

        #region Area Where Variables are Declared

        public double Idols_Counter;
        //double RemainingIdolsNum;

        //public int Remaining_Idols_count;
        //public int Remaining_Idols_Count
        //{
        //    get { return Remaining_Idols_count; }
        //    set
        //    {
        //        Remaining_Idols_count = value;
        //        Refresh_Remaining_Idols_Label();
        //    }
        //}





        private void Form1_Load(object sender, EventArgs e)
        {
            
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



        private void PlayerIdols_TextChanged(object sender, EventArgs e)
        {
            Variables.Idols_Counter = int.Parse(PlayerIdols.Text);
            Variables.Remaining_Idols_Counter = Variables.Idols_Counter;
            RefreshLabel();
        }

        private void RefreshLabel()
        {
            Remaining_Idols_Label.Text = Variables.Remaining_Idols_Counter.ToString();
        }


        //private void button13_Click(object sender, EventArgs e)
        //{
        //    if(NumberCheck() == 0) { return; }         
        //    ClickBestTalent();
        //    CalculateBestScore();
        //}

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    if (IdolCheck() == 0) { return; }
        //    if (NumberCheck() == 0) { return; }
        //    RemainingIdolsNum = int.Parse(RemainingIdols.Text);
        //    while(RemainingIdolsNum > 0 && (RemainingIdolsNum - CalculateBestScoreCost()) > 0)
        //    {
        //        ClickBestTalent();
        //    }
        //}




        #region Exit Button
        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        #region Calculation Top Dps FOr Each Talent


        //private double CalculateBestScoreCost()
        //{
        //    double a, b, c, d, e;
        //    if (Passive_Criticals_Button.Enabled == true)
        //    {
        //        a = CalculatePassiveCriticalsScore();
        //    }
        //    else { a = 0; };
        //    if (Surplus_Cooldown_Button.Enabled == true)
        //    {
        //        b = CalculateSurplusCooldownScore();
        //    }
        //    else { b = 0; };
        //    if (OverEnchanted_Button.Enabled == true)
        //    {
        //        c = CalculateOverEchantedScore();
        //    }
        //    else { c = 0; };
        //    if (Set_Bonus_Button.Enabled == true)
        //    {
        //        d = CalculateSetBonusScore();
        //    }
        //    else { d = 0; };
        //    if (Sharing_Is_Caring_Button.Enabled == true)
        //    {
        //        e = CalculateSharingIsCaringScore();
        //    }
        //    else { e = 0; };

        //    double[] Scores = { a, b, c, d, e };
        //    double MaxScore = Scores.Max();

        //    if (MaxScore == a)
        //    {
        //        return CalculateCost(10, 1.1, Talent_Counter[3]);
        //    }
        //    else if (MaxScore == b)
        //    {
        //        return CalculateCost(25, 1.1, Talent_Counter[5]);
        //    }
        //    else if (MaxScore == c)
        //    {
        //        return CalculateCost(100, 1.1, Talent_Counter[4]);
        //    }
        //    else if (MaxScore == d)
        //    {
        //        return CalculateCost(100, 1.1, Talent_Counter[6]);
        //    }
        //    else
        //    {
        //        return CalculateCost(500, 1.25, Talent_Counter[7]);
        //    }
        //}


        //private void ClickBestTalent()
        //{
        //    double a, b, c, d, e;
        //    if (Passive_Criticals_Button.Enabled == true)
        //    {
        //        a = CalculatePassiveCriticalsScore();
        //    }
        //    else{a = 0;};
        //    if (Surplus_Cooldown_Button.Enabled == true)
        //    {
        //        b = CalculateSurplusCooldownScore();
        //    }
        //    else { b = 0; };
        //    if (OverEnchanted_Button.Enabled == true)
        //    {
        //        c = CalculateOverEchantedScore();
        //    }
        //    else { c = 0; };
        //    if (Set_Bonus_Button.Enabled == true)
        //    {
        //        d = CalculateSetBonusScore();
        //    }
        //    else { d = 0; };
        //    if (Sharing_Is_Caring_Button.Enabled == true)
        //    {
        //        e = CalculateSharingIsCaringScore();
        //    }
        //    else { e = 0; };

        //    double[] Scores = {a, b, c, d, e};
        //    double MaxScore = Scores.Max();

        //    if(MaxScore == a)
        //    {
        //        Passive_Criticals_Button.PerformClick();
        //    }
        //    else if( MaxScore == b) 
        //    {
        //        Surplus_Cooldown_Button.PerformClick();
        //    }
        //    else if (MaxScore == c)
        //    {
        //        OverEnchanted_Button.PerformClick();
        //    }
        //    else if (MaxScore == d)
        //    {
        //        Set_Bonus_Button.PerformClick();
        //    }
        //    else
        //    {
        //        Sharing_Is_Caring_Button.PerformClick();
        //    }
        //}
        //#endregion


       

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


   

        private void button3_Click_1(object sender, EventArgs e)
        {      
            Forms.Stats_Form.MdiParent = this;
            Forms.Stats_Form.ShowIcon = false;
            Forms.Stats_Form.Dock = DockStyle.Fill;
            Forms.Stats_Form.Show();
            Forms.Talent_Form.Hide();
            Forms.Botting_Form.Hide();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            Forms.Talent_Form.Remaining_Confirmed += RefreshLabel;
            Forms.Talent_Form.MdiParent = this;
            Forms.Talent_Form.ShowIcon = false;
            Forms.Talent_Form.Dock = DockStyle.Fill;
            Forms.Talent_Form.Show();
            Forms.Stats_Form.Hide();
            Forms.Botting_Form.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.Botting_Form.MdiParent = this;
            Forms.Botting_Form.ShowIcon = false;
            Forms.Botting_Form.Dock = DockStyle.Fill;
            Forms.Botting_Form.Show();
            Forms.Stats_Form.Hide();
            Forms.Talent_Form.Hide();
        }




    }
}
