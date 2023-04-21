using MarketDataAnalyser.Code.ClassPub;
using MarketDataAnalyser.EVEAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketDataAnalyser
{
    public partial class Popup_Edit_Item : Form
    {
        private MarketItem targetItem;
        private cConfig AppConfig;
        public Popup_Edit_Item(MarketItem  target)
        {
            InitializeComponent();
            this.targetItem = target;
            this.AppConfig = cConfig.Instance;
            this.label1.Text = this.targetItem.Name;
            this.numericUpDown1.Value = this.targetItem.Seuil;
            populateCombox();
        }

        private async void populateCombox()
        {
            this.comboBox1.Items.Clear();
            foreach (MarketGroup item in MarketGroup.GetAllMarketGroup())
            {
                if (!this.comboBox1.Items.Contains(item.Name)) { this.comboBox1.Items.Add(item.Name); };
            }

            this.comboBox1.SelectedItem = this.targetItem.GroupName;
            var itemEve = await EVEEsiInformation.Instance.GetItemAsync(targetItem.typeID);
            var groupEve = await EVEEsiInformation.Instance.GetGroupAsync(itemEve.GroupId);

            string groupname = groupEve.Name;
            if (!this.comboBox1.Items.Contains(groupname)) { this.comboBox1.Items.Add(groupname); };
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.targetItem.Seuil = (int)this.numericUpDown1.Value;
            this.targetItem.GroupName = this.comboBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AppConfig.Data.Doctrines.Any(x => x.DoctrineLinks.Any(y => y.typeID == targetItem.typeID)))
            {
                MessageBox.Show("l item est aussi dans une doctrine deleter la doctrine avant.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            if (AppConfig.Data.ListItem.Contains(targetItem))
                AppConfig.Data.ListItem.Remove(targetItem);
            this.DialogResult = DialogResult.OK;
        }
    }
}
