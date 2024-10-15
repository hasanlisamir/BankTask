using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
	public class Transaction
	{
		public double Amount { get; set; }
		public string Description { get; set; }
		public DateTime CreateAt {  get; set; }

	}
}
