using System;
using System.Windows.Forms;

namespace PokeHealRank
{
    static class Program
    {
        [STAThread]
        static void Main(string[] ca)
        {
            args = ca;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string[] args = null;
    }
}
