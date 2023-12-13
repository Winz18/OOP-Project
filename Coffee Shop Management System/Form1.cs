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
    public partial class Form1 : Form
    {
        History history = new History();
        Inventory inventory = new Inventory();
        Coffe coffe = new Coffe();
        Shop_DBDataContext db = new Shop_DBDataContext();
        public Dictionary<int, Dictionary<string, int>> ListOrder = new Dictionary<int, Dictionary<string, int>>();
        public float total = 0;
        CurrentOrderForm currentOrderForm = new CurrentOrderForm();
        public int Role;
        ReportForm reportForm = new ReportForm();
        string connect = "Data Source=34.176.57.189;Initial Catalog=OOP;Persist Security Info=True;User ID=sqlserver;Password=Lak@2302;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand("SELECT * FROM Coffes", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            if (!ListOrder.ContainsKey(0))
            {
                ListOrder[0] = new Dictionary<string, int>();
            }

            if (Role == -1)
            {
                currentOrderForm.btnPrepare.Visible = false;
                currentOrderForm.btnOrder.Visible = true;
                currentOrderForm.btnPay.Visible = true;
            }

            if (Role == 2)
            {
                currentOrderForm.btnPrepare.Visible = true;
                currentOrderForm.btnOrder.Visible = false;
                currentOrderForm.btnPay.Visible = false;
            }

            if (Role == 1)
            {
                currentOrderForm.btnPrepare.Visible = true;
                currentOrderForm.btnOrder.Visible = true;
                currentOrderForm.btnPay.Visible = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Selected = true;
                string name = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                float price = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString());
                if (e.Button == MouseButtons.Left)
                {
                    if (ListOrder[0].ContainsKey(name))
                    {
                        ListOrder[0][name] += 1;
                    }
                    else
                    {
                        ListOrder[0][name] = 1;
                    }

                    total += price;
                    inputOrder_TextChanged(sender, e);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (ListOrder[0].ContainsKey(name))
                    {
                        if (ListOrder[0][name] > 1)
                        {
                            ListOrder[0][name] -= 1;
                            total -= price;
                            inputOrder_TextChanged(sender, e);
                        }
                        else
                        {
                            ListOrder[0].Remove(name);
                            total -= price;
                            inputOrder_TextChanged(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            inputOrder.Text = "";
            total = 0;
            ListOrder[0].Clear();
        }

        private void inputOrder_TextChanged(object sender, EventArgs e)
        {
            inputOrder.Text = "Danh sách món đã chọn:\n";
            ListOrder.TryGetValue(0, out Dictionary<string, int> value);
            foreach (var key in value)
            {
                inputOrder.Text += $"{key.Key} x {key.Value}\n";
            }
            inputOrder.Text += $"Tổng tiền: {total}";
        }

        private void btnTable1_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 1;
            btnTable_Click(ref sender, ref e, 1, ref btnTable1, ref cbxTable1);
        }

        private void btnTable11_Click(object sender, EventArgs e)
        { 
            currentOrderForm.TableNumber = 11;
            btnTable_Click(ref sender, ref e, 11, ref btnTable11, ref cbxTable11);
        }

        private void btnTable2_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 2;
            btnTable_Click(ref sender, ref e, 2, ref btnTable2, ref cbxTable2);
        }

        private void btnTable_Click(ref object sender, ref EventArgs e, int tableNum, ref Button table, ref CheckBox cbxTable)
        {
            try
            {
                if (!ListOrder.ContainsKey(tableNum))
                {
                    ListOrder[tableNum] = new Dictionary<string, int>(ListOrder[0]);
                }

                if (table.DialogResult != DialogResult.Yes)
                {
                    currentOrderForm.orders = new Dictionary<string, int>(ListOrder[tableNum]);
                    btnClear_Click(sender, e);
                    currentOrderForm.ShowDialog();
                    if (currentOrderForm.DialogResult == DialogResult.OK)
                    {
                        table.BackColor = Color.Red;
                        btnClear_Click(sender, e);
                        currentOrderForm.DialogResult = DialogResult.None;
                    }
                    if (currentOrderForm.DialogResult == DialogResult.Yes)
                    {
                        cbxTable.Checked = true;
                        table.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    currentOrderForm.orders = new Dictionary<string, int>(ListOrder[tableNum]);
                    currentOrderForm.ShowDialog();
                    if (currentOrderForm.DialogResult == DialogResult.Yes)
                    {
                        table.BackColor = Color.White;
                        currentOrderForm.DialogResult = DialogResult.None;
                        table.DialogResult = DialogResult.None;
                        ListOrder.Remove(tableNum);
                        cbxTable.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTable3_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 3;
            btnTable_Click(ref sender, ref e, 3, ref btnTable3, ref cbxTable3);
        }

        private void btnTable4_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 4;
            btnTable_Click(ref sender, ref e, 4, ref btnTable4, ref cbxTable4);
        }

        private void btnTable5_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 5;
            btnTable_Click(ref sender, ref e, 5, ref btnTable5, ref cbxTable5);
        }

        private void btnTable6_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 6;
            btnTable_Click(ref sender, ref e, 6, ref btnTable6, ref cbxTable6);
        }

        private void btnTable7_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 7;
            btnTable_Click(ref sender, ref e, 7, ref btnTable7, ref cbxTable7);
        }

        private void btnTable8_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 8;
            btnTable_Click(ref sender, ref e, 8, ref btnTable8, ref cbxTable8);
        }

        private void btnTable9_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 9;
            btnTable_Click(ref sender, ref e, 9, ref btnTable9, ref cbxTable9);
        }

        private void btnTable10_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 10;
            btnTable_Click(ref sender, ref e, 10, ref btnTable10, ref cbxTable10);
        }

        private void btnTable12_Click(object sender, EventArgs e)
        {
            currentOrderForm.TableNumber = 12;
            btnTable_Click(ref sender, ref e, 12, ref btnTable12, ref cbxTable12);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            MessageBox.Show(manager.manage_inventory(), "Notification");
            inventoryForm inventoryForm = new inventoryForm();
            inventoryForm.Show();
        }

        private void lbLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Loginform loginform = new Loginform();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Role = loginform.Role;
                if (Role == 2 || Role == -1)
                {
                    btnManage.Visible = false;
                    btnReport.Visible = false;
                }
                if (Role == 1)
                {
                    btnManage.Visible = true;
                    btnReport.Visible = true;
                }
            }
            Form1_Load(sender, e);
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            reportForm.ShowDialog();
            if (reportForm.DialogResult == DialogResult.OK)
            {
               reportForm.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
