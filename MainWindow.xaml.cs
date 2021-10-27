using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;

namespace primetest_gmp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string[] memory;
		string[] resultstring = new string[2];
		string[] term_split;
		float[] term_result;
		char[] separator = { '+', '-', '*', '/', '(', ')', ' ' };
		int result_index = 0;
		int memory_index = 0;
		public MainWindow()
		{
			InitializeComponent();
			//string input = OutputScreen_green.Text.ToString();
			//memory = new string[input.Length];
			//term_split = new string[input.Length];
			//term_result = new float[4];
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
			switch(e.Key)
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
			}
		}

		private string BracketsResolve(string input) //returns the term in the most inner brackets
		{
			if(input.Contains('('))
			{
				resultstring = input.Split('(', 2);
				term_split[0] = resultstring[0];
				return BracketsResolve(resultstring[1]);
			}
			else if(input.Contains(')'))
			{
				resultstring = input.Split(')', 2);
				term_split[1] = resultstring[1];
				return BracketsResolve(resultstring[0]);
			}
			return TermResolve(resultstring[0]);
		}
		private string TermAdd(string input)
		{
			if(input.Contains('+'))
			{
				resultstring = input.Split('+', 2);
				while(!resultstring[0].All(char.IsDigit) | !resultstring[1].All(char.IsDigit))
				{
					foreach(char element in separator)
					{
						if(resultstring[0].Contains(element))
						{
							memory = resultstring[0].Split(element, 2);
							resultstring[0] = memory[1];
							term_split[0] = memory[0];
							break;
						}
						else if(resultstring[1].Contains(element))
						{
							memory = resultstring[1].Split(element, 2);
							resultstring[1] = memory[0];
							term_split[1] = memory[1];
							break;
						}
					}
				}
				//memory[memory_index++] = resultstring[0];
				if(resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
				{
					term_result[result_index] = int.Parse(resultstring[0]) + int.Parse(resultstring[1]);
					input = input.Replace(string.Concat(resultstring[0] + "+" + resultstring[1]), term_result[result_index].ToString());
					return TermAdd(input);
				}
				return TermEvaluation(input);
			}
			for(int i = 0; i < memory.Length - 1; i++)
			{
				if(memory[i] != null)
				{
					term_result[result_index] += int.Parse(memory[i]);
					memory[i] = null;
				}
				else
				{
					result_index++;
					break;
				}
			}
			return TermEvaluation(resultstring[1]);
		}
		private string TermSub(string input)
		{
			if(input.Contains('-'))
			{
				resultstring = input.Split('-', 2);
				if(resultstring[0].All(char.IsWhiteSpace))
					return input;
				while(!resultstring[0].All(char.IsDigit))
				{
					foreach(char element in separator)
					{
						if(resultstring[0].Contains(element))
						{
							memory = resultstring[0].Split(element, 2);
							resultstring[0] = memory[1];
							break;
						}
					}
				}
				memory[memory_index++] = resultstring[0];
				if(resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
				{
					term_result[result_index] = int.Parse(resultstring[0]) - int.Parse(resultstring[1]);
					return TermEvaluation(term_result[result_index++].ToString());
				}
				return TermSub(resultstring[1]);
			}
			for(int i = 0; i < memory.Length - 1; i++)
			{
				if(memory[i] != null)
				{
					term_result[result_index] -= int.Parse(memory[i]);
					memory[i] = null;
				}
				else
				{
					result_index++;
					break;
				}
			}
			return TermEvaluation(resultstring[1]);
		}
		private string TermMul(string input)
		{
			if(input.Contains('*'))
			{
				resultstring = input.Split('*', 2);
				memory[memory_index++] = resultstring[0];
				while(!resultstring[0].All(char.IsDigit))
				{
					foreach(char element in separator)
					{
						if(resultstring[0].Contains(element))
						{
							memory = resultstring[0].Split(element, 2);
							resultstring[0] = memory[1];
							break;
						}
					}
				}
				if(resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
				{
					term_result[result_index] = int.Parse(resultstring[0]) * int.Parse(resultstring[1]);
					return TermResolve(term_result[result_index++].ToString());
				}
				return TermMul(resultstring[1]);
			}
			for(int i = 0; i < memory.Length - 1; i++)
			{
				if(memory[i] != null)
				{
					term_result[result_index] *= int.Parse(memory[i]);
					memory[i] = null;
				}
				else
				{
					result_index++;
					break;
				}
			}
			return TermEvaluation(resultstring[1]);
		}
		private string TermDiv(string input)
		{
			if(input.Contains('/') && resultstring[0].All(char.IsDigit))
			{
				resultstring = input.Split('/', 2);
				while(!resultstring[0].All(char.IsDigit))
				{
					foreach(char element in separator)
					{
						if(resultstring[0].Contains(element))
						{
							memory = resultstring[0].Split(element, 2);
							resultstring[0] = memory[1];
							break;
						}
					}
				}
				memory[memory_index++] = resultstring[0];
				if(resultstring[0].All(char.IsDigit) && resultstring[1].All(char.IsDigit))
				{
					term_result[result_index] = int.Parse(resultstring[0]) / int.Parse(resultstring[1]);
					return term_result[result_index++].ToString();
				}
				return TermDiv(resultstring[1]);
			}
			for(int i = 0; i < memory.Length - 1; i++)
			{
				if(memory[i] != null)
				{
					term_result[result_index] /= int.Parse(memory[i]);
					memory[i] = null;
				}
				else
				{
					result_index++;
					break;
				}
			}
			return TermResolve(resultstring[1]);
		}
		private string TermResolve(string input) //returns the result of a blank term
		{
			if(input.Contains('*'))
			{
				TermMul(input);
			}
			memory_index = 0;
			if(input.Contains('/'))
			{
				TermDiv(input);
			}
			memory_index = 0;
			if(input.Contains('+'))
			{
				TermAdd(input);
			}
			memory_index = 0;
			if(input.Contains('-'))
			{
				TermSub(input);
			}
			memory_index = 0;
			for(int i = 1; i < term_result.Length - 1; i++)
			{
				term_result[0] += term_result[i];
				term_result[i] = 0;
			}
			return TermEvaluation(Convert.ToString(term_result[0]));
		}

		private string TermOutput(string input)
		{
			OutputScreen_green.Text = input;
			return OutputScreen_green.Text.ToString();
		}
		private string TermEvaluation(string screentext)
		{
			if(screentext.Contains('(') || screentext.Contains(')'))
				BracketsResolve(screentext);
			if(!screentext.All(char.IsDigit))
				TermResolve(screentext);
			else
			{
				for(int i = 0; i < term_split.Length - 1; i++)
				{
					if(term_split[i] != null && (term_split[i].Contains('*') || term_split[i].Contains('/')))
					{
						if(i >= 1)
						{
							screentext = string.Concat(screentext, Convert.ToString(term_split[i]));
							term_split[i] = null;
						}
						else
						{
							screentext = string.Concat(Convert.ToString(term_split[i]), screentext);
							term_split[i] = null;
						}
						TermEvaluation(screentext);
					}
					if(term_split[i] == null) break;
				}
				for(int j = 0; j < term_result.Length - 1; j++)
				{
					if(term_split[j] != null && (term_split[j].Contains('+') || term_split[j].Contains('-')))
					{
						if(j >= 1)
						{
							screentext = string.Concat(screentext, Convert.ToString(term_split[j]));
							term_split[j] = null;
						}
						else
						{
							screentext = string.Concat(Convert.ToString(term_split[j]), screentext);
							term_split[j] = null;
						}
						TermEvaluation(screentext);
					}
				}
			}
			TermEvaluation(screentext);
			return screentext = screentext.All(char.IsDigit) ? TermOutput(screentext) : TermResolve(screentext);
		}
		private void btn_add(object sender, RoutedEventArgs e)
		{
			string input = OutputScreen_green.Text.ToString();
			memory = new string[input.Length];
			term_split = new string[input.Length];
			term_result = new float[4];
			TermEvaluation(input);
			//string input = OutputScreen_green.Text.ToString();
			//TermEvaluation(input);


			//try
			//{
			//	numbers = Array.ConvertAll(splitted, int.Parse);
			//	if(numbers != null)
			//	{
			//		OutputScreen_green.Inlines.Clear();
			//	}
			//}
			//catch
			//{
			//	OutputScreen_green.Inlines.Clear();
			//	OutputScreen_green.Text = "Wrong syntax!";
			//}

		}
	}
}

