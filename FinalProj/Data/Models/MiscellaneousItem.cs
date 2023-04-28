using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Interfaces;

// this class creates a miscellaneous item. A part ID, part name, amount in stock and condition are the attributes that make up a miscellaneous item in the context of this program. 

namespace FinalProj.Data.Models
{	// inherits from Icomponent interface 
	public class MiscellaneousItem : IComponent
	{
		private int partId;
		private string partName;
		private int amountInstock;
		private string condition;

		public int PartId { get => partId; set => partId = value; }
		public string PartName { get => partName; set => partName = value; }
		public int AmountInstock { get => amountInstock; set => amountInstock = value; }
		public string Condition { get => condition; set => condition = value; }
		
		// creates MiscellaneousItem object
		public MiscellaneousItem(int partId, string partName, int instock, string condition)
		{
			this.partId = partId;
			this.partName = partName;
			this.amountInstock = instock;
			this.condition = condition;
		}

		// constructor
		public MiscellaneousItem()
		{
		}
	}
}
