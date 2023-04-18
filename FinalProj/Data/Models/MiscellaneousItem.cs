using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Interfaces;

namespace FinalProj.Data.Models
{
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


    }
}
