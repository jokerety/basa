using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	[ProtoContract]
	public class Phone
	{
		public Phone()
		{ }
		public Phone(string number, int id)
		{
			Id = id;
			Number = number;
		}
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(2)]
		public string Number { get; set; }
	}
}
