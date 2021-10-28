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
        string[] memory = new string[25];
        string[] resultstring = new string[2];
        string[] term_split = new string[25];
        float[] term_result = new float[4];
        char[] separator = { '+', '-', '*', '/', '(', ')', ' ' };
        int result_index = 0;
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
                case Key.Enter: { TermEvaluation(OutputScreen_green.Text); break; }
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

        private string BracketsResolve(string input) //returns the term in the most inner brackets
        {
            if (input.Contains('('))
            {
                resultstring = input.Split('(', 2);
                term_split[0] = resultstring[0];
                return resultstring[1];
            }
            else if (input.Contains(')'))
            {
                resultstring = input.Split(')', 2);
                term_split[1] = resultstring[1];
                return resultstring[0];
            }
            return input;
        }
        private string TermAdd(string input)
        {
            if (input.Contains('+'))
            {
                resultstring = input.Split('+', 2);
                while (!resultstring[0].All(char.IsDigit) | !resultstring[1].All(char.IsDigit))
                {
                    foreach (char element in separator)
                    {
                        if (resultstring[0].Contains(element))
                        {
                            memory = resultstring[0].Split(element, 2);
                            resultstring[0] = memory[1];
                            term_split[0] = memory[0];
                            break;
                        }
                        else if (resultstring[1].Contains(element))
                        {
                            memory = resultstring[1].Split(element, 2);
                            resultstring[1] = memory[0];
                            term_split[1] = memory[1];
                            break;
                        }
                    }
                }
                if (resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
                {
                    term_result[result_index] = int.Parse(resultstring[0]) + int.Parse(resultstring[1]);
                    input = input.Replace(string.Concat(resultstring[0] + "+" + resultstring[1]), term_result[result_index].ToString());
                    return input;
                }
            }
            return input;
        }
        private string TermSub(string input)
        {
            if (input.Contains('-'))
            {
                resultstring = input.Split('-', 2);
                while (!resultstring[0].All(char.IsDigit) | !resultstring[1].All(char.IsDigit))
                {
                    foreach (char element in separator)
                    {
                        if (resultstring[0].Contains(element))
                        {
                            memory = resultstring[0].Split(element, 2);
                            resultstring[0] = memory[1];
                            term_split[0] = memory[0];
                            break;
                        }
                        else if (resultstring[1].Contains(element))
                        {
                            memory = resultstring[1].Split(element, 2);
                            resultstring[1] = memory[0];
                            term_split[1] = memory[1];
                            break;
                        }
                    }
                }
                if (resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
                {
                    term_result[result_index] = int.Parse(resultstring[0]) - int.Parse(resultstring[1]);
                    input = input.Replace(string.Concat(resultstring[0] + "-" + resultstring[1]), term_result[result_index].ToString());
                    return input;
                }
            }
            return input;
        }
        private string TermMul(string input)
        {
            if (input.Contains('*'))
            {
                resultstring = input.Split('*', 2);
                while (!resultstring[0].All(char.IsDigit) | !resultstring[1].All(char.IsDigit))
                {
                    foreach (char element in separator)
                    {
                        if (resultstring[0].Contains(element))
                        {
                            memory = resultstring[0].Split(element, 2);
                            resultstring[0] = memory[1];
                            term_split[0] = memory[0];
                            break;
                        }
                        else if (resultstring[1].Contains(element))
                        {
                            memory = resultstring[1].Split(element, 2);
                            resultstring[1] = memory[0];
                            term_split[1] = memory[1];
                            break;
                        }
                    }
                }
                if (resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
                {
                    term_result[result_index] = int.Parse(resultstring[0]) * int.Parse(resultstring[1]);
                    input = input.Replace(string.Concat(resultstring[0] + "*" + resultstring[1]), term_result[result_index].ToString());
                    return input;
                }
            }
            return input;
        }
        private string TermDiv(string input)
        {
            if (input.Contains('/'))
            {
                resultstring = input.Split('/', 2);
                while (!resultstring[0].All(char.IsDigit) | !resultstring[1].All(char.IsDigit))
                {
                    foreach (char element in separator)
                    {
                        if (resultstring[0].Contains(element))
                        {
                            memory = resultstring[0].Split(element, 2);
                            resultstring[0] = memory[1];
                            term_split[0] = memory[0];
                            break;
                        }
                        else if (resultstring[1].Contains(element))
                        {
                            memory = resultstring[1].Split(element, 2);
                            resultstring[1] = memory[0];
                            term_split[1] = memory[1];
                            break;
                        }
                    }
                }
                if (resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
                {
                    term_result[result_index] = int.Parse(resultstring[0]) / int.Parse(resultstring[1]);
                    input = input.Replace(string.Concat(resultstring[0] + "/" + resultstring[1]), term_result[result_index].ToString());
                    return input;
                }
            }
            return input;
        }
        private string TermResolve(string input) //returns the result of a blank term
        {
            if (input.Contains('('))
            {
                input = BracketsResolve(input);
            }
            if (input.Contains(')'))
            {
                input = BracketsResolve(input);
            }
            if (input.Contains('*'))
            {
                input = TermMul(input);
            }
            if (input.Contains('/'))
            {
                input = TermDiv(input);
            }
            if (input.Contains('+'))
            {
                input = TermAdd(input);
            }
            if (input.Contains('-'))
            {
                input = TermSub(input);
            }
            return input;
        }
        private void TermOutput(string input)
        {
            OutputScreen_green.Inlines.Clear();
            OutputScreen_green.Text = input;
        }
        private void TermEvaluation(string screentext)
        {
            if (!screentext.All(char.IsDigit))
                screentext = TermResolve(screentext);
            TermOutput(screentext);
        }
        private void btn_math(object sender, RoutedEventArgs e)
        {
            TermEvaluation(OutputScreen_green.Text);
        }

        private void btn_math(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TermEvaluation(OutputScreen_green.Text);
        }
    }
}

