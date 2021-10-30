using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace primetest_gmp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] resultstring = new string[2];
        char[] operator_point = { '*', '/' };
        char[] operator_line = { '+', '-' };
        char[] separator = { '(', ')' };
        string input;
        float result;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void btn_write_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            OutputScreen_green.Text += b.Content;
        }

        private void btn_clear(object sender, RoutedEventArgs e)
        {
            OutputScreen_green.Inlines.Clear();
        }

        private void key_write(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0: { OutputScreen_green.Text += "0"; break; }
                case Key.NumPad1: { OutputScreen_green.Text += "1"; break; }
                case Key.NumPad2: { OutputScreen_green.Text += "2"; break; }
                case Key.NumPad3: { OutputScreen_green.Text += "3"; break; }
                case Key.NumPad4: { OutputScreen_green.Text += "4"; break; }
                case Key.NumPad5: { OutputScreen_green.Text += "5"; break; }
                case Key.NumPad6: { OutputScreen_green.Text += "6"; break; }
                case Key.NumPad7: { OutputScreen_green.Text += "7"; break; }
                case Key.NumPad8: { OutputScreen_green.Text += "8"; break; }
                case Key.NumPad9: { OutputScreen_green.Text += "9"; break; }
                case Key.D0: { OutputScreen_green.Text += "0"; break; }
                case Key.D1: { OutputScreen_green.Text += "1"; break; }
                case Key.D2: { OutputScreen_green.Text += "2"; break; }
                case Key.D3: { OutputScreen_green.Text += "3"; break; }
                case Key.D4: { OutputScreen_green.Text += "4"; break; }
                case Key.D5: { OutputScreen_green.Text += "5"; break; }
                case Key.D6: { OutputScreen_green.Text += "6"; break; }
                case Key.D7: { OutputScreen_green.Text += "7"; break; }
                case Key.D8: { OutputScreen_green.Text += "8"; break; }
                case Key.D9: { OutputScreen_green.Text += "9"; break; }
                case Key.Divide: { OutputScreen_green.Text += "/"; break; }
                case Key.Add: { OutputScreen_green.Text += "+"; break; }
                case Key.Subtract: { OutputScreen_green.Text += "-"; break; }
                case Key.Multiply: { OutputScreen_green.Text += "*"; break; }
                case Key.Enter: { btn_math(Key.Enter, e); break; }
                case Key.Back:
                    {
                        if (OutputScreen_green.Text == string.Empty)
                        {
                            break;
                        }
                        OutputScreen_green.Text = OutputScreen_green.Text.Remove(OutputScreen_green.Text.Length - 1);
                        break;
                    }
            }
        }

        private string Add(string x, string y)
        {
            result = int.Parse(x) + int.Parse(y);
            return result.ToString();
        }

        private string Sub(string input)
        {
            result = int.Parse(resultstring[0]) - int.Parse(resultstring[1]);
            return result.ToString();
        }

        private string Mul(string input)
        {
            result = int.Parse(resultstring[0]) * int.Parse(resultstring[1]);
            return result.ToString();
        }
        private string Div(string input)
        {
            result = int.Parse(resultstring[0]) / int.Parse(resultstring[1]);
            return result.ToString();
        }
        private string Term(string input)
        {
            char[] scanterm = input.ToCharArray();

            while (!input.All(char.IsDigit))
            {
                for (int i = 0; i < scanterm.Length - 1; i++)
                {
                    //if (scanterm[i] == '(')
                    //{
                    //    resultstring = input.Split(separator[i], 2);
                    //    return Term(resultstring[1]);
                    //}
                    //if (scanterm[i] == ')')
                    //{
                    //    resultstring = resultstring[1].Split(separator[i], 2);
                    //    return Term(resultstring[0]);
                    //}
                    //if (scanterm[i] == '*')
                    //{
                    //    resultstring = input.Split(scanterm[i], 2);
                    //    return Term(resultstring[1]);
                    //}

                    //else if (scanterm[i] == '/')
                    //{
                    //    resultstring = input.Split(scanterm[i], 2);
                    //    return Term(resultstring[1]);
                    //}

                    //if (scanterm[i] == '-')
                    //{
                    //    resultstring = input.Split(scanterm[i], 2);
                    //    return Term(resultstring[1]);
                    //}
                    if (scanterm[i] == '+')
                    {
                        resultstring = input.Split(scanterm[i], 2);
                        resultstring = resultstring[1].Split(scanterm[i], 2);
                        if (resultstring.Length <= 1)
                        {
                            resultstring = input.Split(scanterm[i], 2);
                            result = int.Parse(resultstring[0]) + int.Parse(resultstring[1]);
                            return input = input.Replace(resultstring[0] + '+' + resultstring[1], result.ToString());
                        }
                        scanterm = input.ToCharArray();
                        resultstring = input.Split(scanterm[i], 2);
                        Term(resultstring[1]);
                        resultstring = input.Split(scanterm[i], 2);
                        input = input.Replace(resultstring[1], result.ToString());
                        //Term(resultstring[1]);
                    }
                    //resultstring[1] = input.Replace(resultstring[0] + scanterm[i] + resultstring[1], result.ToString());
                    //Term(resultstring[1]);
                }
            }
            if (input.Contains('+'))
            {

            }
            //if (resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
            //{
            //    if (input.Contains('*'))
            //        Mul(input);
            //    if (input.Contains('/'))
            //        Div(input);
            //    if (input.Contains('+'))
            //        Add(resultstring[0], resultstring[1]);
            //    if (input.Contains('-'))
            //        Sub(input);
            //}
            return input;
        }
        private void btn_math(object sender, RoutedEventArgs e)
        {
            Term(OutputScreen_green.Text);
        }

        private void btn_math(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Term(OutputScreen_green.Text);
        }
    }
}

