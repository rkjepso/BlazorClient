using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Model
{
    public enum LangToFrom { EngSpa, SpaEng, NorSpa, SpaNor };
    public enum Order { Sequental, Random, Artif_Int };
    public enum Auto { Auto500ms = 500, Auto1s = 1000, Auto2s = 2000, Auto3s = 3000, Auto5s = 5000, Manual = 0 };
    public enum Mode { Scrolling, OneByOne, All_Time, All_Now, All_Man };

    // State variables 
    [Serializable]
    public struct Data
    {
        public Mode Mode { get; set; }
        public LangToFrom LangToFrom { get; set; }

        public Order Order { get; set; }
        public Auto Auto { get; set; }
        public int SecThink { get; set; }
        public int NumBatch { get; set; }
        public int TotalWords { get; set; }
        public int IdxStart { get; set; }
        public int Step { get; set; }

        public void Default()
        {
            Mode = (Mode.OneByOne);
            LangToFrom = (LangToFrom.SpaNor);
            Order = (Order.Sequental);
            Auto = (Auto.Auto1s);
            SecThink = 2000;
            NumBatch = 3;
            TotalWords = 1000;
            IdxStart = 0;
            Step = 25;
        }

        public void DefaultsForTest()
        {
            Mode = (Mode.OneByOne);
            Order = (Order.Sequental);
            NumBatch = 5;
            Step = 10;
            SecThink = 500;
        }

    }
    public class Config
    {
    }
}
