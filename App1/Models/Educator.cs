using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class Educator
    {
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
        public int Workload { get; set; }
        public bool Bonus { get; set; }

        public override string ToString() => $"{this.Name}\n{this.FacultyNumber}\n{this.Workload}\n{this.Bonus}";
    }
}
