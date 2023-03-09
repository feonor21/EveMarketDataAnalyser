using MarketDataAnalyser.EVEAPI;


namespace MarketDataAnalyser.Code.EVEAPI.Market
{
    static class HelpMarket
    {


        public static async Task<double> CalculatePercentileAsync(int typeId, ESI.NET.Enumerations.MarketOrderType OrderType = ESI.NET.Enumerations.MarketOrderType.Sell, int percentileSetpoint = 95, int regionID = 10000002)
        {
            List<orderPercentileProcessing> arrayOrder = await GetAllorderAsync(regionID, OrderType, typeId);
            return PercentileEveOrder(arrayOrder, percentileSetpoint);
        }
        public static async Task<List<orderPercentileProcessing>> GetAllorderAsync(int RegionID, ESI.NET.Enumerations.MarketOrderType sellorbuy, int typeID)
        {
            if (sellorbuy == ESI.NET.Enumerations.MarketOrderType.All)
            {
                return null;
            }

            //recuperation de tout les datas
            List<orderPercentileProcessing> array2 = new List<orderPercentileProcessing>();
            List<ESI.NET.Models.Market.Order> OrdersReponse = null;
            int page = 1;
            do
            {
                //compressed arkonmor a the forge
                OrdersReponse = await EVEEsiInformation.Instance.getOrderByregionAndTypeAsync(RegionID, sellorbuy, typeID, page);
                if (OrdersReponse != null)
                {
                    foreach (ESI.NET.Models.Market.Order order in OrdersReponse)
                    {
                        array2.Add(new orderPercentileProcessing() { value = order.Price, volume = order.VolumeRemain });
                    }
                }
                page++;
            } while (OrdersReponse != null);

            if (sellorbuy == ESI.NET.Enumerations.MarketOrderType.Sell)
            {
                array2 = array2.OrderByDescending(x => x.value).ToList();
                return array2;
            }
            else
            {
                array2 = array2.OrderBy(x => x.value).ToList();
                return array2;
            }



        }
        public static double PercentileEveOrder(List<orderPercentileProcessing> sequence, double percentileSetpoint)
        {
            long volume_global = 0;
            long volume_percentil = 0;

            double resultpercentil = 0;

            sequence.ForEach(x => volume_global += x.volume);
            
            volume_percentil = (long)((decimal)volume_global * (decimal)((100.0 - percentileSetpoint) / 100.0));

            long count = 0;
            foreach (orderPercentileProcessing item in sequence)
            {
                if (count < volume_percentil || ((count + item.volume) >= volume_percentil))
                    resultpercentil = (double)item.value;
                else
                    break;
                
                count += item.volume;
            }

            return resultpercentil;

        }





    }
    public class orderPercentileProcessing
    {
        public decimal value { get; set; }
        public long volume { get; set; }
    }
}
