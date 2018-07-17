using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class Person
	{
		public Person()
		{ Phones = new List<Phone>(); }
		public Person(string firstName, string secondName, string patronymic, string info)
		{
			FirstName = firstName;
			SecondName = secondName;
			Patronymic = patronymic;
			Info = info;
			Phones = new List<Phone>();
		}
		public int Id { get; set; }
		public string FirstName { get; set ; }
		public string SecondName { get; set; }
		public string Patronymic { get; set; }
		public string Info { get; set; }
		public virtual ICollection<Phone> Phones { get; set; }

		public void ShowPerson()
		{
			Console.WriteLine($"№{Id} : ФИО:{SecondName} {FirstName} {Patronymic}\nИнформация:{Info}\nТелефоны:");
			foreach (Phone number in Phones)
			{
				Console.WriteLine($"{number.Number}");
			}
		}

	}
}
