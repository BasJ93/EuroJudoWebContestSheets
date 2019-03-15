using System;
using System.Collections.Generic;
using System.Text;

namespace EJUPublisher.Models
{
    public class ContestOrder
    {
        public int Tatami { get; set; }
        public List<Contest> Contests { get; set; }

        public ContestOrder()
        {
            Contests = new List<Contest>();
        }
    }
}
