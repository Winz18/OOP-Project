using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace Coffee_Shop_Management_System
{
    public partial class ReportForm : Form
    {
        string connect = "Data Source=34.176.57.189;Initial Catalog=OOP;Persist Security Info=True;User ID=sqlserver;Password=Lak@2302;";
        private DateTime Start;
        private DateTime End;
        private string Query;

        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();
                    Start = dtpStart.Value.Date;
                    End = dtpEnd.Value.Date;

                    // Cắt bỏ thông tin giờ và giây từ Start và End
                    Start = new DateTime(Start.Year, Start.Month, Start.Day, 0, 0, 0);
                    End = new DateTime(End.Year, End.Month, End.Day, 23, 59, 59);

                    Query = "SELECT * FROM History WHERE Date >= @StartDate AND Date <= @EndDate";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", Start);
                        command.Parameters.AddWithValue("@EndDate", End);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvShow.DataSource = table;
                    }
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Report");

                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Name";
                    worksheet.Cells[1, 3].Value = "Contact";
                    worksheet.Cells[1, 4].Value = "Date";
                    worksheet.Cells[1, 5].Value = "Price";
                    worksheet.Cells[1, 6].Value = "Feedback";

                    int row = 2;

                    using (SqlConnection connection = new SqlConnection(connect))
                    {
                        connection.Open();
                        Start = dtpStart.Value.Date;
                        End = dtpEnd.Value.Date;

                        Query = "SELECT * FROM History WHERE Date BETWEEN @StartDate AND @EndDate";

                        using (SqlCommand command = new SqlCommand(Query, connection))
                        {
                            command.Parameters.AddWithValue("@StartDate", Start);
                            command.Parameters.AddWithValue("@EndDate", End);

                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                worksheet.Cells[row, 1].Value = reader[0].ToString();
                                worksheet.Cells[row, 2].Value = reader[1].ToString();
                                worksheet.Cells[row, 3].Value = reader[2].ToString();
                                worksheet.Cells[row, 4].Value = reader[3].ToString();
                                worksheet.Cells[row, 5].Value = reader[4].ToString();
                                worksheet.Cells[row, 6].Value = reader[5].ToString();

                                row++;
                            }
                        }
                        connection.Close();
                    }

                    FileInfo excelFile = new FileInfo("Report.xlsx");
                    excelPackage.SaveAs(excelFile);
                    MessageBox.Show("Report Generated Successfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
