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

                CaiDatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }
        private void CaiDatDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["UserName"].HeaderText = "UserName";
            dataGridView1.Columns["HoatDong"].HeaderText = "Hoạt động";
            dataGridView1.Columns["ChiTiet"].HeaderText = "Chi tiết";
            dataGridView1.Columns["ThoiGian"].HeaderText = "Thời gian";

            dataGridView1.Columns["UserName"].FillWeight = 90;
            dataGridView1.Columns["HoatDong"].FillWeight = 80;
            dataGridView1.Columns["ChiTiet"].FillWeight = 250;
            dataGridView1.Columns["ThoiGian"].FillWeight = 100;
        }

    }
}
