using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Controller;

namespace TugasBesar.View
{
    public partial class OrderHistory : Form
    {
        Connect connect = new Connect();
        public OrderHistory()
        {
            InitializeComponent();
        }

        public void View()
        {
            historyData.DataSource = connect.ShowData("SELECT * FROM order_list WHERE status='Success' OR status='Cancelled'");
            historyData.Columns[0].HeaderText = "ID Order";
            historyData.Columns[1].HeaderText = "Username";
            historyData.Columns[2].HeaderText = "Date Order";
            historyData.Columns[3].HeaderText = "Game";
            historyData.Columns[4].HeaderText = "ID Account";
            historyData.Columns[5].HeaderText = "Items";
            historyData.Columns[6].HeaderText = "Payment";
            historyData.Columns[7].HeaderText = "Status";
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            View();
        }

        private void ExportToExcel()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "OrderHistory.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("OrderHistory");

                        for (int i = 1; i <= historyData.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i].Value = historyData.Columns[i - 1].HeaderText;
                            for (int j = 1; j <= historyData.Rows.Count; j++)
                            {
                                worksheet.Cells[j + 1, i].Value = historyData.Rows[j - 1].Cells[i - 1].Value;
                            }
                        }

                        package.Save();
                    }

                    ExportSuccess exportSuccess = new ExportSuccess();
                    exportSuccess.Show();
                }
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
