using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace objetivoLinha
{
    public partial class Form2 : Form
    {
        public static Form2 instance;

        private string thisModelName;
        private string thisProdTime;
        private int thisQuantity;

        private int totalQuantity;

        private int objectiveDay = 20;

        private int produced = 0;

        private int time = 0;
        private int minutes = 0;

        private string diferencaString;

        private int dif = 0;

        private int i = 0;

        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startCron();
            updateLabels();
            getProdTime();
            calcDif();
            showDiff();
        }

        public void setObjective()
        {
            objectiveDay = totalQuantity;
        }

        public void calcTotalQuant()
        {
            totalQuantity = 0;
            foreach (var item in Form1.instance.listFromListBox())
            {
                string[] split = item.Split('-');
                totalQuantity += Convert.ToInt32(split[1]);
            }
        }

        private string getProdTime()
        {
            int value = 480 / objectiveDay;

            thisProdTime = value.ToString() + ":00";

            return thisProdTime;
        }

        public void getListValues()
        {
            foreach (var item in Form1.instance.listFromListBox())
            {
                string[] split = item.Split('-');
                thisModelName = split[0].Trim();
                thisQuantity = int.Parse(split[1].Trim());
            }
        }

        public void updateLabels()
        {
            getListValues();
            mediaTimeLabel.Text = getProdTime();
            quantityObjLabel.Text = totalQuantity.ToString();
            prodQuant.Text = produced.ToString();
        }


        public void decreaseQuantity()
        {
            foreach (var item in Form1.instance.listFromListBox())
            {
                string[] split = item.Split('-');
                if (split.Length != 2)
                {
                    MessageBox.Show("A string não foi dividida corretamente.");
                    continue;
                }

                string modelName = split[0].Trim();
                int quantity = int.Parse(split[1].Trim());

                if (quantity > 0)
                {
                    quantity--;
                    produced++;
                    //totalQuantity--;

                    Form1.instance.updateListBox(modelName, quantity.ToString());

                    MessageBox.Show("Modelo " + modelName + " atualizado para " + quantity + " unidades");
                    if (quantity == 0)
                    {
                        Form1.instance.removeModelFromList(modelName);
                        MessageBox.Show("Modelo " + modelName + " removido da lista");
                    }

                    if (produced == totalQuantity)
                    {
                        MessageBox.Show("FOGUETES E FOGUETES");
                    }
                    break; 
                }
                
            }
        }


        public void showTotalQuant()
        {
            MessageBox.Show(totalQuantity.ToString());
        }

        public void startCron()
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

            string minutesString = minutes.ToString().PadLeft(2, '0');
            string timeString = time.ToString().PadLeft(2, '0');

            string formattedTime = $"{minutesString}:{timeString}";

            label10.Text = formattedTime;
        }

        
        private void calcDif()
        {
            string atualTimeString = label10.Text;
            string mediaTimeString = mediaTimeLabel.Text;

            // Convertendo as strings para objetos DateTime
            DateTime atualTime = DateTime.ParseExact(atualTimeString, "mm:ss", CultureInfo.InvariantCulture);
            DateTime mediaTime = DateTime.ParseExact(mediaTimeString, "mm:ss", CultureInfo.InvariantCulture);

            // Calculando a diferença
            TimeSpan diferenca = atualTime - mediaTime;

            // Convertendo a diferença de volta para uma string no formato desejado (por exemplo, HH:mm:ss)
            diferencaString = diferenca.ToString();

            label11.Text = diferencaString;
        }

        private int timeExt()
        {
            string timeString = label11.Text;

            string[] parts = timeString.Split(':');

            int minutes = int.Parse(parts[0]) * 60;

            int seconds = int.Parse(parts[1]) + minutes;

            return seconds;
        }

        private int timeExt2()
        {
            string timeString = mediaTimeLabel.Text;

            string[] parts = timeString.Split(':');

            int minutes = int.Parse(parts[0]) * 60;

            int seconds2 = int.Parse(parts[1]) + minutes;

            return seconds2;
        }


        private void incDiff()
        {
            int seconds = timeExt();
            int seconds2 = timeExt2();


            if (i < 1000)
            { 
                if (seconds / seconds2 == i)
                {
                    dif++;
                    i++;
                }
                
            }
            
            labelMen.Text = i.ToString();


        }

        private void decDiff()
        {
            int seconds = timeExt();
            int seconds2 = timeExt2();

            if (seconds / seconds2 < 0)
            {
                dif--;
            }
        }

        public void showDiff()
        {
            incDiff();  
            label12.Text = dif.ToString();
        }

    }
}
