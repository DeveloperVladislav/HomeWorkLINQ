using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkLINQ
{
	public class Test
	{
		public int Age { get; set; }
		public string? Name { get; set; }
		public string? Category { get; set; }
		public Test(int age,string category,string name)
		{
			Name = name;
			Age = age;
			Category = category;
		}

		public void Show()
		{
			Console.WriteLine($"    Name - {Name}\n    Category - {Category}\n    Age - {Age}\n");
		}
	}
}
