using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2
{
	class Employee
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public int DepId { get; set;}
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
	class Program
	{
		static void Main()
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

			Console.WriteLine("\n Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке\n");
			Console.WriteLine("Code for weakers : ");
			var res = from e in employees
					  join d in departments on e.DepId equals d.Id
						 where d.Country.ToUpper() == "UKRAINE" && d.City.ToUpper() != "DONETSK"
						 select new { e.FirstName, e.LastName };
			foreach (var item in res)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new { e.FirstName, e.LastName, d.Country, d.City }).Where(e=>e.City.ToUpper() != "DONETSK" && e.Country.ToUpper()== "UKRAINE").ToList().ForEach(i => Console.WriteLine(i));

			Console.WriteLine("\n Вывести список стран без повторений\n");
			Console.WriteLine("Code for weakers : ");
			var res1 = (from d in departments					  
					  select d.Country).Distinct();
			foreach (var item in res1)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			departments.Select(d=>d.Country).Distinct().ToList().ForEach(i => Console.WriteLine(i));
			
			
			Console.WriteLine("\n Выбрать 3 - x первых сотрудников, возраст которых превышает 25 лет\n");
			Console.WriteLine("Code for weakers : ");
			var res2 = (from e in employees
						where e.Age>25
						select e).Take(3);
			foreach (var item in res2)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.Where(e=>e.Age>25).Take(3).ToList().ForEach(i => Console.WriteLine(i));


			



			Console.WriteLine("\n Выбрать имена, фамилии и возраст студентов из Киева, возраст которых меньше 23 года\n");
			Console.WriteLine("Code for weakers : ");
			var res3 = from e in employees
					  join d in departments on e.DepId equals d.Id
					  where e.Age<23 && d.City.ToUpper() == "KYIV"
					  select new { e.FirstName, e.LastName, e.Age, d.City };
			foreach (var item in res3)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new { e.FirstName, e.LastName, e.Age, d.City }).Where(e => e.City.ToUpper() == "KYIV" && e.Age<23).ToList().ForEach(i => Console.WriteLine(i));
		}
	}
}
