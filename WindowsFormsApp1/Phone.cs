using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class Phone
	{
		public Phone()
		{ }
		public Phone(string number, int id)
		{
			Id = id;
			Number = number;
		}

		public int Id { get; set; }

		public string Number { get; set; }
	}
}
