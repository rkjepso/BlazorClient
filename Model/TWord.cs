using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGloser.Model
{
    [Serializable]
    public class TWord
    {
        public int ID { get; set; }
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Norwegian { get; set; }
        public string FromWord { get; set; }
        public string ToWord { get; set; }
        public string ToWordAns { get; set; }
        public bool IsCorrect { get; set; }

        // For AI usage level.
        public int Level { get; set; }
    }
}
