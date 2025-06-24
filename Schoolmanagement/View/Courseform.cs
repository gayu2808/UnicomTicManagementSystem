using Schoolmanagement.Controller;
using Schoolmanagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Schoolmanagement.Controller.CourseController;
using static System.Collections.Specialized.BitVector32;

namespace Schoolmanagement.View
{
    public partial class Courseform : Form
    {
        CourseController controller = new CourseController();
        public Courseform()
        {
            InitializeComponent();
            LoadCourses();
        }
        private void LoadCourses()
        {
            var courses = controller.GetAllCourses();
            dataGridViewCourses.DataSource = courses;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Courseform_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tcourse.Text))
            {
                MessageBox.Show("Please enter a valid Course Name.");
                return;
            }

            var course = new Course
            {
                CourseName = tcourse.Text
            };

            controller.AddCourse(course);
            MessageBox.Show("Course added successfully!");
            LoadCourses();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count > 0)
            {
                // Get the selected course ID
                int courseId = Convert.ToInt32(dataGridViewCourses.SelectedRows[0].Cells[0].Value);

                // Fetch the course details
                var course = controller.GetCourseById(courseId);

                if (course != null)
                {
                    // Update course name
                    course.CourseName = tcourse.Text; // Get the new course name from the textbox

                    // Update the course in the database
                    controller.UpdateCourse(course);
                    MessageBox.Show("Course updated successfully!");
                    LoadCourses();  // Refresh the list
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
