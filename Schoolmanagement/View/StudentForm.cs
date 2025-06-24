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
using System.Xml.Linq;

namespace Schoolmanagement
{
    public partial class StudentForm : Form
    {
        private StudentController studentController;
        public StudentForm()
        {
            InitializeComponent();
            studentController = new StudentController();

            LoadStudents();
        }
        private void LoadStudents()
        {
            var students = studentController.GetAllStudents();  // Fetch all students from DB
            dataGridView1.DataSource = students;
            // Bind students list to DataGridView
            // Optionally, you can format the columns after binding
            /* dataGridView1.Columns["StudentId"].Visible = false;  // Hide the StudentId column (if needed)
             dataGridView1.Columns["StudentName"].HeaderText = "Name";  // Rename column header
             dataGridView1.Columns["StudentAddress"].HeaderText = "Address";  // Rename column header
             dataGridView1.Columns["CourseName"].HeaderText = "Course Name";  // Rename column header
         }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Management_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
              
                int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var student = studentController.GetStudentById(studentId);

                if (student != null)
                {
                    tname.Text = student.StudentName;
                    taddress.Text = student.StudentAddress;
                    tcourse.Text = student.CourseId.ToString();  
                    student.StudentName = tname.Text;
                    student.StudentAddress = taddress.Text;
                    int courseId;
                    if (!int.TryParse(tcourse.Text, out courseId)) 
                    {
                        MessageBox.Show("Please enter a valid Course ID.");
                        return;
                    }
                    student.CourseId = courseId;
                    studentController.UpdateStudent(student);

                    MessageBox.Show("Student updated successfully!");
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Student not found!");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tcourse.Text) || !int.TryParse(tcourse.Text, out int courseId))
            {
                MessageBox.Show("Please enter a valid Course ID.");
                return;  // Exit the method if the Course ID is invalid
            }

            var student = new Student
            {
                StudentName = tname.Text,  // Get data from textboxes
                StudentAddress = taddress.Text,
                CourseId = courseId      // Assign validated CourseId
            };

            // Add the student to the database
            studentController.AddStudent(student);
            MessageBox.Show("Student added successfully!");
            LoadStudents();  // Refresh the list
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)  // Check if a student is selected
            {
                // Get the selected student's ID
                int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                // Delete the student from the database
                studentController.DeleteStudent(studentId);
                MessageBox.Show("Student deleted successfully!");
                LoadStudents();  // Refresh the list
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
