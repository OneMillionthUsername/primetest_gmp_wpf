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
		private void btn_add(object sender, RoutedEventArgs e)
		{
			char[] operation = { '+', '-', '*', '/', '(', ')' };
			string inline = OutputScreen_green.Text.ToString();
			char[] literals = inline.ToCharArray();
			string[] splitted;
			int[] numbers = new int[100];
			int[] operation_index = new int[100];
			int addend1, addend2;

			try
			{
				numbers = Array.ConvertAll(splitted, int.Parse);
				if(numbers != null)
				{
					OutputScreen_green.Inlines.Clear();
				}
			}
			catch
			{
				OutputScreen_green.Inlines.Clear();
				OutputScreen_green.Text = "Wrong syntax!";
			}

		}
	}
}
