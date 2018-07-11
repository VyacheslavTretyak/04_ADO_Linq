using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
	class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string City { get; set; }
		public override string ToString()
		{
			return $"People on name {Name}";
		}
	}
}
