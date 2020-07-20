using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Homework_08
{
	public partial class GenerateDeptsAndEmployeesMenu : Window
	{
		/// <summary>
		/// Создаём этот класс только для реализации проверки входных значение в окне
		/// </summary>
		public class EntryRange
		{
			public uint NumDepRange { get; set; }
			public uint NumEmpRange { get; set; }
		}
		public EntryRange entryRange;
		public GenerateDeptsAndEmployeesMenu()
		{
			InitializeComponent();
			entryRange = new EntryRange() { NumDepRange = 1, NumEmpRange = 1 };
			this.DataContext = entryRange;

		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}
	}
}
