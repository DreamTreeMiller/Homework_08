using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //public static int CompareByAge(Employee x, Employee y)
        //{
        //	if (x == null && y == null) return 0;           // Сотрудники идентичны
        //	if (x == null) return -1;                       // x - null, y not null, y is greater
        //	if (y == null) return  1;                       // x is not null, y is null, x is greater
        //	return x.Age.CompareTo(y.Age);
        //}

        public int depID;
        public string DepName { get { return "Отдел_" + $"{depID}"; } }
        //public static int CompareByDepName(Employee x, Employee y)
        //{
        //    if (x == null && y == null) return 0;           // Сотрудники идентичны
        //    if (x == null) return -1;                       // x - null, y not null, y is greater
        //    if (y == null) return 1;                        // x is not null, y is null, x is greater
        //    return x.DepName.CompareTo(y.DepName);
        //}

        public int Salary { get; set; }
        //public static int CompareBySalary(Employee x, Employee y)
        //{
        //    if (x == null && y == null) return 0;           // Сотрудники идентичны
        //    if (x == null) return -1;                       // x - null, y not null, y is greater
        //    if (y == null) return  1;                       // x is not null, y is null, x is greater
        //    return x.Salary.CompareTo(y.Salary);
        //}

        public int NumOfProj { get; set; }
        public Employee() { }        // Надо явно объявлять для сериализации в XML
        public Employee(int id, string firstN, string lastN, int age, int depNum, int salary, int nofpr)
        {
            ID = id;
            FirstName = firstN;
            LastName = lastN;
            Age = age;
            depID = depNum;
            Salary = salary;
            NumOfProj = nofpr;
        }
        public override string ToString()
        {
            return $"{ID,8}" +
                   $"{FirstName,10}" +
                   $"{LastName,16}" +
                   $"{Age,12}" +
                   $"{DepName,16}" +
                   $"{Salary,10:###,###}" +
                   $"{NumOfProj,8}";
        }
    }
}
