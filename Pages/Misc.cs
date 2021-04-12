using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Pages
{
    static public class Misc
    {
        public static List<T> AddMany<T>(this List<T> lstD, List<T> lstS, int idxFirst, int idxLast)
        {
            for (int i = idxFirst; i <= idxLast; i++)
                lstD.Add(lstS[i]);
            return lstD;
        }

    }
}
