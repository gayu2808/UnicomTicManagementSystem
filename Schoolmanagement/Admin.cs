using Schoolmanagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolmanagement
{
    public partial class Adminform : Form
    {

        public Adminform()
        {
            InitializeComponent();
            
        }


        public void LoadForm(object formObj)
        {
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Examform form = new Examform();
            LoadForm(form);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            LoadForm(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LecturerForm form = new LecturerForm();
            LoadForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffForm form = new StaffForm();
            LoadForm(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Courseform form = new Courseform();
            LoadForm(form);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SubjectForm form = new SubjectForm();
            LoadForm(form);
        }
    }
}
