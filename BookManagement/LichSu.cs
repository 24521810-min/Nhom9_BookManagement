using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using BookManagement.Models;

namespace BookManagement
{
    public partial class LichSu : Form
    {
        private readonly HttpClient _client;

        public LichSu(string token)
        {
            InitializeComponent();

            // API đúng cổng swagger
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7214/");
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

           

            LoadLichSu();
        }

        private async void LoadLichSu()
        {
            try
            {
                var data = await _client.GetFromJsonAsync<List<LichSuDto>>("api/LichSu");
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

       
    }
}
