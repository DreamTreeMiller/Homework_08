using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Department
    {
        private int depID;
        public int DepID                           // От 1 до 9999
        {
            get { return this.depID; }
            set
            {
                if (value <= 0) depID = 1;
                if (value > 9999) depID = 9999;
                this.depID = value;
            }
        }

        private string depName;
        public string DepName                         // Сделаем стандартным Отдел_хххх - 
        {                                               // хххх - цифры от 1 до 9999
            get { return "Отдел_" + $"{depID}"; }
        }
        public DateTime OpeningDate { get; set; }
        public int NumOfEmpl { get; set; }

        public string Projects { get; set; }
        public Department() { }         // Надо явно объявлять для сериализации в XML

        /// <summary>
        /// Конструктор. Создает отдел. Дата отдела - текущая. Поле проекты - No projects yet.
        /// </summary>
        /// <param name="depID">Номер отдела</param>
        /// <param name="numOfEmpl">Количество сотрудников</param>
        public Department(int depID, int numOfEmpl)
        {
            DepID = depID;
            NumOfEmpl = numOfEmpl;
            OpeningDate = DateTime.Now;
            Projects = "No projects yet";
        }

        /// Предикат проверки номер департамента для List.Find
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=netcore-3.1#System_Collections_Generic_List_1_Find_System_Predicate__0__
        /// Ну и другие тоже надо писать

        public override string ToString()
        {
            return $"{DepName,12}" +
                   $", создан {OpeningDate,12:dd.MM.yyyy}" +
                   $", кол-во сотрудников: {NumOfEmpl,8}" +
                   $", {Projects}";
        }
    }

    /// <summary>
    /// Компаратор для поля возраст
    /// </summary>
    class CompareByAge : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null && y == null) return 0;           // Сотрудники идентичны
            if (x == null) return -1;                       // x - null, y not null, y is greater
            if (y == null) return  1;                       // x is not null, y is null, x is greater
            return x.Age.CompareTo(y.Age);
        }
    }

    /// <summary>
    /// Компаратор для поля зарплата
    /// </summary>
    class CompareBySalary : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null && y == null) return 0;           // Сотрудники идентичны
            if (x == null) return -1;                       // x - null, y not null, y is greater
            if (y == null) return  1;                       // x is not null, y is null, x is greater
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
