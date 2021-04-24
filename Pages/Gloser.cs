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
        private static Data _dt = new();
        private static Data _dtTest = new();
        public  static Data Cfg 
        {
            get => GetGloser()?.state == "Testing" ? _dtTest : _dt;
        }

        static public Data GetData() => _dt;
  
        [Inject]
        protected ILocalStorageService Storage { get; set; }

        public void SaveParams() => Storage.SetItem("__gloser", _dt);
        public async Task LoadParams()
        {
            try
            {
                _dt = await Storage.GetItem<Data>("__gloser");
                if (_dt.Equals(default(Data)))
                    _dt.Default();
            }
            catch (Exception)
            {
                _dt.Default();
            }
            _dtTest = _dt;
            _dtTest.DefaultsForTest();
        }

        static string StrToLang
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
        static string StrFromLang
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


