using BLL.Repository;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_MovieTheather
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
            GenerateListView();
        }
        BaseRespository<Movie> movieRepository = new BaseRespository<Movie>();
        public void GenerateListView()
        {
            ListView listView = new ListView();
            foreach (Movie movie in movieRepository.GetList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.SubItems.Add(movie.Description);
                listView.Items.Add(lvi);
            }
            pnlMovie.Controls.Add(listView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.MovieName = "Big Fish";
            movie.Description = "asdsad";
            movie.Duration = TimeSpan.FromHours(01.45);
        }
    }
}
