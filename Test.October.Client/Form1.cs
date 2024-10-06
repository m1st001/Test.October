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
                MessageBox.Show("������� �����, � �� ������");
            }
            else
            {
                string result = _logic.CheckAssemblyFeasibility(orderId); // ��������, ������ �� ��������� ����� ��������� ��������

                MessageBox.Show(result, "��������� ��������");
            }
        }
        private void GetItemQuantitiesBySite_SelectedItemChanged(object sender, EventArgs e) 
        {
            DataTable result = _logic.GetItemQuantitiesBySite(long.Parse(GetItemQuantitiesBySite.Text)); // �������, ������� ���������� ������� � ��������� �����������
                                                                                                         // ��������� �� ������� ���� ������������ �� ������ ��������� ��������
            dataGridView1.DataSource = result;
            dataGridView1.RowHeadersVisible = false;
        }

        private void GetAssemblyTasks_Click(object sender, EventArgs e) 
        {
            DataTable assemblyTasks = _logic.GetAssemblyTasks(); // �������, ������� ���������� ������ � ������� ������ �� ��������� ���������

            
            dataGridView3.DataSource = assemblyTasks;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns[0].HeaderText = "�������� ��������";
            dataGridView3.Columns[1].HeaderText = "Id ������";
            dataGridView3.Columns[2].HeaderText = "��� ������������";
            dataGridView3.Columns[3].HeaderText = "���������� ������� � ������";
        }

        private void btnCheckActiveSites_Click(object sender, EventArgs e) 
        {
            DataTable activeAssembly = _logic.CheckActiveAssembly(); // �������, ������� ���������� ������ � �������� ���������
            checkActiveAsembly.DataSource = activeAssembly;
            checkActiveAsembly.RowHeadersVisible = false;

        }

        private void btnGetAvailableInventory_Click(object sender, EventArgs e) 
        {
            DataTable availableInv = _logic.GetAvailableInventory(); // �������, ������� ���������� � �����
                                                                     // �������� � � ����� ���������� ����� ������� ������� �����
            dataGridView4.DataSource = availableInv;
            dataGridView4.RowHeadersVisible = false;
        }
    }
}
