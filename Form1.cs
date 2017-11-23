using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        int a = 0;
        int time = 0;
        [DllImport("user32")]
        public static extern void LockWorkStation();

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(a);
                return 0;
            });
            t.Wait();
            //Task.Delay(a);
            Process.Start("shutdown", "/s /t a");
            a = 0;
            time = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(a);
                return 0;
            });
            t.Wait();
            Process.Start("shutdown", "/r /t a");
            a = 0;
            time = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(a);
                return 0;
            });
            t.Wait();
            SetSuspendState(true, true, true);//hibernate
            a = 0;
            time = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sleep
            var t = Task.Run(async delegate
            {
                await Task.Delay(a);
                return 0;
            });
            t.Wait();
            SetSuspendState(false, true, true);
            a = 0;
            time = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                label5.Visible = true;
                timer2.Enabled = true;
                MessageBox.Show(a.ToString());
                var t = Task.Run(async delegate
                {
                    await Task.Delay(a);
                    return 0;
                });
                t.Wait();
                // System.Threading.Thread.Sleep(a);
                LockWorkStation();
                a = 0;
                time = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(a);
                return 0;
            });
            t.Wait();
            ExitWindowsEx(0, 0);
            a = 0;
            time = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button7.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox3.Visible = true;
                textBox2.Visible = true;
                textBox1.Visible = true;
                MessageBox.Show("Select time duration");
            }

            else
            {
                button7.Visible = false;
                textBox3.Visible = false;
                textBox2.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                a = 0;
                time = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
           // label5.Visible = true;
            label5.Text = time.ToString();
            int hrs = int.Parse(textBox1.Text);
            hrs = hrs * 60 * 60;
            int min = int.Parse(textBox2.Text);
            min = min * 60;
            int sec = int.Parse(textBox3.Text);
            hrs = hrs + 0;
            min = min + 0;
            sec = sec + 0;
            time = hrs + min + sec;
            a = time * 1000;
            MessageBox.Show(time.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("HH:mm:ss tt");
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            int b;
            b = time;
            label5.Visible = true;
            while (b != 0 && b > 0)
            {
               // label5.Visible = true;
                label5.Text = b.ToString();
                b = b - 1;
            }
            label5.Visible = false;
            timer2.Enabled = false;
        }
    }
}