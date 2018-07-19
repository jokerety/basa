using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	[ProtoContract]
	public class Person
	{
		public Person()
		{ }
		public Person(string firstName, string secondName, string patronymic, string info)
		{
			FirstName = firstName;
			SecondName = secondName;
			Patronymic = patronymic;
			Info = info;
		}
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(2)]
		public string FirstName { get; set ; }
		[ProtoMember(3)]
		public string SecondName { get; set; }
		[ProtoMember(4)]
		public string Patronymic { get; set; }
		[ProtoMember(5)]
		public string Info { get; set; }
		[ProtoMember(6)]
		public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
	}
}
