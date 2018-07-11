using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Person> person = new List<Person>() {
				new Person() { Name = "Andrey", Age = 24, City = "Kyiv" },
				new Person() { Name = "Liza", Age = 18, City = "Moscow" },
				new Person() { Name = "Oleg", Age = 15, City = "London" },
				new Person() { Name = "Sergey", Age = 55, City = "Kyiv" },
				new Person() { Name = "Sergey", Age = 32, City = "Kyiv" }
			};
			Console.WriteLine("\nPeoples Age < 25\n");
			Console.WriteLine("Code for weakers : ");
			IEnumerable <Person> res = from p in person
							   where p.Age < 25
							   select p;
			foreach (var item in res)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			person.Where(p => p.Age < 25).ToList<Person>().ForEach(i => Console.WriteLine(i));

			Console.WriteLine("\nPeoples that live in Kyiv\n");
			Console.WriteLine("Code for weakers : ");
			IEnumerable<Person> res1 = from p in person
				  where p.City.ToUpper() == "KYIV"
				  select p;
			foreach (var item in res1)
			{
				Console.WriteLine(item.Name);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			person.Where(p => p.City.ToUpper() == "KYIV").ToList<Person>().ForEach(i => Console.WriteLine(i.Name));

			Console.WriteLine("\nName of peoples that Live in Kyiv\n");
			Console.WriteLine("Code for weakers : ");
			IEnumerable<string> res2 = from p in person
										where p.City.ToUpper() == "KYIV"
										select p.Name;
			foreach (var item in res2)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			person.Where(p => p.City.ToUpper() == "KYIV").Select(p=>p.Name).ToList<string>().ForEach(i => Console.WriteLine(i));


			Console.WriteLine("\nPeoples that Live in Kyiv and Age > 35\n");
			Console.WriteLine("Code for weakers : ");
			IEnumerable<Person> res3 = from p in person
									   where p.Age > 35 && p.City.ToUpper() == "KYIV"
									   select p;
			foreach (var item in res3)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			person.Where(p => p.City.ToUpper() == "KYIV" && p.Age > 35).ToList().ForEach(i => Console.WriteLine(i));

			Console.WriteLine("\nPeoples that live in Moscow\n");
			Console.WriteLine("Code for weakers : ");
			IEnumerable<Person> res4 = from p in person
									   where p.City.ToUpper() == "MOSCOW"
									   select p;
			foreach (var item in res4)
			{
				Console.WriteLine(item.Name);
			}
			Console.WriteLine("\nCode for hard programmers : ");
			person.Where(p => p.City.ToUpper() == "MOSCOW").ToList<Person>().ForEach(i => Console.WriteLine(i.Name));
		}
	}
}
