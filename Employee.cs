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

        public string DepName { get; set; }

        public int Salary { get; set; }

        public int NumOfProj { get; set; }
        public Employee() { }        // Надо явно объявлять для сериализации в XML
        public Employee(int id, string firstN, string lastN, int age, string depName, int salary, int nofpr)
        {
            ID = id;
            FirstName = firstN;
            LastName = lastN;
            Age = age;
            DepName = depName;
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
