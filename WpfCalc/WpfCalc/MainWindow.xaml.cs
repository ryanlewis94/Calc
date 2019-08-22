using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool calcPress = true;
        public string symbol = "";
        public double result = 0;

        

        private void NumPress(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = (string)button.Content;

            if (TxtResult.Text == "0" || !calcPress)
            {
                TxtResult.Text = "";
                TxtOut.Text = "";
                symbol = "";
                calcPress = true;
            }

            if (num == ".")
            {
                if (!TxtOut.Text.Contains("."))
                {
                    if (TxtResult.Text == "")
                    {
                        TxtResult.Text += $"0{num}";
                    }
                    else
                    {
                        if (TxtResult.Text.EndsWith("+") || TxtResult.Text.EndsWith("-") ||
                            TxtResult.Text.EndsWith("*") || TxtResult.Text.EndsWith("/"))
                        {
                            TxtResult.Text += $"0{num}";
                        }
                        else
                        {
                            TxtResult.Text += num;
                        }
                    }
                    TxtOut.Text += num;
                }

            }
            else
            {
                TxtOut.Text += num;
                TxtResult.Text += num;
            }
        }

        private void CalcPress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (calcPress)
            {
                GetResult();
            }

            if (TxtOut.Text == "" || TxtOut.Text == ".")
            {
                MessageBox.Show("please make sure you enter a number before an operation");
            }
            else
            {
                symbol = (string)button.Content;
                result = double.Parse(TxtOut.Text);
                calcPress = true;
                TxtOut.Text = "";
                if (TxtResult.Text.Contains("+") || TxtResult.Text.Contains("-") || 
                    TxtResult.Text.Contains("*") || TxtResult.Text.Contains("/"))
                {
                    if (symbol == "*" || symbol == "/")
                    {
                        TxtResult.Text = TxtResult.Text.Insert(0, "(");
                        TxtResult.Text = TxtResult.Text.Insert(TxtResult.Text.Length, ")");
                    }
                }
                
                TxtResult.Text += symbol;
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
                            TxtOut.Text = (result + double.Parse(TxtOut.Text)).ToString();
                            break;

                        case "-":
                            TxtOut.Text = (result - double.Parse(TxtOut.Text)).ToString();
                            break;

                        case "*":
                            TxtOut.Text = (result * double.Parse(TxtOut.Text)).ToString();
                            break;

                        case "/":
                            TxtOut.Text = (result / double.Parse(TxtOut.Text)).ToString();
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                TxtResult.Text = "0";
                TxtOut.Text = "0";
            }
        }

        private void BtnEq_Click(object sender, RoutedEventArgs e)
        {
            GetResult();
            TxtResult.Text = TxtOut.Text;
            calcPress = false;
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            calcPress = true;
            symbol = "";
            result = 0;
            TxtOut.Text = "";
            TxtResult.Text = "0";
        }
    }
}
