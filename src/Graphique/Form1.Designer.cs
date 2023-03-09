namespace MarketDataAnalyser
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.esiTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.structureIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mode_MarketGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.Mode_Doctrine = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.ItemContent = new System.Windows.Forms.TextBox();
            this.btn_add_Item = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DoctrineContente = new System.Windows.Forms.TextBox();
            this.Doctrine_Add = new System.Windows.Forms.Button();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn3 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn4 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn5 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn9 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn10 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn6 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn7 = new BrightIdeasSoftware.OLVColumn();
            this.olvColumn8 = new BrightIdeasSoftware.OLVColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esiTokenToolStripMenuItem,
            this.structureIDToolStripMenuItem,
            this.Mode_MarketGroup,
            this.Mode_Doctrine});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // esiTokenToolStripMenuItem
            // 
            this.esiTokenToolStripMenuItem.Name = "esiTokenToolStripMenuItem";
            this.esiTokenToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.esiTokenToolStripMenuItem.Text = "Esi Token";
            this.esiTokenToolStripMenuItem.Click += new System.EventHandler(this.esiTokenToolStripMenuItem_Click);
            // 
            // structureIDToolStripMenuItem
            // 
            this.structureIDToolStripMenuItem.Name = "structureIDToolStripMenuItem";
            this.structureIDToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.structureIDToolStripMenuItem.Text = "Structure ID";
            this.structureIDToolStripMenuItem.Click += new System.EventHandler(this.structureIDToolStripMenuItem_Click);
            // 
            // Mode_MarketGroup
            // 
            this.Mode_MarketGroup.BackColor = System.Drawing.SystemColors.Window;
            this.Mode_MarketGroup.Name = "Mode_MarketGroup";
            this.Mode_MarketGroup.Size = new System.Drawing.Size(126, 20);
            this.Mode_MarketGroup.Text = "Mode Market Group";
            this.Mode_MarketGroup.Click += new System.EventHandler(this.Mode_MarketGroup_Click);
            // 
            // Mode_Doctrine
            // 
            this.Mode_Doctrine.Name = "Mode_Doctrine";
            this.Mode_Doctrine.Size = new System.Drawing.Size(98, 20);
            this.Mode_Doctrine.Text = "Mode Doctrine";
            this.Mode_Doctrine.Click += new System.EventHandler(this.Mode_Doctrine_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 467);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1234, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // ItemContent
            // 
            this.ItemContent.Location = new System.Drawing.Point(8, 51);
            this.ItemContent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ItemContent.Name = "ItemContent";
            this.ItemContent.Size = new System.Drawing.Size(211, 23);
            this.ItemContent.TabIndex = 3;
            // 
            // btn_add_Item
            // 
            this.btn_add_Item.Location = new System.Drawing.Point(131, 21);
            this.btn_add_Item.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_add_Item.Name = "btn_add_Item";
            this.btn_add_Item.Size = new System.Drawing.Size(88, 27);
            this.btn_add_Item.TabIndex = 5;
            this.btn_add_Item.Text = "Ajouter";
            this.btn_add_Item.UseVisualStyleBackColor = true;
            this.btn_add_Item.Click += new System.EventHandler(this.btn_add_Item_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item nom(ou ID)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DoctrineContente);
            this.groupBox1.Controls.Add(this.ItemContent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Doctrine_Add);
            this.groupBox1.Controls.Add(this.btn_add_Item);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(236, 443);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(86, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "OU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Copy Past doctrine";
            // 
            // DoctrineContente
            // 
            this.DoctrineContente.Location = new System.Drawing.Point(8, 127);
            this.DoctrineContente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DoctrineContente.Multiline = true;
            this.DoctrineContente.Name = "DoctrineContente";
            this.DoctrineContente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DoctrineContente.Size = new System.Drawing.Size(211, 282);
            this.DoctrineContente.TabIndex = 7;
            // 
            // Doctrine_Add
            // 
            this.Doctrine_Add.Location = new System.Drawing.Point(8, 415);
            this.Doctrine_Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Doctrine_Add.Name = "Doctrine_Add";
            this.Doctrine_Add.Size = new System.Drawing.Size(211, 27);
            this.Doctrine_Add.TabIndex = 5;
            this.Doctrine_Add.Text = "Ajouter un FUUUUUUU doctrine";
            this.Doctrine_Add.UseVisualStyleBackColor = true;
            this.Doctrine_Add.Click += new System.EventHandler(this.Doctrine_Add_ClickAsync);
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.AllColumns.Add(this.olvColumn3);
            this.treeListView1.AllColumns.Add(this.olvColumn4);
            this.treeListView1.AllColumns.Add(this.olvColumn5);
            this.treeListView1.AllColumns.Add(this.olvColumn9);
            this.treeListView1.AllColumns.Add(this.olvColumn10);
            this.treeListView1.AllColumns.Add(this.olvColumn6);
            this.treeListView1.AllColumns.Add(this.olvColumn7);
            this.treeListView1.AllColumns.Add(this.olvColumn8);
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn6,
            this.olvColumn7,
            this.olvColumn8});
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.Location = new System.Drawing.Point(236, 24);
            this.treeListView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(998, 443);
            this.treeListView1.TabIndex = 10;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListView1_FormatRow);
            this.treeListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseDoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Hideable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Text = "GroupName";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "TotalSeuil";
            this.olvColumn3.Hideable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.Searchable = false;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Seuil";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "VolumePerso";
            this.olvColumn4.AspectToStringFormat = "{0:#,##0}";
            this.olvColumn4.Hideable = false;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Text = "VolumePerso";
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Volume";
            this.olvColumn5.AspectToStringFormat = "{0:#,##0}";
            this.olvColumn5.Hideable = false;
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.Searchable = false;
            this.olvColumn5.Text = "Volume";
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "BuyPriceParse";
            this.olvColumn9.AspectToStringFormat = "";
            this.olvColumn9.Text = "BuyPrice";
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "SellPriceParse";
            this.olvColumn10.AspectToStringFormat = "";
            this.olvColumn10.Text = "SellPrice(+20%)";
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "PricePersoParse";
            this.olvColumn6.AspectToStringFormat = "";
            this.olvColumn6.Hideable = false;
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.Searchable = false;
            this.olvColumn6.Text = "PricePerso";
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "PriceParse";
            this.olvColumn7.AspectToStringFormat = "";
            this.olvColumn7.Hideable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.Searchable = false;
            this.olvColumn7.Text = "Price";
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "i_am_seller";
            this.olvColumn8.Hideable = false;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.Searchable = false;
            this.olvColumn8.Text = "i_am_seller";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 511);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1250, 550);
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem esiTokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem structureIDToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ItemContent;
        private System.Windows.Forms.Button btn_add_Item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem Mode_MarketGroup;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private ToolStripMenuItem Mode_Doctrine;
        private Button Doctrine_Add;
        private Label label3;
        private TextBox DoctrineContente;
        private Label label4;
    }
}

