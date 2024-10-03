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
        private void btnCheckFeasibility_Click(object sender, EventArgs e) // ��������, ������ �� ��������� ����� ��������� ��������
        {
            int orderId = int.Parse(textForOrderId.Text);
            string result = _logic.CheckAssemblyFeasibility(orderId);
            MessageBox.Show(result, "��������� ��������");
        }
        private void GetItemQuantitiesBySite_SelectedItemChanged(object sender, EventArgs e) // �������, ������� ���������� ������� � ��������� �����������
                                                                                           // ��������� �� ������� ���� ������������ �� ������ ��������� �������� 
        {
            DataTable result = _logic.GetItemQuantitiesBySite(long.Parse(domainUpDown1.Text));
            dataGridView1.DataSource = result;
        }

        private void GetAvailableStocks_SelectedItemChanged(object sender, EventArgs e) // ��������� ��������
        {
            DataTable result = _logic.GetAvailableStocks(long.Parse(GetAvailableStocks.Text));
            dataGridView2.DataSource = result;
        }

        private void GetAssemblyTasks_Click(object sender, EventArgs e) // �������, ������� ���������� ������ � ������� ������ �� ��������� ���������
        {
            DataTable assemblyTasks = _logic.GetAssemblyTasks();
            dataGridView3.DataSource = assemblyTasks;
        }
    }

}
