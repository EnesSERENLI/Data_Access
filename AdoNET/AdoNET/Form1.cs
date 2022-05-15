using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ado.Net
            /*
                --Disconnected 
                    -ilk etapta veri tabanına bir istek gönderilecek.
                    -Eğer veri tabanı bağlantısı kapalı ise açılacak.(SqlConnetion.Oped();)
                    -Bağlantı oluşturulduktan sonra veriler projeye çekilecek.(SqlCommand => sorgulamak istediğin komut. SqlDataReader => command'ı çalıştır ver verileri datareader'a aktar.)
                    -Bağlantı kapatılacak.
                    -Verilerde işlemler yapılacak.
            */

            //Standart Connetion (Sql server authentication) => Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            //Trusted Connetion (Windows Authentication) => Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
            //ConnectionString=> bağlantı yolu. (server name,login,password)

            //--Discconected

            SqlConnection sqlConnetion = new SqlConnection("server=DESKTOP-JOE5KI8\\SQLEXPRESS02;Database=Northwind;Trusted_Connection=True");
            if (sqlConnetion.State == ConnectionState.Closed) //Kapalı ise aç
                sqlConnetion.Open();
            SqlCommand cmd = new SqlCommand("select * from orders", sqlConnetion); //sorgulanacak komut
            SqlDataReader dr = cmd.ExecuteReader(); //cmd yi çalıstır ve dr ye aktar
            DataTable dt = new DataTable();
            dt.Load(dr); //Veritablosuna dr yi yükle
            dataGridView1.DataSource = dt; // datatable ı gridview e yükle
            sqlConnetion.Close(); // Sorguyu yaptık bağlantıyı kapattık.

            //--Connected

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from [Order Details]", sqlConnetion); //sorguyu ve server bağlantısını ver
            DataTable dt2 = new DataTable();
            dataAdapter.Fill(dt2);
            dataGridView1.DataSource = dt2;

        }
    }
}
