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
		public class EntryRange : IDataErrorInfo
		{
			public uint NumDepRange { get; set; }
			public uint NumEmpRange { get; set; }
			public string this[string columnName]
			{
				get
				{
					string error = String.Empty;
					switch (columnName)
					{
						case "NumDepRange":
							if ((NumDepRange < 1) || (NumDepRange > 10_000))
							{
								error = "Количество департаментов должно быть от 1 и до 10,000";
							}
							break;
						case "NumEmpRange":
							if ((NumEmpRange < 1) || (NumEmpRange > 1_000_000))
							{
								error = "Количество департаментов должно быть от 1 и до 1,000,000";
							}
							break;
					}
					return error;
				}
			}
			public string Error
			{
				get { throw new NotImplementedException(); }
			}
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
