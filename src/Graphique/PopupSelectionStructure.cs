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

namespace MarketDataAnalyser.Graphique
{
    public partial class PopupSelectionStructure : Form
    {
        public cConfig AppConfig;


        public PopupSelectionStructure(cConfig aAppConfig)
        {
            AppConfig = aAppConfig;
            InitializeComponent();
            refreshdata();
        }

        public void affectestructureID(long ID)
        {
            //string result = Interaction.InputBox("ID de la structure cible", "MarketData", "1028858195912");
            AppConfig.structureID = ID;
        }


        public void refreshdata()
        {
            listBox1.Items.Clear();

            listBox1.DataSource = AppConfig.AllStructureId;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "structureID";


            auth_listBox1_SelectedValueChanged = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (AppConfig.AllStructureId != null)
            {
                foreach (var item in AppConfig.AllStructureId)
                {
                    if (item.structureID == numericUpDown1.Value)
                    {
                        button2.Text = "Update";
                        return;
                    }
                }
                button2.Text = "Add";
                return;
            }
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (EVEEsiInformation.Instance != null && EVEEsiInformation.Instance.token != null)
                {
                    await EVEEsiInformation.Instance.Connection(AppConfig.token,ESI.NET.Enumerations.GrantType.RefreshToken);
                    var temp = await EVEEsiInformation.Instance.GetStructureAsync((long)numericUpDown1.Value);
                    this.textBox1.Text = temp.Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "La station n'existe pas.","Attention", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            structure target = null;

            if (AppConfig.AllStructureId != null)
            {
                foreach (structure item in AppConfig.AllStructureId)
                {
                    if (item.structureID == numericUpDown1.Value)
                    {
                        target = item;
                        break;
                    }
                }
            }
            else
                AppConfig.AllStructureId = new List<structure>();

            if (target == null)
                target = new structure();
            else
                AppConfig.AllStructureId.Remove(target);

            target.name = textBox1.Text;
            target.structureID = (long)numericUpDown1.Value;

            AppConfig.AllStructureId.Add(target);

            refreshdata();
        }

        bool auth_listBox1_SelectedValueChanged = false;
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (auth_listBox1_SelectedValueChanged && listBox1.SelectedItem != null)
            {
                structure target = (structure)listBox1.SelectedItem;

                numericUpDown1.Value = target.structureID;
                textBox1.Text = target.name;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (auth_listBox1_SelectedValueChanged && listBox1.SelectedItem != null)
            {
                AppConfig.structureID = (long)numericUpDown1.Value;
                this.Close();
            }
        }
    }
}
