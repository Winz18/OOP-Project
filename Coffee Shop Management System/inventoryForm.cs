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
using DoAnCK;

namespace Coffee_Shop_Management_System
{
    public partial class inventoryForm : Form
    {
        string connect = 
            "Data Source=34.176.57.189;Initial Catalog=OOP;Persist Security Info=True;User ID=sqlserver;Password=Lak@2302;";

        public inventoryForm()
        {
            InitializeComponent();
        }

        public void inventoryForm_load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand("SELECT * FROM Inventory", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Selected = true;
                if (e.Button == MouseButtons.Left)
                {
                    tbxItem.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                    tbxQuantity.Text = dataGridView1.CurrentCell.Value.ToString();
                }
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = "Inventory";
                string columnName = tbxItem.Text;
                int newValue = int.Parse(tbxQuantity.Text);
                UpdateDatabaseColumn(connect, tableName, columnName, newValue); 
                inventoryForm_load(sender, e);
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }
        private void UpdateDatabaseColumn(string connectionString, string tableName, string columnName, int newValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = $"UPDATE {tableName} SET {columnName} = @NewValue";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Update successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Check your input again !");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string newColumnName = tbxItem.Text;

                // Kiểm tra xem cột đã tồn tại hay chưa
                if (!IsColumnExists("Inventory", newColumnName))
                {
                    // Thêm cột mới vào bảng
                    AddColumnToTable("Inventory", newColumnName, "int");

                    // Lấy giá trị từ tbxQuantity
                    int newValue;
                    if (int.TryParse(tbxQuantity.Text, out newValue))
                    {
                        // Cập nhật giá trị mới cho cột
                        UpdateDatabaseColumn(connect, "Inventory", newColumnName, newValue);

                        // Load lại dữ liệu
                        inventoryForm_load(sender, e);

                        MessageBox.Show("Column added and data updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid value for quantity. Please enter a valid integer value.");
                    }
                }
                else
                {
                    MessageBox.Show("Column already exists. Please choose a different column name.");
                }
                inventoryForm_load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private bool IsColumnExists(string tableName, string columnName)
        {
            // Kiểm tra xem cột đã tồn tại trong bảng hay chưa
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void AddColumnToTable(string tableName, string columnName, string dataType)
        {
            // Thêm cột mới vào bảng
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string addColumnQuery = $"ALTER TABLE {tableName} ADD {columnName} {dataType}";

                using (SqlCommand command = new SqlCommand(addColumnQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string columnNameToRemove = tbxItem.Text;

                // Kiểm tra xem cột có tồn tại hay không
                if (IsColumnExists("Inventory", columnNameToRemove))
                {
                    // Xóa cột từ bảng
                    RemoveColumnFromTable("Inventory", columnNameToRemove);

                    // Load lại dữ liệu
                    inventoryForm_load(sender, e);

                    MessageBox.Show("Column removed successfully!");
                }
                else
                {
                    MessageBox.Show("Column does not exist. Please enter a valid column name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            inventoryForm_load(sender, e);
        }

        private void RemoveColumnFromTable(string tableName, string columnName)
        {
            // Xóa cột từ bảng
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string removeColumnQuery = $"ALTER TABLE {tableName} DROP COLUMN {columnName}";

                using (SqlCommand command = new SqlCommand(removeColumnQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

