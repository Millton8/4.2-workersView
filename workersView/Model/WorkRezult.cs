﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workersView.Model
{
    public class WorkRezult
    {
        public long? ID { get; set; }
        public long? uniq { get; set; }
        public string? name { get; set; }
        public DateTime tBegin { get; set; }
        public string? project { get; set; }
        public DateTime tEnd { get; set; }
        public float timeOfWork { get; set; }
        public int price { get; set; }
        public decimal salary { get; set; }

        public WorkRezult()
        {
            
        }
        public WorkRezult(long ID, string name, string project)
        {
            this.ID = ID;
            this.name = name;
            this.tBegin = DateTime.Now;
            this.project = project;
        }

        
        public void AddInfo()
        {
            this.tEnd = DateTime.Now;
            this.timeOfWork = Convert.ToSingle((DateTime.Now - this.tBegin).TotalHours);
            this.salary = Convert.ToDecimal(price*timeOfWork);

        }
    }
}
