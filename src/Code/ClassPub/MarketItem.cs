using MarketDataAnalyser.Code.Divers;
using MarketDataAnalyser.Code.EVEAPI.Market;
using MarketDataAnalyser.EVEAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketDataAnalyser.Code.ClassPub
{
    public class MarketItem
    {

        public MarketItem()
        {
        }
        public MarketItem(MarketItem toCopy)
        {
            this.typeID = toCopy.typeID;
            this.Name = toCopy.Name;
            this.GroupName = toCopy.GroupName;
            this.Seuil = toCopy.Seuil;
            this.Volume = toCopy.Volume;
            this.VolumePerso = toCopy.VolumePerso;
            this._StationPrice = toCopy._StationPrice;
            this._myPrice = toCopy._myPrice;
            this.i_am_seller = toCopy.i_am_seller;
            this.BuyPrice = toCopy.BuyPrice;
            this.SellPrice = toCopy.SellPrice;

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
            var GroupNameResult = await EVEEsiInformation.Instance.GetGroupAsync(EsiTypeResult.GroupId);

            var temp = new MarketItem();
            temp.typeID = itemID;
            temp.Name = EsiTypeResult.Name;
            temp.GroupName = GroupNameResult.Name;



            if (cConfig.Instance.Data.ListItem.FirstOrDefault(i => i.typeID == itemID) == null)
            {
                cConfig.Instance.Data.ListItem.Add(temp);
                cConfig.Instance.SerialConfig();
            }
        }

        public int typeID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public long Seuil { get; set; }
        public long TotalSeuil()
        {
            long totalSeuil = this.Seuil;

            foreach (var doctrine in cConfig.Instance.Data.Doctrines)
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
        public long VolumeMissing()
        {
            var difference = TotalSeuil() - Volume;
            if (difference < 0)
                return 0;
            else
                return difference;
        }
        [JsonIgnore]
        public double _StationPrice { get; set; }
        public double StationPrice
        {
            get
            {
                if (_StationPrice == 0)
                    return SellPrice;
                else
                    return _StationPrice;
            }   // get method
            set { _StationPrice = value; }  // set method
        }

        [JsonIgnore]
        private double _myPrice;
        public double MyPrice
        {
            get {
                if (_myPrice == 0)
                    return SellPrice;
                else
                    return _myPrice; 
            }   // get method
            set { _myPrice = value; }  // set method
        }



        [JsonIgnore]
        public bool i_am_seller { get; set; }

        [JsonIgnore]
        public double BuyPrice { get; set; }
        [JsonIgnore]
        public double SellPrice { get; set; }


        public void CleanMarketInfo()
        {
            Volume = 0;
            VolumePerso = 0;
            StationPrice = 0;
            MyPrice = 0;
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

            BuyPrice = buyTask.Result * (double)cConfig.Instance.coefBuyerJita;
            SellPrice = sellTask.Result * (double)cConfig.Instance.coefSellerJita;
        }
    }
}
