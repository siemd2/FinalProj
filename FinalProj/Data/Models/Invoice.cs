using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Models
{
    public class Invoice
    {
        private int id;
        //private Service services;
        private double cost;
        private DateTime date;

        public int InvoiceId { get => id; set => id = value; }
        public double Cost { get => cost; set => cost = value; }
        public DateTime Date { get => date; set => date = value; }
        public List<Service> ServicesDone { get; set; } = new List<Service> { };
    }
}
