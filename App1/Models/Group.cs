using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public string FacultyNumber { get; set; }
        public byte Course { get; set; }
        public bool IsBudget { get; set; }

        public override string ToString() => $"{this.GroupName}\n{this.FacultyNumber}\n{this.Course}";
    }
}
