//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Text.Json;
using Newtonsoft.Json;



namespace prjAPIDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7045/api/APIDemo");
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            label1.Text = json;

            List<TProduct> product = JsonConvert.DeserializeObject<List<TProduct>>(json);
            dataGridView1.DataSource = product;

        }
    }
}
