using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Logic;
using ESI.NET.Models.Market;
using ESI.NET.Models.SSO;
using ESI.NET.Models.Universe;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketDataAnalyser.EVEAPI
{
    public class EVEEsiInformation
    {

        public EsiClient EsiClient;
        private AuthorizedCharacterData auth_char;
        public SsoToken token;

        private static EVEEsiInformation instance = null;
        private static readonly object padlock = new object();


        public static EVEEsiInformation Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new EVEEsiInformation(); }
                    return instance;
                }
            }
        }
        private EVEEsiInformation()
        {
            EsiClient = new EsiClient(getconfig());
        }


        public IOptions<EsiConfig> getconfig()
        {
            IOptions<EsiConfig> config = Options.Create(new EsiConfig()
            {
                EsiUrl = "https://esi.evetech.net/",
                DataSource = DataSource.Tranquility,
                ClientId = cConfig.Instance.EsiCLientId,
                SecretKey = cConfig.Instance.EsiSecret,
                CallbackUrl = "http://localhost/oauth-callback",
                UserAgent = "MARKETDATAANALYSER"
            });
            return config;
        }

        public static void CheckClientId()
        {
            if (cConfig.Instance.EsiCLientId == null)
            {
                string result = Interaction.InputBox("ESI ClientId", "Config Esi");
                if (result != "")
                {
                    cConfig.Instance.EsiCLientId = result;
                    cConfig.Instance.SerialConfig();
                }
            }

        }
        public static void CheckSecretKey()
        {
            if (cConfig.Instance.EsiSecret == null)
            {
                string result = Interaction.InputBox("ESI SecretKey", "Config Esi");
                if (result != "")
                {
                    cConfig.Instance.EsiSecret = result;
                    cConfig.Instance.SerialConfig();
                }
            }
            
        }

        public static string GetUrlConnection()
        {
            CheckClientId();
            CheckSecretKey();
            var stringscope = "";
            
            stringscope = "publicData\r\nesi-universe.read_structures.v1\r\nesi-markets.structure_markets.v1\r\nesi-markets.read_character_orders.v1";


            stringscope = stringscope.Replace("\r\n", "%20");
            var urlAUTH = "https://login.eveonline.com/v2/oauth/authorize/?response_type=code" +
                "&state=MARKETDATAANALYSER" +
                "&redirect_uri=http://localhost/oauth-callback" +
                "&client_id="+cConfig.Instance.EsiCLientId +
                "&scope="+stringscope;

            return urlAUTH;
        }

        public async Task Connection(string token,GrantType grantType)
        {
            try
            {
                this.token = await this.EsiClient.SSO.GetToken(grantType, token);
                this.auth_char = await this.EsiClient.SSO.Verify(this.token);
                this.EsiClient.SetCharacterData(auth_char);
                cConfig.Instance.token = this.token.RefreshToken;
            }
            catch (Exception ex)
            {
                throw ex; // "Erreur dans le code ESI!";
            }
        }


        public  string GetCharacterName()
        {
            return this.auth_char.CharacterName;
        }
        public int GetCharacterID()
        {
            try
            {
                return this.auth_char.CharacterID;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }


        public async Task<Structure> GetStructureAsync(long StructureID)
        {
            try
            {
                EsiResponse<ESI.NET.Models.Universe.Structure> StructureResponse = await this.EsiClient.Universe.Structure(StructureID);
                return StructureResponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<long[]> GetAllStructureAsync()
        {
            try
            {
                EsiResponse<long[]> OrdersReponse = await this.EsiClient.Universe.Structures();
                return OrdersReponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<Order>> GetStructureOrderAsync(long StructureID, int page)
        {
            try
            {
                EsiResponse<List<ESI.NET.Models.Market.Order>> OrdersReponse = await this.EsiClient.Market.StructureOrders(StructureID, page);
                return OrdersReponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Order>> GetCharacterOrderAsync()
        {
            try
            {
                EsiResponse<List<ESI.NET.Models.Market.Order>> OrdersReponse = await this.EsiClient.Market.CharacterOrders();
                return OrdersReponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Statistic>> GetStructureOrderHistoryAsync(int RegionID, int typeID)
        {
            try
            {
                EsiResponse<List<ESI.NET.Models.Market.Statistic>> OrdersReponse = await this.EsiClient.Market.TypeHistoryInRegion(RegionID, typeID);
                return OrdersReponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Order>> getOrderByregionAndTypeAsync(int RegionID, MarketOrderType sellorbuy ,  int typeID, int page=1)
        {
            try
            {
                EsiResponse<List<ESI.NET.Models.Market.Order>> OrdersReponse = await this.EsiClient.Market.RegionOrders(RegionID, sellorbuy, page,typeID);
                return OrdersReponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<ESI.NET.Models.Universe.Type> GetItemAsync(int ItemID)
        {
            try
            {
                EsiResponse<ESI.NET.Models.Universe.Type> ItemResponse = await this.EsiClient.Universe.Type(ItemID);
                return ItemResponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ESI.NET.Models.Universe.Group> GetGroupAsync(int GroupID)
        {
            try
            {
                EsiResponse<ESI.NET.Models.Universe.Group> ItemResponse = await this.EsiClient.Universe.Group(GroupID);
                return ItemResponse.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GetCharacterNameByIDAsync(int CharacterID)
        {
            try
            {
                EsiResponse<List<ESI.NET.Models.Character.Character>> response = await this.EsiClient.Character.Names(new int[] { CharacterID });
                return response.Data.First().Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
