using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
    public class Service
    {
        private int id;
        private string name;
        private VehiclePart part;
        private MiscellaneousItem miscellaneousItem;
        //private VehiclePart vehiclePart;
        private string timeRequire;
        private double cost;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public VehiclePart Part { get => part; set => part = value; }
        public MiscellaneousItem MiscellaneousItem { get => miscellaneousItem; set => miscellaneousItem = value; }
        //public VehiclePart VehiclePart { get => vehiclePart; set => vehiclePart = value; }
        public string TimeRequire { get => timeRequire; set => timeRequire = value; }
        public double Cost { get => cost; set => cost = value; }
    }
}
