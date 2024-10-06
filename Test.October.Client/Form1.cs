using System.Data;
using Test.October.Data;
using Test.October.DataAccess;

namespace Test.October.Client
{
    public partial class Form1 : Form
    {
        private readonly DbConnect _connect;
        private readonly Logic _logic;
        public Form1()
        {
            InitializeComponent();
            _connect = new DbConnect();
            _logic = new Logic();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _connect.ConnectToDbAsync();
        }
        private void btnCheckFeasibility_Click(object sender, EventArgs e)
        {
            int orderId;
            if (!int.TryParse(textForOrderId.Text, out orderId))
            {
                MessageBox.Show("Введите числа, а не строку");
            }
            else
            {
                string result = _logic.CheckAssemblyFeasibility(orderId); // Проверка, успеют ли закончить заказ сборочная площадка

                MessageBox.Show(result, "Результат проверки");
            }
        }
        private void GetItemQuantitiesBySite_SelectedItemChanged(object sender, EventArgs e) 
        {
            DataTable result = _logic.GetItemQuantitiesBySite(long.Parse(GetItemQuantitiesBySite.Text)); // Функция, которая возвращает таблицу с суммарным количеством
                                                                                                         // элементов по каждому типу номенклатуры на каждой сборочной площадке
            dataGridView1.DataSource = result;
            dataGridView1.RowHeadersVisible = false;
        }

        private void GetAssemblyTasks_Click(object sender, EventArgs e) 
        {
            DataTable assemblyTasks = _logic.GetAssemblyTasks(); // Функция, которая возвращает данные о задачах сборки на сборочных площадках

            
            dataGridView3.DataSource = assemblyTasks;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns[0].HeaderText = "Название площадки";
            dataGridView3.Columns[1].HeaderText = "Id заказа";
            dataGridView3.Columns[2].HeaderText = "Тип номенклатуры";
            dataGridView3.Columns[3].HeaderText = "Количество деталей в задаче";
        }

        private void btnCheckActiveSites_Click(object sender, EventArgs e) 
        {
            DataTable activeAssembly = _logic.CheckActiveAssembly(); // Функция, которая возвращает данные о активных площадках
            checkActiveAsembly.DataSource = activeAssembly;
            checkActiveAsembly.RowHeadersVisible = false;

        }

        private void btnGetAvailableInventory_Click(object sender, EventArgs e) 
        {
            DataTable availableInv = _logic.GetAvailableInventory(); // Функция, которая возвращает с каких
                                                                     // площадок и в каком количестве можно забрать готовый заказ
            dataGridView4.DataSource = availableInv;
            dataGridView4.RowHeadersVisible = false;
        }
    }
}
