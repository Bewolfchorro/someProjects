using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace objetivoLinha
{
    public partial class Form1 : Form
    {
        public static Form1 instance;

        private string modelName;
        private string quantity;


        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            Form3 form3 = new Form3();
            form3.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            textToVars();
            showVars();
            addListBox();
            listFromListBox();
            /*
            foreach (var item in listFromListBox())
            {
                MessageBox.Show(item);
            }
            */
            Form2.instance.calcTotalQuant();
            Form2.instance.setObjective();
            Form2.instance.showTotalQuant();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void textToVars()
        {
            modelName = modelNameText.Text;
            quantity = quantityText.Text;
        }

        private void addListBox()
        {
            listBox1.Items.Add(modelName + " - " + quantity);
        }

        private void showVars()
        {
            MessageBox.Show("Modelo: " + modelName + "\nQuantidade: " + quantity);
        }

        public List<string> listFromListBox()
        {
            List<string> list = new List<string>();
            foreach (var item in listBox1.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public void updateListBox(string modelName, string quantity)
        {
            // Encontra o item na ListBox e atualiza seus valores
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                if (item.StartsWith(modelName))
                {
                    listBox1.Items[i] = modelName + " - " + quantity;
                    break;
                }
            }
        }

        // Função para remover o modelo da lista
        public void removeModelFromList(string modelName)
        {
            // Encontra e remove o modelo da ListBox
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                if (item.StartsWith(modelName))
                {
                    listBox1.Items.RemoveAt(i);
                    break;
                }
            }
        }

    }
}
