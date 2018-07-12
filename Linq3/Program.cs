using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq3
{
	class Program
	{
		class Employee
		{
			public int Id { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public int Age { get; set; }
			public int DepId { get; set; }
			public override string ToString()
			{
				return $"Emploee {FirstName} {LastName}";
			}
		}
		class Department
		{
			public int Id { get; set; }
			public string Country { get; set; }
			public string City { get; set; }
			public override string ToString()
			{
				return $"Department {Country} {City}";
			}
		}
		static void Main(string[] args)
		{
			List<Department> departments = new List<Department>()
			{
				new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" },
				new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" },
				new Department() { Id = 3, Country = "France", City = "Paris" },
				new Department() { Id = 4, Country = "Russia", City = "Moscow" }
			};

			List<Employee> employees = new List<Employee>()
			{
				new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
				new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
				new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
				new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
				new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
				new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
				new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
			};

			Console.WriteLine("\n  Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.\n");
			Console.WriteLine("Code for weakers : ");
			var res = (from e in employees
					   join d in departments on e.DepId equals d.Id
					   where d.Country.ToUpper() == "UKRAINE"
					   orderby e.FirstName, e.LastName
					   select e).ToList();
			foreach (var item in res)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new { e.FirstName, e.LastName, d.Country }).Where(e => e.Country.ToUpper() == "UKRAINE").OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList().ForEach(i => Console.WriteLine(i));

			Console.WriteLine("\n Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.\n");
			Console.WriteLine("Code for weakers : ");
			var res1 = (from e in employees
						orderby e.Age descending
						select new { e.Id, e.FirstName, e.LastName, e.Age }).ToList();
			foreach (var item in res1)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.Select(e => new { e.Id, e.FirstName, e.LastName, e.Age }).OrderByDescending(e => e.Age).ToList().ForEach(i => Console.WriteLine(i));


			Console.WriteLine("\n Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.\n");
			Console.WriteLine("Code for weakers : ");
			var res2 = (from e in employees
						group e by e.Age into g
						select new { g.Key, count = g.Count() });
			foreach (var item in res2)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.GroupBy(e => e.Age).Select(g => new { g.Key, count = g.Count() }).ToList().ForEach(i => Console.WriteLine(i));
		}
	}
}
