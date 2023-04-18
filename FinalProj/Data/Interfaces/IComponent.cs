using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Interfaces
{
	internal interface IComponent
	{
		int PartId { get; set; }
		string PartName { get; set; }
		int AmountInstock { get; set; }
		string Condition { get; set; }


	}
}
