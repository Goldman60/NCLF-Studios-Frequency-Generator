using System;
using System.Data;
using System.Windows.Forms;

namespace F_G
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            T = new Timer();
            T.Tick += new EventHandler(T_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            (sender as Button).Enabled = false;
            ChangeEnables(false);
            T.Interval = (int)(IntervalDomain.Value);
            T.Start();
            button2.Enabled = true;
        }

        Timer T;

        void T_Tick(object sender, EventArgs e)
        {
            Console.Beep((int)FreqDomain.Value, (int)DurationDomain.Value);
        }

        void ChangeEnables(bool enabled)
        {
            DurationDomain.Enabled = enabled;
            FreqDomain.Enabled = enabled;
            IntervalDomain.Enabled = enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            ChangeEnables(true);
            T.Stop();
            button1.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MessageBox.Show(string.Format("NCLF Studios Frequency Generator v. {0}\nCopyright NCLF Studios 2011", a), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
