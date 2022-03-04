using System;
using System.Collections.Generic;

namespace EuroJudoWebContestSheets.Models
{
    public class ApiKey
    {
        public ApiKey()
        {
            
        }

        public int Id { get; set; }
        public string Owner { get; set; }
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public IList<string> Roles { get; set;  }
    }
}