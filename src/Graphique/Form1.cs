﻿using BrightIdeasSoftware;
using ESI.NET;
using ESI.NET.Models.Assets;
using ESI.NET.Models.Character;
using EveMarketDataAnalyser.Code.ClassPub;
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

        List<ESI.NET.Models.Market.Order> orderglobal = new List<ESI.NET.Models.Market.Order>();

        public Form1()
        {
            InitializeComponent();

            AppConfig = cConfig.DeserialConfig();

            treeListViewCreate();
            treeListView1resize();


            RefreshMenu();



            this.Text = "MarketDataAnalyzer";
        }

        private async void esiTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Process process = new Process();

                var googlepath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

                if (File.Exists(googlepath))
                    process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                else
                    process.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";


                process.StartInfo.Arguments = EVEEsiInformation.GetUrlConnection();
                process.Start();

                string result = Interaction.InputBox("Code Retour ESI", "FleetLogLoot ADD", "xxxxxxxxxx");
                if (result != "")
                {
                    await EVEEsiInformation.Instance.Connection(result, ESI.NET.Enumerations.GrantType.AuthorizationCode);
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
            treeListView1resize();
        }
        private void Mode_Doctrine_Click(object sender, EventArgs e)
        {
            ModeMarket = 1;
            RefreshMenu();
            treeListView1resize();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = cConfig.getPathFile();
                // Ouvre l'explorateur de fichiers et sélectionne le fichier
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MarketDataAnalyser_DATA_" + DateTime.Now.ToString("yyyy_MM_dd") + ".json";
                AppConfig.ExportData(filePath);
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {

                // Vérifier si l'utilisateur veut remplacer les données existantes
                if (MessageBox.Show("Voulez-vous vraiment remplacer toutes les données existantes ?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Fichiers JSON (*.json)|*.json|Tous les fichiers (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lire le fichier JSON sélectionné par l'utilisateur
                        string jsonText = File.ReadAllText(openFileDialog.FileName);

                        // Désérialiser le JSON dans un objet Personne
                        cConfigData newData = JsonConvert.DeserializeObject<cConfigData>(jsonText);

                        AppConfig.Data = newData;

                        AppConfig.SerialConfig();
                    }
                }
                else
                {
                    MessageBox.Show("ptit péteux vas :P");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void exportStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MarketDataAnalyser_STRUCTURE_" + DateTime.Now.ToString("yyyy_MM_dd") + ".json";
                AppConfig.ExportStructure(filePath);
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si l'utilisateur veut remplacer les données existantes
                if (MessageBox.Show("Voulez-vous vraiment remplacer toutes les Structure existantes ?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Fichiers JSON (*.json)|*.json|Tous les fichiers (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lire le fichier JSON sélectionné par l'utilisateur
                        string jsonText = File.ReadAllText(openFileDialog.FileName);

                        // Désérialiser le JSON dans un objet Personne
                        List<Structure> newData = JsonConvert.DeserializeObject<List<Structure>>(jsonText);

                        AppConfig.AllStructureId = newData;

                        AppConfig.SerialConfig();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btn_add_Item_Click(object sender, EventArgs e)
        {
            await EVEEsiInformation.Instance.Connection(AppConfig.token, ESI.NET.Enumerations.GrantType.RefreshToken);
            var test = await EVEEsiInformation.Instance.GetStructureAsync(1041331926562);


            if (this.ItemContent.Text == "") { return; }

            try
            {
                await MarketItem.CreateMarketItem(this.ItemContent.Text);
                this.ItemContent.Text = "";
                RefreshMenu();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ERROR : Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error); }


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
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.DarkBlue;
            refreshMarketReel();


            this.button1.BackColor = Color.Gainsboro;
        }

        private void treeListViewCreate()
        {
            this.treeListView1.Columns.Clear();
            this.treeListView2.Columns.Clear();

            treeListViewCreateColumn(this.treeListView1, "Name", "Name", "", false);
            treeListViewCreateColumn(this.treeListView1, "Fit", "SeuilFit", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "Seuil", "TotalSeuil", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "MyVolume", "VolumePerso", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "Volume", "Volume", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "Missing", "VolumeMissing", "{0:#,##0}");

            treeListViewCreateColumn(this.treeListView1, "BuyPrice(JITA " + GetPercentageSignedString(AppConfig.coefBuyerJita) + ")", "BuyPrice", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "SellPrice(JITA " + GetPercentageSignedString(AppConfig.coefSellerJita) + ")", "SellPrice", "{0:#,##0}");

            treeListViewCreateColumn(this.treeListView1, "MyPrice", "MyPrice", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView1, "StationPrice", "StationPrice", "{0:#,##0}");

            treeListViewCreateColumn(this.treeListView2, "Name", "Name", "", false);
            treeListViewCreateColumn(this.treeListView2, "Fit", "SeuilFit", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "Seuil", "TotalSeuil", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "MyVolume", "VolumePerso", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "Volume", "Volume", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "Missing", "VolumeMissing", "{0:#,##0}");

            treeListViewCreateColumn(this.treeListView2, "BuyPrice(JITA " + GetPercentageSignedString(AppConfig.coefBuyerJita) + ")", "BuyPrice", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "SellPrice(JITA " + GetPercentageSignedString(AppConfig.coefSellerJita) + ")", "SellPrice", "{0:#,##0}");

            treeListViewCreateColumn(this.treeListView2, "MyPrice", "MyPrice", "{0:#,##0}");
            treeListViewCreateColumn(this.treeListView2, "StationPrice", "StationPrice", "{0:#,##0}");

            this.treeListView1.RebuildColumns();
            this.treeListView2.RebuildColumns();
        }
        private string GetPercentageSignedString(decimal value)
        {
            decimal variation = 0;
            if (value > 0)
                variation = (value - 1) * 100;
            if (value < 0)
                variation = (1 - value) * 100;

            if (variation > 0)
                return "+" + Math.Ceiling(variation).ToString() + "%";
            else if (variation < 0)
                return Math.Ceiling(variation).ToString() + "%";
            else
                return "";
        }
        private void treeListViewCreateColumn(TreeListView target, string HeaderText, string PropertyName, string format = "", bool hideable = true)
        {
            OLVColumn columnHeader = new BrightIdeasSoftware.OLVColumn();
            columnHeader.Width = 1;
            columnHeader.Text = HeaderText;
            columnHeader.AspectName = PropertyName;
            columnHeader.Hideable = hideable;
            columnHeader.Searchable = false;
            columnHeader.IsEditable = false;
            if (format != "")
                columnHeader.AspectToStringFormat = format;
            target.AllColumns.Add(columnHeader);

        }
        private void treeListView1resize()
        {
            treeListView1resize(this.treeListView1);
            treeListView1resize(this.treeListView2);
        }
        private void treeListView1resize(TreeListView target)
        {
            target.Columns[0].Width = (int)Math.Round((double)target.Width * 0.145);
            target.Columns[1].Width = (int)Math.Round((double)target.Width * 0.07);
            target.Columns[2].Width = (int)Math.Round((double)target.Width * 0.07);
            target.Columns[3].Width = (int)Math.Round((double)target.Width * 0.07);
            target.Columns[3].Width = (int)Math.Round((double)target.Width * 0.07);
            target.Columns[4].Width = (int)Math.Round((double)target.Width * 0.07);
            target.Columns[5].Width = (int)Math.Round((double)target.Width * 0.11);
            target.Columns[6].Width = (int)Math.Round((double)target.Width * 0.11);
            target.Columns[7].Width = (int)Math.Round((double)target.Width * 0.11);
            target.Columns[8].Width = (int)Math.Round((double)target.Width * 0.11);
            target.Columns[9].Width = (int)Math.Round((double)target.Width * 0.11);
            if (ModeMarket == 0)
            {
                target.Columns[1].Width = 0;
            }

        }



        private async void RefreshMenu()
        {
            if (AppConfig.token != null && AppConfig.token != "")
            {

                try
                {
                    await EVEEsiInformation.Instance.Connection(AppConfig.token, ESI.NET.Enumerations.GrantType.RefreshToken);

                    this.esiTokenToolStripMenuItem.Text = EVEEsiInformation.Instance.GetCharacterName();

                    if (AppConfig.structureID > 0)
                        this.structureIDToolStripMenuItem.Text = AppConfig.AllStructureId.Find(x => x.structureID == AppConfig.structureID).name;


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
                            this.treeListView1.SetObjects(AppConfig.Data.Doctrines);
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

                    button1.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur dans le token, peut etre expirer... refais ta connexion.\n\nSi ca marche toujours pas,\nContact Feo Les Bon Tuyau", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                }

            }
        }

        private async void refreshMarketReel()
        {
            RefreshMenu();
            treeListView1resize();
            SetPercentDone("Refresh loading...");

            orderglobal.Clear();

            foreach (var item in AppConfig.Data.ListItem)
            {
                item.CleanMarketInfo();
            }

            await refreshMarketReelMyOrderAsync();


            List<Task> alltask = new List<Task>();
            int parallelismeLimit = 5;
            for (int i = 1; i <= parallelismeLimit; i++)
            {
                alltask.Add(refreshMarketReelAllOrderTask(i, parallelismeLimit));
            }
            Task.WaitAll(alltask.ToArray());



            foreach (ESI.NET.Models.Market.Order item in orderglobal)
            {
                MarketItem itemmarket = AppConfig.Data.ListItem.FirstOrDefault(i => i.typeID == item.TypeId);
                if (!item.IsBuyOrder && itemmarket != null)
                {
                    itemmarket.Volume += item.VolumeRemain;

                    if (itemmarket.StationPrice == 0 || (double)item.Price < itemmarket.StationPrice) { itemmarket.StationPrice = (double)item.Price; }
                }
            }

            alltask = new List<Task>();
            foreach (MarketItem item in AppConfig.Data.ListItem)
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
                    var itemmarket = AppConfig.Data.ListItem.FirstOrDefault(i => i.typeID == item.TypeId);
                    if (itemmarket == null)
                    {
                        var EsiTypeResult = await EVEEsiInformation.Instance.GetItemAsync(item.TypeId);
                        itemmarket = new MarketItem() { typeID = item.TypeId, Name = EsiTypeResult.Name, StationPrice = double.MaxValue, MyPrice = double.MaxValue, GroupName = "Undifined" };
                        AppConfig.Data.ListItem.Add(itemmarket);
                    }

                    AppConfig.SerialConfig();

                    itemmarket.i_am_seller = true;
                    itemmarket.VolumePerso += item.VolumeRemain;
                    if (itemmarket.MyPrice == 0 || (double)item.Price < itemmarket.MyPrice) { itemmarket.MyPrice = (double)item.Price; }

                }
            }
        }
        private Task refreshMarketReelAllOrderTask(int initialpage, int step, int limit = 50000)
        {
            return Task.Run(async () =>
            {
                for (int i = initialpage; i <= limit; i += step)
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
                                    tmpmarket.StationPrice += (double)(order.Volume * order.Average);
                                }
                            }
                            if (AppConfig.Data.ListItem.FirstOrDefault(tmp => tmp.typeID == tmpmarket.typeID) != null)
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

                if (marketitem.Volume >= marketitem.TotalSeuil())
                    e.Item.BackColor = Color.ForestGreen;

                if (marketitem.Volume < marketitem.TotalSeuil())
                    e.Item.BackColor = Color.Orange;

                if (marketitem.Volume == 0)
                    e.Item.BackColor = Color.OrangeRed;

            }
            if (e.Model is Doctrine)
            {
                Doctrine doctrine = (Doctrine)e.Model;

                if (doctrine.Volume() >= doctrine.TotalSeuil())
                    e.Item.BackColor = Color.ForestGreen;

                if (doctrine.Volume() < doctrine.TotalSeuil())
                    e.Item.BackColor = Color.Orange;

                if (doctrine.Volume() == 0)
                    e.Item.BackColor = Color.OrangeRed;

            }

        }
        private void treeListView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.treeListView1.SelectedItem != null)
            {
                if (this.treeListView1.SelectedItem.RowObject is Doctrine)
                {
                    this.treeListView2.SetObjects(((Doctrine)this.treeListView1.SelectedItem.RowObject).items());
                }

                if (this.treeListView1.SelectedItem.RowObject is MarketGroup)
                {
                    this.treeListView2.SetObjects(((MarketGroup)this.treeListView1.SelectedItem.RowObject).items());
                }
            }
        }
        private void treeListView1_ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            if (ModeMarket == 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            MarketItem itemTarget = e.TargetModel as MarketItem;
            if (itemTarget == null)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;

        }
        private void treeListView1_ModelDropped(object sender, ModelDropEventArgs e)
        {
            // If they didn't drop on anything, then don't do anything
            if (e.TargetModel == null)
                return;


            MarketItem itemTarget = e.TargetModel as MarketItem;

            foreach (var item in e.SourceModels)
            {

                MarketItem itemSource = item as MarketItem;
                if (itemSource != null)
                    itemSource.GroupName = itemTarget.GroupName;
            }

            // Force them to refresh
            AppConfig.SerialConfig();
            e.RefreshObjects();
        }

        private void treeListView2_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Model is MarketItem)
            {
                MarketItem marketitem = (MarketItem)e.Model;

                if (marketitem.Volume >= marketitem.TotalSeuil())
                    e.Item.BackColor = Color.ForestGreen;

                if (marketitem.Volume < marketitem.TotalSeuil())
                    e.Item.BackColor = Color.Orange;

                if (marketitem.Volume == 0)
                    e.Item.BackColor = Color.OrangeRed;

            }
        }
    }
}
