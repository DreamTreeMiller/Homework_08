using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Homework_08
{
    public class Organization
    {
        public List<Department> Departments;
        public List<Employee> Employees;
        public int numberOfDepts;
        public int totalEmployees;

        public Organization()
        {
            Departments = new List<Department>();
            numberOfDepts = 0;
            Employees = new List<Employee>();
            totalEmployees = 0;
        }

        /// <summary>
        /// Добавляет новый отдел с названием Отдел_ХХХХ. 
        /// </summary>
        /// <param name="depNum">уникальный номер отдела</param>
        /// <param name="numOfEmpl">количество сотрудников в отделе</param>
        /// <returns>0  - если отдел успешно открыт</returns>
        /// <returns>-1 - если номер отдела меньше или равен 0, или больше 9999</returns>
        /// <returns>-2 - если отдел с таким номером уже существует</returns>
        public int OpenDept(int depNum, string depName, int numOfEmpl)
        {
            if (depNum <= 0 || depNum > 9_999) return -1;  // Номер отдела от 1 до 9_999
            if (DeptNumExists(depNum)) return -2;          // Департамент с таким номером уже существует
            Department newDep = new Department(depNum, depName, numOfEmpl);
            Departments.Add(newDep);
            numberOfDepts++;
            return 0;

        }

        /// <summary>
        /// Проеверяет, существует ли отдел с таким номером
        /// </summary>
        /// <param name="depNum">Номер отдела</param>
        /// <returns>true - существует</returns>
        /// <returns>false - нет</returns>
        private bool DeptNumExists(int depNum)
        {
            return true;
        }

        public bool CloseDept(int depID)
        {
            numberOfDepts--;
            return true;
        }

        /// <summary>
        /// Создает заданное количество отделов, в каждом не более maxEmp сотрудников
        /// </summary>
        /// <param name="maxDep">Количество отделов для создания</param>
        /// <param name="maxEmp">Максимальное кол-во сотрудников в одном отделе</param>
        /// <returns>Результат записывается в коллекции Departments и Employees</returns>
        public void GenerateDeptAndEmployees(int maxDep, int maxEmp)
        {
            if (maxDep * maxEmp > 1_000_000_000)
            {
                Console.WriteLine("Не могу принять такие данные!!!\n" +
                                  "Произведение кол-ва отделов на макс. кол-во сотрудников в отделе больше миллиарда!\n" +
                                  "Возможна ошибка переполнения.\n" +
                                  "Введите другие данные.");
                return;
            }
            Random r = new Random();
            int nEmp;
            totalEmployees = 0;
            numberOfDepts = maxDep;
            for (int i = 1; i <= maxDep; i++)
            {
                nEmp = r.Next(1, maxEmp + 1);
                Departments.Add(new Department(i, "Отдел_" + $"{i}", nEmp));
                for (int j = 1; j <= nEmp; j++)
                {
                    totalEmployees++;
                    Employees.Add(new Employee(totalEmployees,                          // уникальный номер сотрудника
                                               $"Имя_{r.Next(1, 1000)}",                // Имя
                                               $"Фамилия_{r.Next(1, 100_000)}",         // Фамилия
                                               r.Next(21, 26),                          // возраст
                                               "Отдел_" + $"{i}",                       // название отдела
                                               r.Next(4, 21) * 5_000,                   // зарплата
                                               r.Next(1, 6)));                          // кол-во проектов
                }
            }
        }

        /// <summary>
        /// Сортирует список сотрудников по полю Отдел
        /// </summary>
        public void SortEmployeesByDep()
        {
            Employees.Sort(delegate (Employee x, Employee y)
            {
                if (x == null && y == null) return 0;           // Сотрудники идентичны
                if (x == null) return -1;                       // x - null, y not null, y is greater
                if (y == null) return 1;                        // x is not null, y is null, x is greater
                return x.DepName.CompareTo(y.DepName);
            });
        }

        /// <summary>
        /// Сортирует часть списка сотрудников (одного отдела) по полю Возраст
        /// </summary>
        /// <param name="startIndex">Индекс элемента, с которого начать сортировку</param>
        /// <param name="count">Количество элементов для сортировки</param>
        public void SortEmployeesByAge(int startIndex, int count)
        {
            Employees.Sort(startIndex, count, new CompareByAge());
        }

        /// <summary>
        /// Сортирует часть списка сотрудников (одного отдела) по полю Зарплата
        /// </summary>
        /// <param name="startIndex">Индекс элемента, с которого начать сортировку</param>
        /// <param name="count">Количество элементов для сортировки</param>
        public void SortEmployeesBySalary(int startIndex, int count)
        {
            Employees.Sort(startIndex, count, new CompareBySalary());
        }

        /// <summary>
        /// Сортирует часть списка по возрасту, а потом в рамках возраста по зарплате
        /// </summary>
        /// <param name="startIndex">Начальный индекс, с которого сортировать</param>
        /// <param name="count">Количество элементов для сортировки</param>
        public void SortByAgeThenSalary(int startIndex, int count)
        {
            // Нам передали сотрудников одного отдела.
            // Начальный индекс этого отдела и количество сотрудников в отделе
            // Отсортируем сначала всех сотрудников по возрасту, 
            SortEmployeesByAge(startIndex, count);

            // Потом в каждом возрасте отсортируем по зарплате.
            // Начальный иднекс по возрасту
            int ageSI = startIndex;
            // Конечный индекс по зарплате
            int ageNextI = ageSI + 1;

            // Начинаем с наименьшего возраста и до конца отрезка списка
            // Если в самом начале надо отсортировать всего один элемент,
            // то цикл не будет выполняться.
            // Сортировка в таком случае, очевидно, не нужна
            while (ageNextI < startIndex + count - 1)
            {
                int currAge = Employees[ageSI].Age;
                ageNextI =
                    // Ищем индекс, с которого начинаются сотрудники следующего возраста,
                    // Следующий возраст - это тот, который не равен текущему

                    // FindIndex возвращает абсолютный индекс от начала Employees
                    Employees.FindIndex(ageSI,
                                        startIndex + count - ageSI,
                                        delegate (Employee x)
                                        {
                                            return !x.Age.Equals(currAge);
                                        });

                // Если дошли до конца диапазона и не нашли другого возраста,
                // то это последняя возрастная группа
                // ageNextI делаем следующим, после конечного индекса диапазона
                if (ageNextI == -1)
                    ageNextI = startIndex + count;
                Employees.Sort(ageSI, ageNextI - ageSI, new CompareBySalary());
                ageSI = ageNextI;
            }

        }

        public void SortByDepAgeSalary()
        {
            if (numberOfDepts == 1)
            {
                SortByAgeThenSalary(0, Employees.Count);
                return;
            }
            // Сортируем всех сотрудников по номеру отдела от 1 до макс. номера отдела
            SortEmployeesByDep();
            // Начальный индекс сотрудника, с которого надо сортировать внутри отдела
            int startIndex = 0;

            // Начинаем с первого отдела и до предпоследнего.
            for (int currDep = 1; currDep < numberOfDepts; currDep++)
            {
                string currDepName = Employees[startIndex].DepName;
                int nextIndex =
                    // Ищем индекс, с которого начинаются сотрудники следующего отдела,
                    // Следующий отдел - это тот, который не равен текущему
                    Employees.FindIndex(startIndex, delegate (Employee x)
                    {
                        return !x.DepName.Equals(currDepName);
                    });
                Console.WriteLine($"start index {startIndex,5}. lenght {nextIndex - startIndex}");
                SortByAgeThenSalary(startIndex, nextIndex - startIndex);
                startIndex = nextIndex;
            }
            //Console.WriteLine($"start index {startIndex,5}. lenght {Employees.Count - startIndex}");
            SortByAgeThenSalary(startIndex, Employees.Count - startIndex);
        }

    
    
    }
}
