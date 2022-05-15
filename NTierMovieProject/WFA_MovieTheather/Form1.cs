using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Entity;
using BLL.Repository;

namespace WFA_MovieTheather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BaseRespository<Category> categoryRepository = new BaseRespository<Category>(); //If we want to add a category => BaseRespository<Category>
        //BaseRespository<Movie> movieRepository = new BaseRespository<Movie>(); // If we want to add a movie.. BaseRespository<Movie>
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="Action"},
                new Category(){CategoryName="Drama"},
                new Category(){CategoryName="Horror"}
            };
            foreach (Category category in categories)
            {
                MessageBox.Show(categoryRepository.Create(category));
            }
            pnlMenu.BackColor = Color.FromArgb(26,60,64);
            pnlContent.BackColor = Color.FromArgb(237,230,219);
        }
    }
}
