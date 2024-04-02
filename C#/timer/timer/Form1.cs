using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        //private string formatedHour;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timerLeft();
        }

        //Código para remover todos os caracteres não numéricos
        private string RemoveSpecialCharacters(string input)
        {
            string cleanedString = Regex.Replace(input, @"\D", "");

            return cleanedString;
        }

        //Código para adicionar ":" a cada dois caracteres
        private string AddColonEveryTwoCharacters(string input)
        {
            string formattedString = "";
            int count = 0;

            foreach (char c in input)
            {
                formattedString += c;

                count++;

                if (count % 2 == 0 && count != input.Length)
                {
                    formattedString += ":";
                }
            }

            return formattedString;
        }

        private void getTime()
        {
            actualTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private string formatTime()
        {
            string formatedHour = RemoveSpecialCharacters(desireTimeText.Text);
            int stringLength = formatedHour.Length;

            
            if (stringLength == 6)
            {
                formatedHour = AddColonEveryTwoCharacters(formatedHour);
            }
            else if (stringLength == 4)
            {
                formatedHour = formatedHour + "00";
                formatedHour = AddColonEveryTwoCharacters(formatedHour);
            }
            else if (stringLength == 2)
            {
                formatedHour = formatedHour + "0000";
                formatedHour = AddColonEveryTwoCharacters(formatedHour);               
            }
            return formatedHour;
        }

        //Código para converter uma string em DateTime
        private DateTime ConvertStringToDateTime(string input)
        {
            string format = "HH:mm:ss";

            DateTime result = DateTime.ParseExact(input, format, null);

            return result;
        }
        //Não está a ser utilizado

        private bool timerLeft()
        {
            string formattedTime = formatTime();

            DateTime formattedDateTime;

            if (DateTime.TryParseExact(formattedTime, "HH:mm:ss", null, DateTimeStyles.None, out formattedDateTime))
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan difference = formattedDateTime - currentTime;
                timeLeftLabel.Text = difference.ToString(@"hh\:mm\:ss");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void canTimer2Start()
        {
            if (timerLeft())
            {
                timer2.Start();
                labelVal();
            }
            else
            {
                MessageBox.Show("Hora inválida");
                timer2.Stop();
                choosenHours.Text = "00:00:00";
            }
        }

        private void labelVal()
        {
            choosenHours.Text = formatTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getTime();
            formatTime();
            canTimer2Start();
            //labelVal();
        }

        
    }
}
