namespace Used_Vehicle_Dealership_System
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.schematableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uvds_schemasDataSet1 = new Used_Vehicle_Dealership_System.uvds_schemasDataSet1();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uvds_schemasDataSet = new Used_Vehicle_Dealership_System.uvds_schemasDataSet();
            this.schematableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schematableTableAdapter = new Used_Vehicle_Dealership_System.uvds_schemasDataSetTableAdapters.schematableTableAdapter();
            this.schematableTableAdapter1 = new Used_Vehicle_Dealership_System.uvds_schemasDataSet1TableAdapters.schematableTableAdapter();
            this.performance_schemaDataSet = new Used_Vehicle_Dealership_System.performance_schemaDataSet();
            this.performanceschemaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schematableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvds_schemasDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvds_schemasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schematableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performance_schemaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceschemaDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(217, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(45)))), ((int)(((byte)(43)))));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 327);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicles In Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(443, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Store";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.schematableBindingSource1;
            this.comboBox1.DisplayMember = "schemaname";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(254, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "schemaname";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // schematableBindingSource1
            // 
            this.schematableBindingSource1.DataMember = "schematable";
            this.schematableBindingSource1.DataSource = this.uvds_schemasDataSet1;
            // 
            // uvds_schemasDataSet1
            // 
            this.uvds_schemasDataSet1.DataSetName = "uvds_schemasDataSet1";
            this.uvds_schemasDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 46);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(544, 231);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // uvds_schemasDataSet
            // 
            this.uvds_schemasDataSet.DataSetName = "uvds_schemasDataSet";
            this.uvds_schemasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schematableBindingSource
            // 
            this.schematableBindingSource.DataMember = "schematable";
            this.schematableBindingSource.DataSource = this.uvds_schemasDataSet;
            // 
            // schematableTableAdapter
            // 
            this.schematableTableAdapter.ClearBeforeFill = true;
            // 
            // schematableTableAdapter1
            // 
            this.schematableTableAdapter1.ClearBeforeFill = true;
            // 
            // performance_schemaDataSet
            // 
            this.performance_schemaDataSet.DataSetName = "performance_schemaDataSet";
            this.performance_schemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // performanceschemaDataSetBindingSource
            // 
            this.performanceschemaDataSetBindingSource.DataSource = this.performance_schemaDataSet;
            this.performanceschemaDataSetBindingSource.Position = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(575, 328);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Used Vehicle Dealership System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schematableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvds_schemasDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvds_schemasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schematableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performance_schemaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceschemaDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private uvds_schemasDataSet uvds_schemasDataSet;
        private System.Windows.Forms.BindingSource schematableBindingSource;
        private uvds_schemasDataSetTableAdapters.schematableTableAdapter schematableTableAdapter;
        private uvds_schemasDataSet1 uvds_schemasDataSet1;
        private System.Windows.Forms.BindingSource schematableBindingSource1;
        private uvds_schemasDataSet1TableAdapters.schematableTableAdapter schematableTableAdapter1;
        private performance_schemaDataSet performance_schemaDataSet;
        private System.Windows.Forms.BindingSource performanceschemaDataSetBindingSource;
    }
}

