using BrightIdeasSoftware;
using ESI.NET.Models.Assets;
using MarketDataAnalyser.Code.ClassPub;
using MarketDataAnalyser.Code.Divers;
using MarketDataAnalyser.EVEAPI;
using MarketDataAnalyser.Graphique;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarketDataAnalyser
{
    public partial class Form1 : Form
    {
        public cConfig AppConfig;

        public int ModeMarket = 0;
        public bool CharAuthAndConnected = false;

        List<ESI.NET.Models.Market.Order> orderglobal = new List<ESI.NET.Models.Market.Order>();

        public Form1()
        {
            InitializeComponent();



            
            treeListView1resize();

            AppConfig = cConfig.DeserialConfig();

            RefreshMenu();


            this.Text = "MarketDataAnalyzer V2.3.0";
        }

        private void esiTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                process.StartInfo.Arguments = EVEEsiInformation.GetUrlConnection();
                process.Start();
                
                string result = Interaction.InputBox("Code Retour ESI", "FleetLogLoot ADD", "xxxxxxxxxx");
                if (result != "")
                {
                    EVEEsiInformation.Instance.Connection(result,ESI.NET.Enumerations.GrantType.AuthorizationCode);
                    AppConfig.SerialConfig();
                    RefreshMenu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dans la creation de la liaison ESI! \n" + ex.Message);
            }
            finally
            {
            }
        }
        private void structureIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphique.PopupSelectionStructure tmp = new Graphique.PopupSelectionStructure(AppConfig))
                {
                    tmp.ShowDialog();
                }

                RefreshMenu();
                AppConfig.SerialConfig();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dans la creation de la liaison ESI! \n" + ex.Message);
            }
        }
        
        private void Mode_MarketGroup_Click(object sender, EventArgs e)
        {
            ModeMarket = 0;
            RefreshMenu();
        }
        private void Mode_Doctrine_Click(object sender, EventArgs e)
        {
            ModeMarket = 1;
            RefreshMenu();
        }

        private async void btn_add_Item_Click(object sender, EventArgs e)
        {
            if (this.ItemContent.Text == "") { return; }

            try
            {
                await MarketItem.CreateMarketItem(this.ItemContent.Text);
                this.ItemContent.Text = "";
                RefreshMenu();
            }
            catch (Exception ex )
            {MessageBox.Show(ex.Message, "ERROR : Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            

        }
        private async void Doctrine_Add_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (this.DoctrineContente.Text == "") { return; }

                await Doctrine.CreateDoctrine(this.DoctrineContente.Text);
                this.DoctrineContente.Text = "";
                RefreshMenu();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ERROR : Add Doctrine", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void treeListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.treeListView1.SelectedItem != null)
            {

                if (this.treeListView1.SelectedItem.RowObject is MarketItem)
                {
                    try
                    {
                        MarketItem marketitemtarget = (MarketItem)this.treeListView1.SelectedItem.RowObject;
                        using (Popup_Edit_Item tmp = new Popup_Edit_Item(marketitemtarget))
                        {
                            tmp.ShowDialog();
                        }
                        AppConfig.SerialConfig();
                        RefreshMenu();
                    }
                    catch (Exception)
                    {

                    }
                }

                if (this.treeListView1.SelectedItem.RowObject is Doctrine)
                {

                    try
                    {
                        Doctrine doctrine = (Doctrine)this.treeListView1.SelectedItem.RowObject;
                        using (Popup_Edit_doctrine tmp = new Popup_Edit_doctrine(doctrine))
                        {
                            tmp.ShowDialog();
                        }
                        AppConfig.SerialConfig();
                        RefreshMenu();
                    }
                    catch (Exception)
                    {

                    }
                }

            }
        }
        private void treeListView1_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if (e.Model is MarketItem)
            {
                MarketItem marketitem = (MarketItem)e.Model;

                if (marketitem.Volume < marketitem.Seuil)
                {
                    
                    e.Item.BackColor = Color.Bisque;
                    if (marketitem.i_am_seller && marketitem.PricePerso != marketitem.Price)
                        e.Item.BackColor = Color.LightSkyBlue;

                    if (marketitem.i_am_seller && marketitem.PricePerso == marketitem.Price)
                        e.Item.BackColor = Color.DarkKhaki;

                }
                else
                {
                    
                    e.Item.BackColor = Color.Violet;
                    if (marketitem.i_am_seller && marketitem.PricePerso != marketitem.Price)
                        e.Item.BackColor = Color.RoyalBlue;

                    if (marketitem.i_am_seller && marketitem.PricePerso == marketitem.Price)
                        e.Item.BackColor = Color.LimeGreen;

                }
            }
            if (e.Model is Doctrine)
            {
                Doctrine doctrine = (Doctrine)e.Model;

                if (doctrine.Volume() < doctrine.Seuil)
                    e.Item.BackColor = Color.Bisque;
                else
                    e.Item.BackColor = Color.LimeGreen;

            }

        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.DarkBlue;
            refreshMarketReel();


            this.button1.BackColor = Color.Gainsboro;
        }

        private async void RefreshMenu()
        {
            if (AppConfig.token != null)
            {
                await EVEEsiInformation.Instance.Connection(AppConfig.token, ESI.NET.Enumerations.GrantType.RefreshToken);

                try
                {
                    this.esiTokenToolStripMenuItem.Text = EVEEsiInformation.Instance.GetCharacterName();

                    if (AppConfig.structureID > 0)
                        this.structureIDToolStripMenuItem.Text = AppConfig.AllStructureId.Find(x=>x.structureID== AppConfig.structureID).name;


                    switch (ModeMarket)
                    {
                        case 1:
                            this.treeListView1.CanExpandGetter = delegate (Object x) { return (x is Doctrine); };
                            this.treeListView1.ChildrenGetter = delegate (object x)
                            {
                                if (x is Doctrine)
                                    return ((Doctrine)x).items();

                                throw new ArgumentException("should be Doctrine");
                            };
                            this.treeListView1.SetObjects(AppConfig.Doctrines);
                            //this.treeListView1.CollapseAll();
                            this.Mode_Doctrine.BackColor = Color.DarkGreen;
                            this.Mode_MarketGroup.BackColor = Color.WhiteSmoke;
                            break;
                        default:
                            this.treeListView1.CanExpandGetter = delegate (Object x) { return (x is MarketGroup); };
                            this.treeListView1.ChildrenGetter = delegate (object x)
                            {
                                if (x is MarketGroup)
                                    return ((MarketGroup)x).items();
                                
                                throw new ArgumentException("should be group");
                            };
                            this.treeListView1.SetObjects(MarketGroup.GetAllMarketGroup());
                            //this.treeListView1.ExpandAll();
                            //for (int i = 0; i < this.treeListView1.Items.Count; i++)
                            //{
                            //    var grp = this.treeListView1.Items[i];
                            //    if (grp.Text == "Undifined")
                            //        this.treeListView1.Collapse(this.treeListView1.GetModelObject(grp.Index));
                            //}
                            //this.treeListView1.CollapseAll();
                            this.Mode_Doctrine.BackColor = Color.WhiteSmoke;
                            this.Mode_MarketGroup.BackColor = Color.DarkGreen;
                            break;
                    }
                    

                    CharAuthAndConnected = true;
                }
                catch (Exception)
                {
                    CharAuthAndConnected = false;
                }

            }
        }

        private void treeListView1resize()
        {
            this.treeListView1.Columns[0].Width = (int)Math.Round((double)this.treeListView1.Width * 0.15);
            this.treeListView1.Columns[1].Width = (int)Math.Round((double)this.treeListView1.Width * 0.10);
            this.treeListView1.Columns[2].Width = (int)Math.Round((double)this.treeListView1.Width * 0.10);
            this.treeListView1.Columns[3].Width = (int)Math.Round((double)this.treeListView1.Width * 0.10);
            this.treeListView1.Columns[4].Width = (int)Math.Round((double)this.treeListView1.Width * 0.125);
            this.treeListView1.Columns[5].Width = (int)Math.Round((double)this.treeListView1.Width * 0.125);
            this.treeListView1.Columns[6].Width = (int)Math.Round((double)this.treeListView1.Width * 0.125);
            this.treeListView1.Columns[7].Width = (int)Math.Round((double)this.treeListView1.Width * 0.125);
            this.treeListView1.Columns[8].Width = 0;
        }
 
        private async void refreshMarketReel()
        {
            RefreshMenu();
            treeListView1resize();
            SetPercentDone("Refresh loading...");

            orderglobal.Clear();

            foreach (var item in AppConfig.ListItem)
            {
                item.CleanMarketInfo();
            }

            await refreshMarketReelMyOrderAsync();


            List <Task> alltask = new List<Task>();
            int parallelismeLimit = 5;
            for (int i = 1; i <= parallelismeLimit; i++)
            {
                alltask.Add(refreshMarketReelAllOrderTask(i, parallelismeLimit));
            }
            Task.WaitAll(alltask.ToArray());



            foreach (ESI.NET.Models.Market.Order item in orderglobal)
            {
                MarketItem itemmarket = AppConfig.ListItem.FirstOrDefault(i => i.typeID == item.TypeId);
                if (!item.IsBuyOrder && itemmarket != null)
                {
                    itemmarket.Volume += item.VolumeRemain;
                    if (item.Price < itemmarket.Price) { itemmarket.Price = item.Price; }
                }
            }

            alltask = new List<Task>();
            foreach (MarketItem item in AppConfig.ListItem)
            {
                alltask.Add(Task.Run(async () =>
                {
                    await item.updatePrice();
                    return Task.CompletedTask;
                }));
            }
            Task.WaitAll(alltask.ToArray());
            
            SetPercentDone("Refresh");
            
            AppConfig.SerialConfig();

        }
        private async Task refreshMarketReelMyOrderAsync()
        {
            List<ESI.NET.Models.Market.Order> orderperso = new List<ESI.NET.Models.Market.Order>();
            List<ESI.NET.Models.Market.Order> orderpage = new List<ESI.NET.Models.Market.Order>();
            orderpage = await EVEEsiInformation.Instance.GetCharacterOrderAsync();
            if (!(orderpage == null)) { orderperso.AddRange(orderpage); }

            foreach (ESI.NET.Models.Market.Order item in orderperso)
            {
                if (!item.IsBuyOrder && item.LocationId == AppConfig.structureID)
                {
                    var itemmarket = AppConfig.ListItem.FirstOrDefault(i => i.typeID == item.TypeId);
                    if (itemmarket == null)
                    {
                        var EsiTypeResult = await EVEEsiInformation.Instance.GetItemAsync(item.TypeId);
                        itemmarket = new MarketItem() { typeID = item.TypeId, Name = EsiTypeResult.Name, Price = decimal.MaxValue, PricePerso = decimal.MaxValue, GroupName = "Undifined" };
                        AppConfig.ListItem.Add(itemmarket);
                    }

                    AppConfig.SerialConfig();

                    itemmarket.i_am_seller = true;
                    itemmarket.VolumePerso += item.VolumeRemain;
                    if (item.Price < itemmarket.PricePerso) { itemmarket.PricePerso = item.Price; }

                }
            }
        }
        private Task refreshMarketReelAllOrderTask(int initialpage,int step,int limit =5000)
        {
            return Task.Run(async () =>
            {               
             
                for (int i = initialpage; i <= limit; i+= step)
                {
                    var orderpage = await EVEEsiInformation.Instance.GetStructureOrderAsync(AppConfig.structureID, i);
                    if (orderpage != null)
                        orderglobal.AddRange(orderpage);
                    else
                        break;
                }
            });
        }

        private async void refreshMarketHistory()
        {
            treeListView1resize();
            SetPercentDone("Launch analyse");


            List<MarketItem> ListItemAnalyser = new List<MarketItem>();
            await Task.Run(async () =>
            {
                int regionId = 10000010;
                List<int> AllTypeID = new List<int>();

                SetPercentDone("Analyse TypeID en cours");
                var url = "https://eve-files.com/chribba/typeid.txt";
                string resultquerystring;
                using (WebClient client = new WebClient())
                {
                    resultquerystring = client.DownloadString(url);
                }
                string[] AllLine = resultquerystring.Split('\n');
                SetPercentDone("TypeID Depopulate Fichier de merde");
                for (int i = 0; i <= 2; i++) { AllLine[i] = ""; }
                foreach (string line in AllLine)
                {
                    if (line == "") { continue; }
                    if (line.Contains("Blueprint")) { continue; }
                    try
                    {
                        AllTypeID.Add(int.Parse(line.Split(' ')[0]));
                    }
                    catch (Exception)
                    {
                    }
                }

                SetPercentDone("Vive les poneys");
                for (int i = 0; i < AllTypeID.Count; i++)
                {
                    MarketItem tmpmarket = new MarketItem();
                    tmpmarket.typeID = AllTypeID[i];
                    ESI.NET.Models.Universe.Type ItemEsi = await EVEEsiInformation.Instance.GetItemAsync(tmpmarket.typeID);
                    if (ItemEsi != null && ItemEsi.Published && ItemEsi.MarketGroupId > 0)
                    {
                        tmpmarket.Name = ItemEsi.Name;
                        List<ESI.NET.Models.Market.Statistic> OrdersReponse = await EVEEsiInformation.Instance.GetStructureOrderHistoryAsync(regionId, ItemEsi.TypeId);
                        if (OrdersReponse != null)
                        {
                            foreach (ESI.NET.Models.Market.Statistic order in OrdersReponse)
                            {
                                if (order.Date >= DateTime.Now.Date.AddDays(-30))
                                {
                                    tmpmarket.Volume += order.Volume;
                                    tmpmarket.Price += (decimal)(order.Volume * order.Average);
                                }
                            }
                            if (AppConfig.ListItem.FirstOrDefault(tmp => tmp.typeID == tmpmarket.typeID) != null)
                            {
                                tmpmarket.i_am_seller = true;
                            }


                             if (tmpmarket.Volume > 0)
                            {
                                ListItemAnalyser.Add(tmpmarket);
                                this.treeListView1.SetObjects(ListItemAnalyser);
                            }

                        }
                    }
                    SetPercentDone("Analyse en cours = > " + i.ToString("#,##0") + "/" + AllTypeID.Count.ToString("#,##0"));
                }
            });

            SetPercentDone("Refresh");
            this.button1.Enabled = true;
        }

        private void SetPercentDone(string txt)
        {
            if (this.button1.InvokeRequired)
            {
                this.button1.Invoke(new Action(() => 
                {
                    this.button1.Text = txt;
                    this.button1.Enabled = (txt == "Refresh");
                }));
            }
            else
            {
                this.button1.Text = txt;
                this.button1.Enabled = (txt == "Refresh");
            }
        }

    }
}
