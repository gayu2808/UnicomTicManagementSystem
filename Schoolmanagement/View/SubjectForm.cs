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
    public partial class SubjectForm : Form
    {
        SubjectController scon = new SubjectController();
        CourseController course = new CourseController();

        public int SubjectId { get; private set; }

        public SubjectForm()
        {
            InitializeComponent();

            LoadSubject();
            LoadCourse();
        }
        public void LoadSubject()
        {
            var subjects = scon.GetAllSubjects(); 
            dgvsub.DataSource = subjects;
        }
        public void LoadCourse()
        {
            var courses = course.GetAllCourses(); 
            com_course.DataSource = courses; 
            com_course.DisplayMember = "CourseName";
            com_course.ValueMember = "CourseId"; 
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tname.Text) || com_course.SelectedItem == null)
            {
                MessageBox.Show("Please enter a valid Subject Name and select a Course.");
                return;
            }

            var subject = new Subject
            {
                SubjectName = tname.Text,
                CourseId = Convert.ToInt32(com_course.SelectedValue) 
            };

            scon.AddSubject(subject); 
            MessageBox.Show("Subject added successfully!");
            LoadSubject();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvsub.SelectedRows.Count > 0) 
            {
                int subjectId = Convert.ToInt32(dgvsub.SelectedRows[0].Cells[0].Value); 

                var subject = scon.GetSubjectById(subjectId); 
                if (subject != null)
                {
                    subject.SubjectName = tname.Text;
                    subject.CourseId = Convert.ToInt32(com_course.SelectedValue);  

                    scon.UpdateSubject(subject);  
                    MessageBox.Show("Subject updated successfully!");
                    LoadSubject();
                }
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvsub.SelectedRows.Count > 0)  
            {
                int subjectId = Convert.ToInt32(dgvsub.SelectedRows[0].Cells[0].Value);
                scon.DeleteSubject(subjectId); 
                MessageBox.Show("Subject deleted successfully!");
                LoadSubject();
            }
        }
    }
}

