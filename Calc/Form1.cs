using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool calcPress = false;
        public string symbol = "";
        public double result = 0;

        private void NumPress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Text;

            if (num == ".")
            {
                if (!txtOut.Text.Contains("."))
                {
                    if (txtOut.Text == "")
                    {
                        txtOut.Text = "0";
                    }
                    txtOut.Text += num;
                }

            }
            else
            {
                txtOut.Text += num;
            }
            
        }

        private void CalcNum(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            if (calcPress)
            {
                GetResult();
            }

            if (txtOut.Text == "" || txtOut.Text == ".")
            {
                MessageBox.Show("please make sure you enter a number before an operation");
            }
            else
            {
                symbol = button.Text;
                result = double.Parse(txtOut.Text);
                calcPress = true;
                txtOut.Text = "";
            }
        }

        private void GetResult()
        {
            try
            {
                if (calcPress)
                {
                    switch (symbol)
                    {
                        case "+":
                            txtOut.Text = (result + double.Parse(txtOut.Text)).ToString();
                            break;

                        case "-":
                            txtOut.Text = (result - double.Parse(txtOut.Text)).ToString();
                            break;

                        case "*":
                            txtOut.Text = (result * double.Parse(txtOut.Text)).ToString();
                            break;

                        case "/":
                            txtOut.Text = (result / double.Parse(txtOut.Text)).ToString();
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Equals(object sender, EventArgs e)
        {
            GetResult();
            calcPress = false;
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            calcPress = false;
            symbol = "";
            result = 0;
            txtOut.Text = "";
        }
    }
}
