using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
    public class Vehicle
    {
        private int vin;
        private string makeModelYear;
        private string lastServiceDate;

        public int Vin { get => vin; set => vin = value; }
        public string MakeModelYear { get => makeModelYear; set => makeModelYear = value; }
        public string LastServiceDate { get => lastServiceDate; set => lastServiceDate = value; }
    }
}
