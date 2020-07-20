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

namespace Homework_08
{
	public partial class MainWindow : Window
	{
		#region Домашнее задание 8
		/// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
		/// В структуре присутствуют департаменты и сотрудники
		/// Каждый департамент может содержать не более 1_000_000 сотрудников.
		/// У каждого департамента есть поля: наименование, дата создания,
		/// количество сотрудников числящихся в нём 
		/// (можно добавить свои пожелания)
		/// 
		/// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
		/// уникальный номер, размер оплаты труда, количество закрепленным за ним проектов.
		///
		/// В данной информаиционной системе должна быть возможность 
		/// - импорта и экспорта всей информации в xml и json
		/// Добавление, удаление, редактирование сотрудников и департаментов
		/// 
		/// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
		/// по нескольким полям, например возрасту и оплате труда
		#endregion

		Organization Apple;
		public MainWindow()
		{
			InitializeComponent();
			Apple = new Organization();
		}

		private void Click_GenerateDeptAndEmployees(object sender, RoutedEventArgs e)
		{
			GenerateDeptsAndEmployeesMenu newOrg = new GenerateDeptsAndEmployeesMenu();
			newOrg.ShowDialog();
			
			if (newOrg.DialogResult == null ||
				newOrg.DialogResult == false)
				return;

			Apple.GenerateDeptAndEmployees((int)newOrg.entryRange.NumDepRange,
										   (int)newOrg.entryRange.NumEmpRange);
			depList.ItemsSource = Apple.Departments;
		}

		private void Click_Employees(object sender, RoutedEventArgs e)
		{

		}

		private void Click_UploadFromXLM(object sender, RoutedEventArgs e)
		{

		}

		private void Click_SaveToXLM(object sender, RoutedEventArgs e)
		{

		}

		private void Click_ExitButton(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
