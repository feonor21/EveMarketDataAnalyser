using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Code.Divers
{
    public static class EveMarketer
    {
        public static EveMarketerPrice GetPrice(int typeID)
        {
            try
            {
                var url = "https://api.evemarketer.com/ec/marketstat/json?usesystem=30000142&typeid=" + typeID;
                dynamic resultqueryjson;

                using (WebClient client = new WebClient())
                {
                    resultqueryjson = JsonConvert.DeserializeObject(client.DownloadString(url));
                }
                
                return new EveMarketerPrice() { buyer = resultqueryjson[0].buy.fivePercent.Value, seller = resultqueryjson[0].sell.fivePercent.Value };

            }
            catch (Exception)
            {
                return new EveMarketerPrice();
            }

        }

    }
    public class EveMarketerPrice{
        public double buyer;
        public double seller;
    }
}
