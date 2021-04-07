using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGloser.Services;
using Microsoft.AspNetCore.Components;


namespace BlazorClient.Pages
{
    public enum LangToFrom  { EngSpa, SpaEng };
    public enum Order       { Sequental, Random, Artif_Int };
    public enum Auto        { Auto500ms = 500, Auto1s = 1000, Auto2s = 2000, Auto3s = 3000, Auto5s = 5000, Manual = 0 };
    public enum Mode        { Scrolling, OneByOne, All_Time, All_Now, All_Man };

    // State variables 
    [Serializable]
    public struct Data
    {
        public Mode Mode       {get; set;}
        public LangToFrom LangToFrom {get; set; } 

        public Order Order     { get; set; }
        public Auto Auto       { get; set; }
        public int  SecThink   { get; set; } 
        public int  NumBatch   { get; set; }
        public int  NTotal     { get; set; }

        public void Default()
        {
            Mode = ( Mode.OneByOne);
            LangToFrom = (LangToFrom.EngSpa);
            Order = (Order.Sequental);
            Auto = ( Auto.Auto1s);
            SecThink = 2000;
            NumBatch = 3;
            NTotal = 50;
        }

    }

    public partial class Gloser 
    {
        static public Data dt = new ();
        static public Data GetData()
        {
            return dt;
        }
        [Inject]
        protected ILocalStorageService Storage { get; set; }

        public void SaveParams() => Storage.SetItem("__gloser", dt);
        public async void LoadParams()
        {
            try
            {
                dt = await Storage.GetItem<Data>("__gloser");
                if (dt.Equals(default(Data)))
                    dt.Default();
            }
            catch (Exception)
            {
                dt.Default();
            }

        }

        static string StrToLang
        {
            get
            {
                return dt.LangToFrom switch
                {
                    LangToFrom.EngSpa => "Spanish",
                    LangToFrom.SpaEng => "English",
                    _ => ""
                };
            }
        }
        static string StrFromLang
        {
            get
            {
                return dt.LangToFrom switch
                {
                    LangToFrom.EngSpa => "English",
                    LangToFrom.SpaEng => "Spanish",
                    _ => ""
                };
            }
        }
    }


}


