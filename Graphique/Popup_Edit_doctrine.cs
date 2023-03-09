using MarketDataAnalyser.Code.ClassPub;
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
    public partial class Popup_Edit_doctrine : Form
    {
        private Doctrine targetItem;
        private cConfig AppConfig;
        public Popup_Edit_doctrine(Doctrine target)
        {
            InitializeComponent();
            this.targetItem = target;
            this.AppConfig = cConfig.Instance;
            this.textBox1.Text = this.targetItem.Name;
            this.numericUpDown1.Value = this.targetItem.Seuil;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //save
            this.targetItem.Seuil = (int)this.numericUpDown1.Value;
            this.targetItem.Name = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //del
            if (AppConfig.Doctrines.Contains(targetItem))
                AppConfig.Doctrines.Remove(targetItem);
            this.DialogResult = DialogResult.OK;
        }
    }
}
