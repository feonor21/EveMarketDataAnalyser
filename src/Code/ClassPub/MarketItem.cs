using MarketDataAnalyser.Code.Divers;
using MarketDataAnalyser.Code.EVEAPI.Market;
using MarketDataAnalyser.EVEAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Code.ClassPub
{
    public class MarketItem
    {

        public MarketItem()
        {
        }
        public static async Task CreateMarketItem(string ValueItem)
        {
            int itemID = 0;
            bool isInteger = int.TryParse(ValueItem, out itemID);

            if (!isInteger)
            {
                itemID = Retry.Do(() => FuzzWork.GetIdByName(ValueItem.Replace(" ", "%20")), TimeSpan.FromMilliseconds(50), 3);
                if (itemID == 0)
                    throw new Exception("Item inconnu");
            }

            var EsiTypeResult = await EVEEsiInformation.Instance.GetItemAsync(itemID);
            var temp = new MarketItem();
            temp.typeID = itemID;
            temp.Name = EsiTypeResult.Name;
            temp.GroupName = "Manual Added";



            if (cConfig.Instance.ListItem.FirstOrDefault(i => i.typeID == itemID) == null)
            {
                cConfig.Instance.ListItem.Add(temp);
                cConfig.Instance.SerialConfig();
            }
        }

        public int typeID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int Seuil { get; set; }
        public int TotalSeuil()
        {
            int totalSeuil = this.Seuil;

            foreach (var doctrine in cConfig.Instance.Doctrines)
            {
                foreach (var DoctrineLink in doctrine.DoctrineLinks.Where(x => x.typeID == this.typeID))
                {
                    totalSeuil += DoctrineLink.Quantity * doctrine.Seuil;
                }
            }
            return totalSeuil;
        }
        
        [JsonIgnore]
        public long Volume { get; set; }
        [JsonIgnore]
        public int VolumePerso { get; set; }
        [JsonIgnore]
        public decimal Price { get; set; }
        public string PriceParse()
        {
            if (Price == decimal.MaxValue)
                return "N/A";
            else
                return string.Format("{0:#,##0.##} ISK", Price); ;
        }
        [JsonIgnore]
        public decimal PricePerso { get; set; }
        public string PricePersoParse()
        {
            if (PricePerso == decimal.MaxValue)
                return "N/A";
            else
                return string.Format("{0:#,##0.##} ISK", PricePerso);
        }
        [JsonIgnore]
        public bool i_am_seller { get; set; }

        [JsonIgnore]
        public double BuyPrice { get; set; }
        public string BuyPriceParse()
        {
            return string.Format("{0:#,##0.##} ISK", BuyPrice);
        }
        [JsonIgnore]
        public double SellPrice { get; set; }
        public string SellPriceParse()
        {
            return string.Format("{0:#,##0.##} ISK", SellPrice);
        }

        public void CleanMarketInfo()
        {
            Volume = 0;
            VolumePerso = 0;
            Price = decimal.MaxValue;
            PricePerso = decimal.MaxValue;
            i_am_seller = false;
        }
        public async Task updatePrice()
        {
            //    var temp = EveMarketer.GetPrice(ItemId);
            //    BuyPrice = temp.buyer;
            //    SellPrice = temp.seller;

            var buyTask = HelpMarket.CalculatePercentileAsync(typeID, ESI.NET.Enumerations.MarketOrderType.Buy, 95);
            var sellTask = HelpMarket.CalculatePercentileAsync(typeID, ESI.NET.Enumerations.MarketOrderType.Sell, 95);

            await buyTask;
            await sellTask;

            BuyPrice = buyTask.Result;
            SellPrice = sellTask.Result;
        }
    }
}
