using Schoolmanagement.Controller;
using Schoolmanagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolmanagement.View
{
    public partial class LecturerForm : Form
    {
        LecturerController controller = new LecturerController();
        public LecturerForm()
        {
            InitializeComponent();
            LoadLecturers();
        }

        public void LoadLecturers() 
        {
            var lecturers = controller.GetAllLecturers();
            dgv_details_lecturers.DataSource = lecturers;

        }
        private void button2_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrWhiteSpace(tname.Text) || string.IsNullOrWhiteSpace(taddress.Text)) 
            {
                MessageBox.Show("Please enter valid Name and Address.");
                return;
            }

            var lecturer = new Lecturer
            {
                Name = tname.Text,
                Address = taddress.Text,
                Phone = tphone.Text,
               
            };

            controller.AddLecturers(lecturer);
            MessageBox.Show("Lecturer added successfully!");
            LoadLecturers();  
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_lecture_edit_Click(object sender, EventArgs e)
        {
            if (dgv_details_lecturers.SelectedRows.Count > 0)
            {
                int lecturerId = Convert.ToInt32(dgv_details_lecturers.SelectedRows[0].Cells[0].Value);

                var lecturer = controller.GetLecturertById(lecturerId);

                if (lecturer != null)
                {
                    tname.Text = lecturer.Name;
                    taddress.Text = lecturer.Address;
                    tphone.Text = lecturer.Phone;

                    lecturer.Name = tname.Text;
                    lecturer.Address = taddress.Text;
                    lecturer.Phone = tphone.Text;

                    controller.UpdateLecturers(lecturer);

                    MessageBox.Show("Lecturer updated successfully!");
                    LoadLecturers(); 
                }
                else
                {
                    MessageBox.Show("Lecturer not found!");
                }
            }
        }

        private void btn_lecture_del_Click(object sender, EventArgs e)
        {
            if (dgv_details_lecturers.SelectedRows.Count > 0)  
            {
                int lecturerId = Convert.ToInt32(dgv_details_lecturers.SelectedRows[0].Cells[0].Value);

                controller.DeleteLecturers(lecturerId);
                MessageBox.Show("Lecturer deleted successfully!");
                LoadLecturers(); 
            }
        }
    }
    }
    

