using System.Windows.Forms;
using CAMP.Utiles;


namespace CAMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Apache b = new Apache();
            b.Start();
            Mysql a = Mysql.Initialize();
            a.Start();

            Application.ApplicationExit += (sender, args) => { a.Stop(); b.Stop(); };
        }
    }
}
