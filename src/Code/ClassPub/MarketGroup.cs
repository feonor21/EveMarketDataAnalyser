using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAnalyser.Code.ClassPub
{
    public class MarketGroup
    {
        public string Name { get; set; }

        public List<MarketItem> items()
        {
            return cConfig.Instance.Data.ListItem.Where(x => x.GroupName == this.Name).ToList();            
        }
        
        public static List<MarketGroup> GetAllMarketGroup()
        {
            List<MarketGroup> result = new List<MarketGroup>();

            foreach (var item in cConfig.Instance.Data.ListItem)
            {
                if (!result.Any(x=>x.Name == item.GroupName))
                    result.Add(new MarketGroup() { Name = item.GroupName });
            }

            return result;
        }
    }
}
