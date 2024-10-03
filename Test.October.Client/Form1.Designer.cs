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
            GetAvailableStocks = new DomainUpDown();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            GetItemQuantitiesBySite = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // textForOrderId
            // 
            textForOrderId.Location = new Point(124, 403);
            textForOrderId.Name = "textForOrderId";
            textForOrderId.Size = new Size(191, 23);
            textForOrderId.TabIndex = 6;
            // 
            // btnCheckFeasibility
            // 
            btnCheckFeasibility.Location = new Point(321, 349);
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
            OrderId.Location = new Point(12, 403);
            OrderId.Name = "OrderId";
            OrderId.Size = new Size(106, 23);
            OrderId.TabIndex = 9;
            OrderId.Text = "Введите OrderId:";
            // 
            // GetAssemblyTasks
            // 
            GetAssemblyTasks.Location = new Point(547, 27);
            GetAssemblyTasks.Name = "GetAssemblyTasks";
            GetAssemblyTasks.Size = new Size(240, 77);
            GetAssemblyTasks.TabIndex = 10;
            GetAssemblyTasks.Text = "Получить доступные запасы";
            GetAssemblyTasks.UseVisualStyleBackColor = true;
            GetAssemblyTasks.Click += GetAssemblyTasks_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(249, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(293, 150);
            dataGridView1.TabIndex = 11;
            // 
            // GetAvailableStocks
            // 
            GetAvailableStocks.Items.Add("1");
            GetAvailableStocks.Items.Add("2");
            GetAvailableStocks.Items.Add("3");
            GetAvailableStocks.Items.Add("4");
            GetAvailableStocks.Items.Add("5");
            GetAvailableStocks.Items.Add("6");
            GetAvailableStocks.Items.Add("7");
            GetAvailableStocks.Items.Add("8");
            GetAvailableStocks.Items.Add("9");
            GetAvailableStocks.Items.Add("10");
            GetAvailableStocks.Items.Add("11");
            GetAvailableStocks.Items.Add("12");
            GetAvailableStocks.Items.Add("13");
            GetAvailableStocks.Items.Add("14");
            GetAvailableStocks.Items.Add("15");
            GetAvailableStocks.Items.Add("16");
            GetAvailableStocks.Items.Add("17");
            GetAvailableStocks.Items.Add("18");
            GetAvailableStocks.Items.Add("19");
            GetAvailableStocks.Items.Add("20");
            GetAvailableStocks.Location = new Point(3, 81);
            GetAvailableStocks.Name = "GetAvailableStocks";
            GetAvailableStocks.Size = new Size(240, 23);
            GetAvailableStocks.TabIndex = 13;
            GetAvailableStocks.Text = "Выберете id соборчной площадки";
            GetAvailableStocks.SelectedItemChanged += GetAvailableStocks_SelectedItemChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(3, 110);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(240, 150);
            dataGridView2.TabIndex = 14;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(548, 110);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(240, 150);
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
            GetItemQuantitiesBySite.Location = new Point(249, 81);
            GetItemQuantitiesBySite.Name = "GetItemQuantitiesBySite";
            GetItemQuantitiesBySite.Size = new Size(292, 23);
            GetItemQuantitiesBySite.TabIndex = 12;
            GetItemQuantitiesBySite.Text = "id соборчной площадки для получения остаков";
            GetItemQuantitiesBySite.SelectedItemChanged += GetItemQuantitiesBySite_SelectedItemChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(GetAvailableStocks);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
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
        private DomainUpDown GetAvailableStocks;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DomainUpDown GetItemQuantitiesBySite;
    }
}
