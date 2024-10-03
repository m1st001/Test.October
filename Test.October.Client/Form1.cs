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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _connect.ConnectToDbAsync();
        }
        private void btnCheckFeasibility_Click(object sender, EventArgs e) // Проверка, успеют ли закончить заказ сборочная площадка
        {
            int orderId = int.Parse(textForOrderId.Text);
            string result = _logic.CheckAssemblyFeasibility(orderId);
            MessageBox.Show(result, "Результат проверки");
        }
        private void GetItemQuantitiesBySite_SelectedItemChanged(object sender, EventArgs e) // Функция, которая возвращает таблицу с суммарным количеством
                                                                                           // элементов по каждому типу номенклатуры на каждой сборочной площадке 
        {
            DataTable result = _logic.GetItemQuantitiesBySite(long.Parse(domainUpDown1.Text));
            dataGridView1.DataSource = result;
        }

        private void GetAvailableStocks_SelectedItemChanged(object sender, EventArgs e) // Получение остатков
        {
            DataTable result = _logic.GetAvailableStocks(long.Parse(GetAvailableStocks.Text));
            dataGridView2.DataSource = result;
        }

        private void GetAssemblyTasks_Click(object sender, EventArgs e) // Функция, которая возвращает данные о задачах сборки на сборочных площадках
        {
            DataTable assemblyTasks = _logic.GetAssemblyTasks();
            dataGridView3.DataSource = assemblyTasks;
        }
    }

}
