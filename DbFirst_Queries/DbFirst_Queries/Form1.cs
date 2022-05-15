using DbFirst_Queries.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirst_Queries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntities db = new NorthwindEntities();

        //Entityframework
        //ORM (Object Relational MApping) bağlantı isteğiyle beraber entityframework ile tabloları class'lara dönüştürür

        private void btnSorguBir_Click(object sender, EventArgs e)
        {
            //Soru

            //Fiyatı 20 ile 50 arasında olan ürünlerin ID,Ürünadı,fiyatı,stok miktarı ve kategori adını listeleyin.
            //T-SQL
            /*
             select ProductID,ProductName,UnitPrice,UnitsInStock,CategoryName as 'CategoryName' from Products p join Categories c on c.CategoryID=p.CategoryID Where UnitPrice>20 and UnitPrice<50
             */

            //Linq
            //var result = from p in db.Products //bana p gelicek productstan
            //             where p.UnitPrice > 20 && p.UnitPrice < 50 //filtreledik
            //             select new
            //             {
            //                 p.ProductID,
            //                 p.ProductName,
            //                 p.UnitPrice,
            //                 p.UnitsInStock,
            //                 p.Category.CategoryName
            //             };
            //dataGridView1.DataSource = result.ToList();

            //Linq to Entity
            var result = db.Products.Where(x => x.UnitPrice > 20 && x.UnitPrice < 50).Select(x => new //Lambda ile yapılış x=>x.property --ilk x products olarak algılıyor.
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.UnitsInStock,
                x.Category.CategoryName
            }).ToList();
            dataGridView1.DataSource = result;
        }

        private void btnSorgu2_Click(object sender, EventArgs e)
        {
            //Soru
            /*
             * Siparişler tablosundan müşteri şirket adı,çalışan adı ve soyadı, sipariş ID'si,Sipariş tarihi ve KargoŞirket adını getiren sorgu yazın
             */

            //T-SQL

            //select o.OrderID,e.FirstName+' '+e.LastName as 'Çalışan Bilgisi',c.CompanyName as 'Müşteri Şirket',o.OrderDate,s.CompanyName as 'Kargo Şirket' from Orders o join Employees e on e.EmployeeID=o.EmployeeID join Shippers s on s.ShipperID=o.ShipVia join Customers c on c.CustomerID=o.CustomerID

            //Linq

            //var result = from o in db.Orders
            //             select new
            //             {
            //                 o.OrderID,
            //                 AdSoyad=o.Employee.FirstName+" "+o.Employee.LastName,
            //                 MüşteriAd=o.Customer.CompanyName,
            //                 o.OrderDate,
            //                 o.Shipper.CompanyName
            //             };
            //dataGridView1.DataSource = result.ToList();
            //Lint to Entity

            var result = db.Orders.Select(o => new
            {
                o.OrderID,
                AdSoyad = o.Employee.FirstName + " " + o.Employee.LastName,
                MüşteriAd = o.Customer.CompanyName,
                o.OrderDate,
                o.Shipper.CompanyName //yukarıda da company name var ona isim vermezsek burada kızar.. Hangi companyname oldugunu bilmesi gerekiyor.
            }).ToList();
            dataGridView1.DataSource = result;
        }

        private void btnSorgu3_Click(object sender, EventArgs e)
        {
            //Müşteri tablosunda bulunan 'CompanyName' içerisinde "restaurant"geçen müşterileri listeleyin

            //T-SQL
            //select * from Customers where CompanyName like '%restaurant%'

            //Linq

            //var result = from c in db.Customers
            //             where c.CompanyName.Contains("restaurant")
            //             select c;
            //dataGridView1.DataSource = result.ToList();

            //Linq to Entity

            var result2 = db.Customers.Where(x => x.CompanyName.Contains("restaurant")).ToList();
            dataGridView1.DataSource = result2;
        }

        private void btnSorgu4_Click(object sender, EventArgs e)
        {
            //kategorisi beverages olan ve ürün adı "kola" fiyatı 5 stok adet 500 olan ürünü ekleyin

            //T-SQL

            //insert into Products (ProductName,CategoryID,UnitPrice,UnitsInStock) values ('Kola',1,5,500)

            //Ekleme İşlemi
            Product p = new Product();
            p.ProductName = "Ayran";
            p.UnitPrice = 5;
            p.UnitsInStock = 500;
            //int catID = db.Categories.First(x => x.CategoryName == "beverages").CategoryID; 
            int catID2 = db.Categories.FirstOrDefault(x => x.CategoryName == "beverages").CategoryID;
            p.CategoryID = catID2;

            //db.Products.Add(new Product
            // {
            //     ProductName = "Kola",
            //     UnitPrice = 5,
            //     UnitsInStock = 500,
            //     CategoryID = db.Categories.FirstOrDefault(x => x.CategoryName == "beverages").CategoryID
            // });

            db.Products.Add(p);
            db.SaveChanges();
        }

        private void btnSorgu5_Click(object sender, EventArgs e)
        {
            // Fiyatı 20'den büyük veya 100'den küçük olan ürünlerin ilk 3'nü getiren sorgu.

            dataGridView1.DataSource = db.Products
                                    .Where(x => x.UnitPrice > 20 || x.UnitsInStock < 100)
                                    .Select(x => new
                                    {
                                        x.ProductID,
                                        x.ProductName,
                                        x.UnitPrice,
                                        x.UnitsInStock
                                    })
                                    .OrderBy(x => new
                                    {
                                        x.UnitPrice,
                                        x.UnitsInStock
                                    })
                                    .Skip(3) //ilk üçünü geç
                                    .Take(3) //ilk 3 nü getir (Skip olduğu için 2. üçlüyü getirecek..
                                    .ToList();
        }

        private void btnSorgu6_Click(object sender, EventArgs e)
        {
            //Janet'in almış olduğu siparişleri listeleyin

            //T-SQL

            //select * from Orders Where EmployeeID = (Select EmployeeID from Employees Where FirstName = 'Janet')

            //Linq

            //var result = from o in db.Orders where o.Employee.FirstName == "Janet" select o;
            //dataGridView1.DataSource = result.ToList();

            //Linq to entity

            dataGridView1.DataSource = db.Orders.Where(x => x.Employee.FirstName == "Janet").Select(x => new
            {
                x.OrderID,
                Fullname = x.Employee.FirstName + " " + x.Employee.LastName,
                x.OrderDate,
                x.Freight,
                x.ShipName
            }).ToList();
        }

        private void btnSorgu7_Click(object sender, EventArgs e)
        {
            //ürün adında r ile başlayan t ile biten ürünler nelerdir.

            //T-SQL

            //Select * from Product Where ProductName like 'r%t'

            //Linq

            //var result = from p in db.Products
            //             where p.ProductName.StartsWith("r") && p.ProductName.EndsWith("t")
            //             select p;
            //dataGridView1.DataSource = result.ToList();

            //Linq to entity

            dataGridView1.DataSource = db.Products.Where(x => x.ProductName.StartsWith("r") && x.ProductName.EndsWith("t")).Select(x => new
            {
                x.ProductName,
                x.UnitPrice
            }).OrderBy(x => x.UnitPrice).ToList();
        }

        private void btnSorgu8_Click(object sender, EventArgs e)
        {
            Product product = db.Products.Find(6);
            if (product == null)
                MessageBox.Show("dont have product");
            else
                MessageBox.Show($"Product Name: {product.ProductName}");
        }

        private void btnSorgu9_Click(object sender, EventArgs e)
        {
            //Hangi kategoriden stokta toplam ne kadar ürün var ?

            //T-SQL

            //select c.CategoryName,sum(p.UnitsInStock) from Products p join Categories c on p.CategoryID=c.CategoryID group by c.CategoryName            
            //Linq

            //var result = from p in db.Products
            //             group p by p.Category.CategoryName into kyw
            //             select new
            //             {
            //                 CategoryName = kyw.Key,
            //                 TotalProduct = kyw.Sum(z => z.UnitsInStock)
            //             };
            //dataGridView1.DataSource = result.ToList();

            //Linq To Entity

            dataGridView1.DataSource = db.Products.GroupBy(x => x.Category.CategoryName).Select(x => new
            {
                Categoryname = x.Key,
                TotalProduct = x.Sum(z => z.UnitsInStock)
            }).ToList();
        }

        private void btnSorgu10_Click(object sender, EventArgs e)
        {
            //En pahalı ve en ucuz ürünler hangileri
            decimal? expensiveProduct = db.Products.Max(x => x.UnitPrice);
            decimal? cheaperProduct = db.Products.Min(x => x.UnitPrice);
            MessageBox.Show($"Expensive Product : {expensiveProduct} \nCheaper Product : {cheaperProduct}");

            //Ürünlerden en az stok olan en fazla stok olanların sayılarını getiren sorgu
            int? leastStock = db.Products.Max(x => x.UnitsInStock);
            int? mostStock = db.Products.Min(x => x.UnitsInStock);
            MessageBox.Show($"LeastStock Quantity: {leastStock} \n MostStock Quantity: {mostStock}");
        }

        private void btnSorgu11_Click(object sender, EventArgs e)
        {
            //Fiyatı 200'den fazla olan ürünü getiren sorgu.

            Product product = null;
            try
            {
                product = db.Products.Single(x => x.UnitPrice > 200);
                listBox1.Items.Add(product.ProductName);
            }
            catch (Exception)
            {
                if (product == null)
                    MessageBox.Show("Don't have product");
            }
        }

        private void btnSorgu12_Click(object sender, EventArgs e)
        {
            //Çalışanların ülkelerini listeleyin
            dataGridView1.DataSource = db.Employees.GroupBy(x => x.Country).Select(x => new
            {
                country = x.Key,
                Sayi = x.Count()
            }).Distinct().ToList();
        }

        private void btnSorgu13_Click(object sender, EventArgs e)
        {
            //Hangi Müşteri toplam kaç adet sipariş vermiş.. Join example..

            dataGridView1.DataSource = db.Orders
                .Join(db.Customers, o => o.CustomerID, c => c.CustomerID, (o, c) => new { o, c })
                .GroupBy(x => x.c.CompanyName)
                .Select(x => new
                {
                    CompanyName = x.Key,
                    Count = x.Count()
                })
                .OrderBy(x => x.Count)
                .ToList();
        }

        private void btnSorgu14_Click(object sender, EventArgs e)
        {
            //Hangi Siparişten ne kadar gelir elde edilmiş ?

            //var orderdetails = from od in db.Order_Details
            //                   orderby od.Quantity * od.UnitPrice * (int)Math.Floor(1 - od.Discount)
            //                   group od by od.OrderID into kyw
            //                   select new
            //                   {
            //                       OrderId = kyw.Key,
            //                       Total = kyw.Sum(x => x.Quantity * x.UnitPrice * (int)Math.Floor(1 - x.Discount))
            //                   };
            //dataGridView1.DataSource = orderdetails.ToList();

            dataGridView1.DataSource = db.Order_Details.GroupBy(x => x.OrderID)
                .Select(x => new
                {
                    OrderID = x.Key,
                    TotalPrice = x.Sum(z => z.Quantity * z.UnitPrice * (int)Math.Floor(1 - z.Discount))
                }).OrderByDescending(x => x.TotalPrice)
                .ToList();
        }
    }
}
