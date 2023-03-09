using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Code.Divers
{
    public static class FuzzWork
    {
        public static int GetIdByName(string item)
        {
            try
            {

                var url = "https://www.fuzzwork.co.uk/api/typeid2.php?typename=" + item;
                dynamic resultqueryjson;
                using (WebClient client = new WebClient())
                {
                    resultqueryjson = JsonConvert.DeserializeObject(client.DownloadString(url));
                }
                return resultqueryjson[0].typeID;
            }
            catch (Exception)
            {
            }
            return 0;
        }
    }
}
