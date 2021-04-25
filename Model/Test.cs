using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Model
{
    [Serializable]
    public class Test
    {
        public string Name { get; set; }
        public DateTime Dt { get; set; }
        public int MaxScore { get; set; }
        public int Score { get; set; }
    }
}
