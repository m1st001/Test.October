using Test.October.DataAccess;

namespace Test.October.Client
{
    public partial class Form1 : Form
    {
        private readonly DbConnect _connect;
        public Form1()
        {
            InitializeComponent();
            _connect = new DbConnect();
        }
    }
}
