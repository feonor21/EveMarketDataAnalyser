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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            parametreToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exportStructureToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            esiTokenToolStripMenuItem = new ToolStripMenuItem();
            structureIDToolStripMenuItem = new ToolStripMenuItem();
            Mode_MarketGroup = new ToolStripMenuItem();
            Mode_Doctrine = new ToolStripMenuItem();
            button1 = new Button();
            ItemContent = new TextBox();
            btn_add_Item = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            DoctrineContente = new TextBox();
            Doctrine_Add = new Button();
            treeListView1 = new BrightIdeasSoftware.TreeListView();
            panel1 = new Panel();
            treeListView2 = new BrightIdeasSoftware.TreeListView();
            tableLayoutPanel1 = new TableLayoutPanel();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeListView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeListView2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { parametreToolStripMenuItem, esiTokenToolStripMenuItem, structureIDToolStripMenuItem, Mode_MarketGroup, Mode_Doctrine });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1551, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // parametreToolStripMenuItem
            // 
            parametreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator1, toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator2, exportStructureToolStripMenuItem, toolStripMenuItem4 });
            parametreToolStripMenuItem.Name = "parametreToolStripMenuItem";
            parametreToolStripMenuItem.Size = new Size(55, 20);
            parametreToolStripMenuItem.Text = "Config";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(161, 22);
            toolStripMenuItem1.Text = "Show Config.ini";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(158, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(161, 22);
            toolStripMenuItem2.Text = "Export Data";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(161, 22);
            toolStripMenuItem3.Text = "Import Data";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(158, 6);
            // 
            // exportStructureToolStripMenuItem
            // 
            exportStructureToolStripMenuItem.Name = "exportStructureToolStripMenuItem";
            exportStructureToolStripMenuItem.Size = new Size(161, 22);
            exportStructureToolStripMenuItem.Text = "Export Structure";
            exportStructureToolStripMenuItem.Click += exportStructureToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(161, 22);
            toolStripMenuItem4.Text = "Import Structure";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // esiTokenToolStripMenuItem
            // 
            esiTokenToolStripMenuItem.Name = "esiTokenToolStripMenuItem";
            esiTokenToolStripMenuItem.Size = new Size(148, 20);
            esiTokenToolStripMenuItem.Text = "Character Esi Connexion";
            esiTokenToolStripMenuItem.Click += esiTokenToolStripMenuItem_Click;
            // 
            // structureIDToolStripMenuItem
            // 
            structureIDToolStripMenuItem.Name = "structureIDToolStripMenuItem";
            structureIDToolStripMenuItem.Size = new Size(118, 20);
            structureIDToolStripMenuItem.Text = "Structure Selection";
            structureIDToolStripMenuItem.Click += structureIDToolStripMenuItem_Click;
            // 
            // Mode_MarketGroup
            // 
            Mode_MarketGroup.BackColor = SystemColors.Window;
            Mode_MarketGroup.Name = "Mode_MarketGroup";
            Mode_MarketGroup.Size = new Size(126, 20);
            Mode_MarketGroup.Text = "Mode Market Group";
            Mode_MarketGroup.Click += Mode_MarketGroup_Click;
            // 
            // Mode_Doctrine
            // 
            Mode_Doctrine.Name = "Mode_Doctrine";
            Mode_Doctrine.Size = new Size(98, 20);
            Mode_Doctrine.Text = "Mode Doctrine";
            Mode_Doctrine.Click += Mode_Doctrine_Click;
            // 
            // button1
            // 
            tableLayoutPanel1.SetColumnSpan(button1, 3);
            button1.Dock = DockStyle.Fill;
            button1.Enabled = false;
            button1.Location = new Point(4, 698);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(1543, 44);
            button1.TabIndex = 2;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonRefresh_Click;
            // 
            // ItemContent
            // 
            ItemContent.Location = new Point(8, 51);
            ItemContent.Margin = new Padding(4, 3, 4, 3);
            ItemContent.Name = "ItemContent";
            ItemContent.Size = new Size(211, 23);
            ItemContent.TabIndex = 3;
            // 
            // btn_add_Item
            // 
            btn_add_Item.Location = new Point(131, 21);
            btn_add_Item.Margin = new Padding(4, 3, 4, 3);
            btn_add_Item.Name = "btn_add_Item";
            btn_add_Item.Size = new Size(88, 27);
            btn_add_Item.TabIndex = 5;
            btn_add_Item.Text = "Ajouter";
            btn_add_Item.UseVisualStyleBackColor = true;
            btn_add_Item.Click += btn_add_Item_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 6;
            label1.Text = "Item nom(ou ID)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(DoctrineContente);
            groupBox1.Controls.Add(ItemContent);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Doctrine_Add);
            groupBox1.Controls.Add(btn_add_Item);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(4, 3);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(242, 689);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Item";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(86, 77);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(50, 32);
            label4.TabIndex = 11;
            label4.Text = "OU";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 109);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 10;
            label3.Text = "Copy Past doctrine";
            // 
            // DoctrineContente
            // 
            DoctrineContente.Location = new Point(8, 127);
            DoctrineContente.Margin = new Padding(4, 3, 4, 3);
            DoctrineContente.Multiline = true;
            DoctrineContente.Name = "DoctrineContente";
            DoctrineContente.ScrollBars = ScrollBars.Vertical;
            DoctrineContente.Size = new Size(211, 282);
            DoctrineContente.TabIndex = 7;
            // 
            // Doctrine_Add
            // 
            Doctrine_Add.Location = new Point(8, 415);
            Doctrine_Add.Margin = new Padding(4, 3, 4, 3);
            Doctrine_Add.Name = "Doctrine_Add";
            Doctrine_Add.Size = new Size(211, 27);
            Doctrine_Add.TabIndex = 5;
            Doctrine_Add.Text = "Ajouter un FUUUUUUU doctrine";
            Doctrine_Add.UseVisualStyleBackColor = true;
            Doctrine_Add.Click += Doctrine_Add_ClickAsync;
            // 
            // treeListView1
            // 
            treeListView1.AllowDrop = true;
            treeListView1.CellEditUseWholeCell = false;
            treeListView1.Dock = DockStyle.Fill;
            treeListView1.FullRowSelect = true;
            treeListView1.IsSimpleDragSource = true;
            treeListView1.IsSimpleDropSink = true;
            treeListView1.Location = new Point(254, 3);
            treeListView1.Margin = new Padding(4, 3, 4, 3);
            treeListView1.Name = "treeListView1";
            treeListView1.ShowGroups = false;
            treeListView1.Size = new Size(642, 689);
            treeListView1.TabIndex = 10;
            treeListView1.UseCompatibleStateImageBehavior = false;
            treeListView1.View = View.Details;
            treeListView1.VirtualMode = true;
            treeListView1.FormatRow += treeListView1_FormatRow;
            treeListView1.ModelCanDrop += treeListView1_ModelCanDrop;
            treeListView1.ModelDropped += treeListView1_ModelDropped;
            treeListView1.SelectionChanged += treeListView1_SelectionChanged;
            treeListView1.MouseDoubleClick += treeListView1_MouseDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeListView2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(903, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(645, 689);
            panel1.TabIndex = 11;
            // 
            // treeListView2
            // 
            treeListView2.AllowDrop = true;
            treeListView2.CellEditUseWholeCell = false;
            treeListView2.Dock = DockStyle.Fill;
            treeListView2.FullRowSelect = true;
            treeListView2.IsSimpleDragSource = true;
            treeListView2.IsSimpleDropSink = true;
            treeListView2.Location = new Point(0, 0);
            treeListView2.Margin = new Padding(4, 3, 4, 3);
            treeListView2.Name = "treeListView2";
            treeListView2.ShowGroups = false;
            treeListView2.Size = new Size(645, 689);
            treeListView2.TabIndex = 11;
            treeListView2.UseCompatibleStateImageBehavior = false;
            treeListView2.View = View.Details;
            treeListView2.VirtualMode = true;
            treeListView2.FormatRow += treeListView2_FormatRow;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(treeListView1, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 2, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1551, 745);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1551, 769);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1250, 550);
            Name = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)treeListView1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeListView2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem Mode_Doctrine;
        private Button Doctrine_Add;
        private Label label3;
        private TextBox DoctrineContente;
        private Label label4;
        private ToolStripMenuItem parametreToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exportStructureToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private BrightIdeasSoftware.TreeListView treeListView2;
    }
}

