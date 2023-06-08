using EveMarketDataAnalyser.Code.ClassPub;
using MarketDataAnalyser.Code.Divers;
using MarketDataAnalyser.EVEAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Code.ClassPub
{
    public class Doctrine
    {
        public Doctrine()
        {
        }
        public static async Task CreateDoctrine(string contente)
        {
            var temp = new Doctrine();
            Dictionary<string, int> doctrineFit = new Dictionary<string, int>();

            // Récupérer les lignes de la TextBox
            string[] lines = contente.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // recuperation du nom du vaisseau
            var shipraw = lines[0].Replace("[", "").Replace("]", "").Split(",");
            temp.Name = shipraw[1];
            temp.Seuil = 1;

            // Parcourir chaque ligne pour recuperer les item(text) et leur quantité
            doctrineFit.Add(shipraw[0], 1);
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {

                    int quantity = 0;
                    string itemName = "";

                    if (lines[i].Contains(" x"))
                    {
                        try
                        {

                            var itemraw = lines[i].Split(" x");
                            itemName = itemraw[0];
                            quantity = Convert.ToInt32(itemraw[1]);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        itemName = lines[i];
                        quantity = 1;
                    }

                    if (!doctrineFit.TryAdd(itemName, quantity))
                        doctrineFit[itemName] += quantity;

                }
            }

            foreach (var keypair in doctrineFit)
            {
                var itemID = Retry.Do(() => FuzzWork.GetIdByName(keypair.Key.Replace(" ", "%20")), TimeSpan.FromMilliseconds(50), 3);
                if (itemID == 0)
                    throw new Exception(keypair.Key + " item inconnu");

                if (cConfig.Instance.Data.ListItem.FirstOrDefault(i => i.typeID == itemID) == null)
                    await MarketItem.CreateMarketItem(itemID.ToString());

                temp.AddItemLink(itemID, keypair.Value);
            }

            if (cConfig.Instance.Data.Doctrines.FirstOrDefault(i => i.Name == temp.Name) != null)
                cConfig.Instance.Data.Doctrines.Remove(cConfig.Instance.Data.Doctrines.FirstOrDefault(i => i.Name == temp.Name));

            cConfig.Instance.Data.Doctrines.Add(temp);

            cConfig.Instance.SerialConfig();
        }

        public string Name { get; set; }
        
        public List<DoctrineItemLink> DoctrineLinks = new List<DoctrineItemLink>();
        public long Seuil { get; set; }
        public long TotalSeuil()
        {
            return Seuil;
        }
        public void AddItemLink(int marketItemID, int quantity)
        {
            DoctrineLinks.Add(new DoctrineItemLink { typeID = marketItemID, Quantity = quantity });
        }
        public List<DoctrineItem> items()
        {
            List<DoctrineItem> result = new List<DoctrineItem>();
            foreach (var i in DoctrineLinks)
            {
                result.Add(new DoctrineItem(cConfig.Instance.Data.ListItem.First(x => x.typeID == i.typeID),i.Quantity));
            }
            return result;
        }
        public long Volume()
        {
            int minimum = 9999999;

            
            foreach (var DoctrineLink in DoctrineLinks)
            {
                var volumeItem = cConfig.Instance.Data.ListItem.Find(x => x.typeID == DoctrineLink.typeID).Volume;
                var quantitySeuil = DoctrineLink.Quantity;
                var ResultRaw = volumeItem / quantitySeuil;
                if(ResultRaw < minimum) 
                    minimum = (int)Math.Ceiling((decimal)ResultRaw);
            }


            return minimum;
        }
        public long VolumeMissing()
        {
            var difference = TotalSeuil() - Volume();
            if (difference < 0)
                return 0;
            else
                return difference;
        }

        public double Price()
        {
            double Price = 0;
            foreach (var DoctrineLink in DoctrineLinks)
            {
                var price = cConfig.Instance.Data.ListItem.Find(x => x.typeID == DoctrineLink.typeID).StationPrice;
                Price += price * DoctrineLink.Quantity;
            }
            return Price;
        }
        public double StationPrice()
        {
            double Price = 0;
            foreach (var DoctrineLink in DoctrineLinks)
            {
                var price = cConfig.Instance.Data.ListItem.Find(x => x.typeID == DoctrineLink.typeID).StationPrice;
                Price += price * DoctrineLink.Quantity;
            }
            return Price;
        }
        public double BuyPrice()
        {
            double Price = 0;
            foreach (var DoctrineLink in DoctrineLinks)
            {
                var price = cConfig.Instance.Data.ListItem.Find(x => x.typeID == DoctrineLink.typeID).BuyPrice;
                Price += price * DoctrineLink.Quantity;
            }
            return Price;
        }
        public double SellPrice()
        {
            double Price = 0;
            foreach (var DoctrineLink in DoctrineLinks)
            {
                var price = cConfig.Instance.Data.ListItem.Find(x => x.typeID == DoctrineLink.typeID).SellPrice;
                Price += price * DoctrineLink.Quantity;
            }
            return Price;
        }
    }

    public class DoctrineItemLink
    {
        public int typeID { get; set; }
        public int Quantity { get; set; }
    }

}
