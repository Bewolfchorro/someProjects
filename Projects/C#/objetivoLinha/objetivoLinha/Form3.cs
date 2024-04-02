using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace objetivoLinha
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        
        private int time = 0;
        private int minutes = 0;

        public Form3()
        {
            InitializeComponent();
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2.instance.decreaseQuantity();
            //Form2.instance.getListValues();

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (time < 59)
            {
                time++;
            }
            else if (time == 59)
            {
                minutes++;
                time = 0;
            }

            


            string timeString = minutes.ToString() + ":" + time.ToString();

            label1.Text = timeString;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
