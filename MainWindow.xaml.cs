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
		string[] terms = new string[100];
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

		private string BracketsResolve(string input)
		{
			string[] resultstring = new string[100];
			string temp;
			int n = 0;
			string inline = input;
			char[] literals = inline.ToCharArray();
			for(int i = 0; i < literals.Length - 1; i++)
			{
				if(literals[i] == '(')
				{
					resultstring = inline.Split('(', 2);
					terms[n] = resultstring[n];
					n++;
				}
			}
			temp = resultstring[n];
			literals = temp.ToCharArray();
			for(int j = 0; j < literals.Length-1; j++)
			{
				n = 0;
				if(temp.EndsWith(')'))
				{
					temp = temp[0..^1];
					resultstring[n] = temp;
					break;
				}
				if(literals[j] == ')')
				{
					resultstring = temp.Split(')', 2); //rs[0] = middleterm
					n++;
					terms[n] = resultstring[n]; 
				}
			}
			return resultstring[n];
		}

		private string Terms(string input)
		{
			string[] adds = new string[100];
			string[] subs = new string[100];
			int result = 0, k = 0, l = 0;
			string term = input;
			string[] resultstring = new string[100];
			char[] literals = term.ToCharArray();
			if(term.Contains('*'))
			{
				for(int i = 0; i < literals.Length - 1; i++)
				{
					if(literals[i] == '*')
					{
						resultstring = term.Split('*');
						result = int.Parse(resultstring[0]) * int.Parse(resultstring[1]);
					}
					if(literals[i] == '/')
					{
						resultstring = term.Split('/');
						result = int.Parse(resultstring[0]) / int.Parse(resultstring[1]);
					}
				}
				return result.ToString(); //term x*y or x/y
			}
			else
			{
				for(int j = 0; j < literals.Length - 1; j++)
				{
					if(literals[j] == '+')
					{
						resultstring = term.Split('+', 2);
						adds[k] = resultstring[k];
						term = resultstring[k+1];
						k++;
					}
					if(literals[j] == '-')
					{
						resultstring = term.Split('-', 2);
						subs[l] = resultstring[l];
						term = resultstring[l+1];
						l++;
					}
				}
				foreach(string addend in adds)
				{
					result += int.Parse(addend);
				}
				foreach(string minuend in subs)
				{
					result -= int.Parse(minuend);
				}
				return result.ToString();
			}
		}
		private void btn_add(object sender, RoutedEventArgs e)
		{
			int[] numbers = new int[100];
			int[] operation_index = new int[100];
			string input = OutputScreen_green.Text.ToString();
			OutputScreen_green.Text = Terms(BracketsResolve(input));


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

