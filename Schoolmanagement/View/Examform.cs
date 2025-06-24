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
    public partial class Examform : Form
    {
        Examcontroller Examcontroller = new Examcontroller();
        public Examform()
        {
            InitializeComponent();
            LoadExams();
        }
        private void LoadExams()
        {
            var courses = Examcontroller.GetAllExams();
            dgvname.DataSource = courses;

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(texname.Text))
            {
                MessageBox.Show("Please enter a valid exam Name.");
                return;
            }

            int subjectId;
            if (!int.TryParse(tsubid.Text, out subjectId))
            {
                MessageBox.Show("Please enter a valid Subject ID.");
                return;
            }

            var exam = new Exam
            {
                ExamName = texname.Text,
                SubjectId = subjectId,  
            };

            Examcontroller.AddExam(exam);
            MessageBox.Show("Exam added successfully!");
            LoadExams();
        }
    

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (dgvname.SelectedRows.Count > 0)
            {
                int examId = Convert.ToInt32(dgvname.SelectedRows[0].Cells[0].Value);
                var exam = Examcontroller.GetExamById(examId);

                if (exam != null)
                {
                    exam.ExamName = texname.Text;

                    int subjectId;
                    if (int.TryParse(tsubid.Text, out subjectId))
                    {
                        exam.SubjectId = subjectId;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Subject ID.");
                        return;
                    }
                    Examcontroller.UpdateExam(exam);
                    MessageBox.Show("Exam updated successfully!");
                    LoadExams();
                }
            }
        }
    }
    }

