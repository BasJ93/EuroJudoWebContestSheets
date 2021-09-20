using EuroJudoProtocols.ShowFights.Models;
using System.Collections.Generic;
using System.Linq;

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

        public ContestOrder(int tatami, IEnumerable<Contest> contests)
        {
            Tatami = tatami;
            Contests = contests.ToList();
        }
    }
}
