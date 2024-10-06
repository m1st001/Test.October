namespace Test.October.Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textForOrderId = new TextBox();
            btnCheckFeasibility = new Button();
            OrderId = new Label();
            GetAssemblyTasks = new Button();
            dataGridView1 = new DataGridView();
            dataGridView3 = new DataGridView();
            GetItemQuantitiesBySite = new DomainUpDown();
            btnCheckActiveSites = new Button();
            checkActiveAsembly = new DataGridView();
            dataGridView4 = new DataGridView();
            btnGetAvailableInventory = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkActiveAsembly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // textForOrderId
            // 
            textForOrderId.Location = new Point(926, 583);
            textForOrderId.Name = "textForOrderId";
            textForOrderId.Size = new Size(191, 23);
            textForOrderId.TabIndex = 6;
            // 
            // btnCheckFeasibility
            // 
            btnCheckFeasibility.Location = new Point(1136, 529);
            btnCheckFeasibility.Name = "btnCheckFeasibility";
            btnCheckFeasibility.Size = new Size(191, 77);
            btnCheckFeasibility.TabIndex = 8;
            btnCheckFeasibility.Text = "Проверить осуществимость сборки";
            btnCheckFeasibility.UseVisualStyleBackColor = true;
            btnCheckFeasibility.Click += btnCheckFeasibility_Click;
            // 
            // OrderId
            // 
            OrderId.BackColor = SystemColors.Control;
            OrderId.Location = new Point(814, 586);
            OrderId.Name = "OrderId";
            OrderId.Size = new Size(106, 23);
            OrderId.TabIndex = 9;
            OrderId.Text = "Введите OrderId:";
            // 
            // GetAssemblyTasks
            // 
            GetAssemblyTasks.Location = new Point(990, 3);
            GetAssemblyTasks.Name = "GetAssemblyTasks";
            GetAssemblyTasks.Size = new Size(241, 37);
            GetAssemblyTasks.TabIndex = 10;
            GetAssemblyTasks.Text = "Получить доступные запасы";
            GetAssemblyTasks.UseVisualStyleBackColor = true;
            GetAssemblyTasks.Click += GetAssemblyTasks_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(299, 150);
            dataGridView1.TabIndex = 11;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(903, 46);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.Size = new Size(405, 335);
            dataGridView3.TabIndex = 15;
            // 
            // GetItemQuantitiesBySite
            // 
            GetItemQuantitiesBySite.Items.Add("1");
            GetItemQuantitiesBySite.Items.Add("2");
            GetItemQuantitiesBySite.Items.Add("3");
            GetItemQuantitiesBySite.Items.Add("4");
            GetItemQuantitiesBySite.Items.Add("5");
            GetItemQuantitiesBySite.Items.Add("6");
            GetItemQuantitiesBySite.Items.Add("7");
            GetItemQuantitiesBySite.Items.Add("8");
            GetItemQuantitiesBySite.Items.Add("9");
            GetItemQuantitiesBySite.Items.Add("10");
            GetItemQuantitiesBySite.Items.Add("11");
            GetItemQuantitiesBySite.Items.Add("12");
            GetItemQuantitiesBySite.Items.Add("13");
            GetItemQuantitiesBySite.Items.Add("14");
            GetItemQuantitiesBySite.Items.Add("15");
            GetItemQuantitiesBySite.Items.Add("16");
            GetItemQuantitiesBySite.Items.Add("17");
            GetItemQuantitiesBySite.Items.Add("18");
            GetItemQuantitiesBySite.Items.Add("19");
            GetItemQuantitiesBySite.Items.Add("20");
            GetItemQuantitiesBySite.Location = new Point(32, 17);
            GetItemQuantitiesBySite.Name = "GetItemQuantitiesBySite";
            GetItemQuantitiesBySite.Size = new Size(299, 23);
            GetItemQuantitiesBySite.TabIndex = 12;
            GetItemQuantitiesBySite.Text = "id соборчной площадки для получения остаков";
            GetItemQuantitiesBySite.SelectedItemChanged += GetItemQuantitiesBySite_SelectedItemChanged;
            // 
            // btnCheckActiveSites
            // 
            btnCheckActiveSites.Location = new Point(32, 552);
            btnCheckActiveSites.Name = "btnCheckActiveSites";
            btnCheckActiveSites.Size = new Size(118, 57);
            btnCheckActiveSites.TabIndex = 16;
            btnCheckActiveSites.Text = "Узнать активные заказы и их площадки";
            btnCheckActiveSites.UseVisualStyleBackColor = true;
            btnCheckActiveSites.Click += btnCheckActiveSites_Click;
            // 
            // checkActiveAsembly
            // 
            checkActiveAsembly.AllowUserToAddRows = false;
            checkActiveAsembly.AllowUserToDeleteRows = false;
            checkActiveAsembly.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            checkActiveAsembly.Location = new Point(46, 415);
            checkActiveAsembly.Name = "checkActiveAsembly";
            checkActiveAsembly.ReadOnly = true;
            checkActiveAsembly.Size = new Size(104, 119);
            checkActiveAsembly.TabIndex = 17;
            // 
            // dataGridView4
            // 
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(224, 415);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.Size = new Size(307, 119);
            dataGridView4.TabIndex = 18;
            // 
            // btnGetAvailableInventory
            // 
            btnGetAvailableInventory.Location = new Point(284, 552);
            btnGetAvailableInventory.Name = "btnGetAvailableInventory";
            btnGetAvailableInventory.Size = new Size(174, 57);
            btnGetAvailableInventory.TabIndex = 19;
            btnGetAvailableInventory.Text = "Узнать, с каких площадок и в каком количестве можно забрать готовый заказ";
            btnGetAvailableInventory.UseVisualStyleBackColor = true;
            btnGetAvailableInventory.Click += btnGetAvailableInventory_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 645);
            Controls.Add(btnGetAvailableInventory);
            Controls.Add(dataGridView4);
            Controls.Add(checkActiveAsembly);
            Controls.Add(btnCheckActiveSites);
            Controls.Add(dataGridView3);
            Controls.Add(GetItemQuantitiesBySite);
            Controls.Add(dataGridView1);
            Controls.Add(GetAssemblyTasks);
            Controls.Add(OrderId);
            Controls.Add(btnCheckFeasibility);
            Controls.Add(textForOrderId);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkActiveAsembly).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private TextBox textBox1;
        private TextBox textForOrderId;
        private Button btnCheckFeasibility;
        private DateTimePicker AssemblyDate;
        private Label OrderId;
        private Button GetAssemblyTasks;
        private BindingSource dbConnectBindingSource;
        private DataGridView dataGridView1;
        private DomainUpDown domainUpDown1;
        private DataGridView dataGridView3;
        private DomainUpDown GetItemQuantitiesBySite;
        private Button btnCheckActiveSites;
        private DataGridView checkActiveAsembly;
        private DataGridView dataGridView4;
        private Button btnGetAvailableInventory;
    }
}
