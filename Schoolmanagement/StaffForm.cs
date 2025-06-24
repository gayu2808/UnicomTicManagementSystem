using Schoolmanagement.Controller;
using Schoolmanagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Schoolmanagement
{
    public partial class StaffForm : Form
    {
        StaffController controller = new StaffController();

        private static string connectionString = "Data Source=Unicomtic.db;Version=3;";

        public object StaffName { get; internal set; }
        public object StaffAddress { get; internal set; }
        public object CourseId { get; internal set; }
        public int StaffId { get; internal set; }

        public StaffForm()
        {
            InitializeComponent();
            LoadStaffs();
        }

        public void LoadStaffs() 
        {
        
        }
        private void Staff_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tname.Text) || string.IsNullOrWhiteSpace(taddress.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter valid Name, Address, and Course.");
                return;
            }

            var staff = new StaffForm
            {
                StaffName = tname.Text,
                StaffAddress = taddress.Text,
                CourseId = Convert.ToInt32(textBox1.Text)
            };
            controller.AddStaff(staff);
            MessageBox.Show("Staff added successfully!");
            LoadStaffs();  
        }


        private void LoadStaffData()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                var staffs = controller.GetAllStaffs();
                dataGridView1.DataSource = staffs;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                tname.Text = row.Cells["StaffName"].Value.ToString();
                taddress.Text = row.Cells["StaffAddress"].Value.ToString();
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                int staffId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                var staff = controller.GetStaffById(staffId);
                if (staff != null)
                {
                    staff.StaffName = tname.Text;
                    staff.StaffAddress = taddress.Text;
                    staff.CourseId = Convert.ToInt32(textBox1.Text);

                    controller.UpdateStaff(staff);
                    MessageBox.Show("Staff updated successfully!");
                    LoadStaffs(); 
                }
            }
        }
        


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int staffId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StaffId"].Value);

                var confirm = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "DELETE FROM Staffs WHERE StaffId = @id";
                        cmd.Parameters.AddWithValue("@id", staffId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Staff record deleted.");
                    LoadStaffData();
                    
                }
            }
            else
            {
                MessageBox.Show("Please select a staff record to delete.");
            }
        }
    }
}


