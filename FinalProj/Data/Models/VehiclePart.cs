using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Interfaces;

namespace FinalProj.Data.Models
{
    public class VehiclePart : IComponent
    {
        private int partId;
        private string partName;
        private int amountInstock;
        private string condition;
        private string arriveDate;
        private string makeModelYear;

        public int PartId { get => partId; set => partId = value; }
        public string PartName { get => partName; set => partName = value; }
        public int AmountInstock { get => amountInstock; set => amountInstock = value; }
        public string Condition { get => condition; set => condition = value; }
		public string ArriveDate { get => arriveDate; set => arriveDate = value; }
		public string MakeModelYear { get => makeModelYear; set => makeModelYear = value; }

        public VehiclePart(int partId, string partName, int amountInstock, string condition, string arriveDate, string mmm)
        {
            this.partId = partId;
            this.partName = partName;
            this.amountInstock = amountInstock;
            this.condition = condition;
            this.arriveDate = arriveDate;
            makeModelYear = mmm;
        }

        public VehiclePart() { }
	}
}
