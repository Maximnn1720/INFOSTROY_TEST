namespace TestApp_Infostroy
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeViewDB = new System.Windows.Forms.TreeView();
			this.ButtonExport = new System.Windows.Forms.Button();
			this.ButtonChange = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TextBoxFilter = new System.Windows.Forms.TextBox();
			this.ButtonChekFilter = new System.Windows.Forms.Button();
			this.СomboBoxBool = new System.Windows.Forms.ComboBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewDB
			// 
			this.treeViewDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.treeViewDB.Location = new System.Drawing.Point(34, 12);
			this.treeViewDB.Name = "treeViewDB";
			this.treeViewDB.Size = new System.Drawing.Size(1095, 378);
			this.treeViewDB.TabIndex = 0;
			this.treeViewDB.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDB_AfterSelect);
			// 
			// ButtonExport
			// 
			this.ButtonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonExport.Location = new System.Drawing.Point(1136, 13);
			this.ButtonExport.Name = "ButtonExport";
			this.ButtonExport.Size = new System.Drawing.Size(169, 23);
			this.ButtonExport.TabIndex = 1;
			this.ButtonExport.Text = "ExportExcel";
			this.ButtonExport.UseVisualStyleBackColor = true;
			this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
			// 
			// ButtonChange
			// 
			this.ButtonChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonChange.Location = new System.Drawing.Point(1136, 43);
			this.ButtonChange.Name = "ButtonChange";
			this.ButtonChange.Size = new System.Drawing.Size(169, 23);
			this.ButtonChange.TabIndex = 2;
			this.ButtonChange.Text = "Change Top Tag";
			this.ButtonChange.UseVisualStyleBackColor = true;
			this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1317, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Enabled = false;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// TextBoxFilter
			// 
			this.TextBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TextBoxFilter.Location = new System.Drawing.Point(1136, 76);
			this.TextBoxFilter.Name = "TextBoxFilter";
			this.TextBoxFilter.Size = new System.Drawing.Size(74, 27);
			this.TextBoxFilter.TabIndex = 4;
			// 
			// ButtonChekFilter
			// 
			this.ButtonChekFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonChekFilter.Location = new System.Drawing.Point(1263, 76);
			this.ButtonChekFilter.Name = "ButtonChekFilter";
			this.ButtonChekFilter.Size = new System.Drawing.Size(42, 28);
			this.ButtonChekFilter.TabIndex = 6;
			this.ButtonChekFilter.Text = "▼";
			this.ButtonChekFilter.UseVisualStyleBackColor = true;
			this.ButtonChekFilter.Click += new System.EventHandler(this.ButtonChekFilter_Click);
			// 
			// СomboBoxBool
			// 
			this.СomboBoxBool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.СomboBoxBool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.СomboBoxBool.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.СomboBoxBool.FormattingEnabled = true;
			this.СomboBoxBool.ItemHeight = 20;
			this.СomboBoxBool.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "≥",
            "≤"});
			this.СomboBoxBool.Location = new System.Drawing.Point(1214, 76);
			this.СomboBoxBool.Name = "СomboBoxBool";
			this.СomboBoxBool.Size = new System.Drawing.Size(45, 28);
			this.СomboBoxBool.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1317, 450);
			this.Controls.Add(this.СomboBoxBool);
			this.Controls.Add(this.ButtonChekFilter);
			this.Controls.Add(this.TextBoxFilter);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.ButtonChange);
			this.Controls.Add(this.ButtonExport);
			this.Controls.Add(this.treeViewDB);
			this.Name = "Form1";
			this.Text = "DBViewer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewDB;
		private System.Windows.Forms.Button ButtonExport;
		private System.Windows.Forms.Button ButtonChange;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.TextBox TextBoxFilter;
		private System.Windows.Forms.Button ButtonChekFilter;
		private System.Windows.Forms.ComboBox СomboBoxBool;
	}
}

