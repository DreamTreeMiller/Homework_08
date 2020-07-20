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

		public MainWindow()
		{
			InitializeComponent();
		}
	}
}
