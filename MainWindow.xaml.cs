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
using System.IO;
using System.Xml.Serialization;

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
			Apple.Departments.Clear();
			Apple.numberOfDepts = 0;
			Apple.Employees.Clear();
			Apple.totalEmployees = 0;
			Apple.GenerateDeptAndEmployees((int)newOrg.entryRange.NumDepRange,
										   (int)newOrg.entryRange.NumEmpRange);
			depList.ItemsSource = Apple.Departments;
			depList.Items.Refresh();
		}

		private void Click_Employees(object sender, RoutedEventArgs e)
		{
			if (Apple.totalEmployees == 0) return;
			EmployeesWindow empWin = new EmployeesWindow(Apple);
			empWin.ShowDialog();

		}

		private void Click_UploadFromXLM(object sender, RoutedEventArgs e)
		{
			string filepathname;
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.FileName = "Organization";
			dlg.DefaultExt = ".xml";
			dlg.Filter = "XML documents (.xml)|*.xml";

			bool? result = dlg.ShowDialog();
			if (result != true) return;

			// Open document
			filepathname = dlg.FileName;

			// Создаем сериализатор на основе указанного типа 
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));

			// Создаем поток для чтения данных
			Stream fStream = new FileStream(filepathname, FileMode.Open, FileAccess.Read);

			// Запускаем процесс десериализации
			Organization tmp = xmlSerializer.Deserialize(fStream) as Organization;

			// Закрываем поток
			fStream.Close();

			Apple.Departments = tmp.Departments;
			Apple.Employees = tmp.Employees;
			Apple.numberOfDepts = tmp.numberOfDepts;
			Apple.totalEmployees = tmp.totalEmployees;
			depList.ItemsSource = Apple.Departments;
			depList.Items.Refresh();
		}

		private void Click_SaveToXLM(object sender, RoutedEventArgs e)
		{
			// Configure save file dialog box
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.FileName = "Organization"; // Default file name
			dlg.DefaultExt = ".xml"; // Default file extension
			dlg.Filter = "XML documents (.xml)|*.xml"; // Filter files by extension

			// Show save file dialog box
			bool? result = dlg.ShowDialog();

			// Process save file dialog box results
			if (result != true) return;

			// Save document
			string Path = dlg.FileName;

			// Создаем сериализатор на основе указанного типа 
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));

			// Создаем поток для сохранения данных
			Stream fStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);

			// Запускаем процесс сериализации
			xmlSerializer.Serialize(fStream, Apple);

			// Закрываем поток
			fStream.Close();
		}

		private void Click_ExitButton(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
