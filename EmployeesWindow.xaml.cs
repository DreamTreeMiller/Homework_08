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
using System.Windows.Shapes;

namespace Homework_08
{
	/// <summary>
	/// Interaction logic for EmployeesWindow.xaml
	/// </summary>
	public partial class EmployeesWindow : Window
	{
		Organization myApple;
		public EmployeesWindow(Organization org)
		{
			InitializeComponent();
			myApple = org;
			employeesListView.ItemsSource = myApple.Employees;
		}

		private void Click_sortbyDep(object sender, RoutedEventArgs e)
		{
			myApple.SortEmployeesByDep();
			employeesListView.ItemsSource = myApple.Employees;
			employeesListView.Items.Refresh();
		}

		private void Click_sortbyAge(object sender, RoutedEventArgs e)
		{
			myApple.SortEmployeesByAge(0, myApple.Employees.Count);
			employeesListView.ItemsSource = myApple.Employees;
			employeesListView.Items.Refresh();
		}

		private void Click_sortbySalary(object sender, RoutedEventArgs e)
		{
			myApple.SortEmployeesBySalary(0, myApple.Employees.Count);
			employeesListView.ItemsSource = myApple.Employees;
			employeesListView.Items.Refresh();
		}

		private void Click_sortbyAgeThenSalary(object sender, RoutedEventArgs e)
		{
			myApple.SortByAgeThenSalary(0, myApple.Employees.Count);
			employeesListView.ItemsSource = myApple.Employees;
			employeesListView.Items.Refresh();
		}

		private void Click_sortbyDepAgeSalary(object sender, RoutedEventArgs e)
		{
			myApple.SortByDepAgeSalary();
			employeesListView.ItemsSource = myApple.Employees;
			employeesListView.Items.Refresh();
		}
	}
}
