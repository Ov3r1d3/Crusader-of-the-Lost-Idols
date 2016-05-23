using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crusader_of_the_Lost_Idols
{

    static class Forms
    {
        public static Stats_Form Stats_Form = new Stats_Form();
        public static Talent_Calculator Talent_Form = new Talent_Calculator();
        public static Botting_System Botting_Form = new Botting_System();
    }

    static class Variables
    {
        public static int[] Talent_Counter = new int[23];
        public static int[] Talent_Cost = new int[23];

        public static int Remaining_Idols_Counter;

        public static int Idols_Counter;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }




}
