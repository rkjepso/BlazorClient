using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGloser.Services;
using Microsoft.AspNetCore.Components;

using BlazorClient.Model;
namespace BlazorClient.Pages
{
    public partial class Gloser 
    {
        static public readonly string strPageTesting = "Testing";

        //static public Data GetData() => _dt;
        //static public Data GetData() => _dt;

        [Inject]
        protected ILocalStorageService Storage { get; set; }

        Data dtTest = default;
        //private static Data _dt = new();
        //private static Data _dtTest = new();
        private Data Cfg
        {
            get {
                if (GetGloser()?.State == strPageTesting)
                    return dtTest.DefaultsForTest();
                else
                    return Storage.GetData();
            }
        }

        // public void SaveParams() => Storage.SetItem("__gloser", _dt);
        //public async Task LoadParams()
        //{
        //    try
        //    {
        //        _dt = await Storage.GetItem<Data>("__gloser");
        //        if (_dt.Equals(default(Data)))
        //            _dt.Default();
        //    }
        //    catch (Exception)
        //    {
        //        _dt.Default();
        //    }
        //    _dtTest = _dt;
        //    _dtTest.DefaultsForTest();
        //}

        public async void AddTest(Test t)
        {
            List<Test> lst = new();
            Test[] aTest;
            try
            {
                aTest = await Storage.GetItem<Test[]>("_tests_");
                lst = aTest.ToList();
            }
            catch (Exception)
            {
            }

            lst.Add(t);
            Storage.SetItemSync<Test[]>("_tests_", lst.ToArray());
        }

        private string StrToLang
        {
            get
            {
                return Cfg.LangToFrom switch
                {
                    LangToFrom.EngSpa => "Spanish",
                    LangToFrom.SpaEng => "English",
                    LangToFrom.NorSpa => "Spanish",
                    LangToFrom.SpaNor => "Norwegian",
                    _ => ""
                };
            }
        }
        private string StrFromLang
        {
            get
            {
                return Cfg.LangToFrom switch
                {
                    LangToFrom.EngSpa => "English",
                    LangToFrom.SpaEng => "Spanish",
                    LangToFrom.NorSpa => "Norwegian",
                    LangToFrom.SpaNor => "Spanish",
                    _ => ""
                };
            }
        }
    }


}


