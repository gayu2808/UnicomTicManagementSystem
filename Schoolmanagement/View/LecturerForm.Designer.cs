namespace Schoolmanagement.View
{
    partial class LecturerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturerForm));
            this.dgv_details_lecturers = new System.Windows.Forms.DataGridView();
            this.btn_lecture_del = new System.Windows.Forms.Button();
            this.btn_lecture_edit = new System.Windows.Forms.Button();
            this.btn_lecture_add = new System.Windows.Forms.Button();
            this.taddress = new System.Windows.Forms.TextBox();
            this.tname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tphone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details_lecturers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_details_lecturers
            // 
            this.dgv_details_lecturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_details_lecturers.Location = new System.Drawing.Point(65, 211);
            this.dgv_details_lecturers.Name = "dgv_details_lecturers";
            this.dgv_details_lecturers.Size = new System.Drawing.Size(547, 189);
            this.dgv_details_lecturers.TabIndex = 29;
            // 
            // btn_lecture_del
            // 
            this.btn_lecture_del.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_lecture_del.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lecture_del.Location = new System.Drawing.Point(631, 361);
            this.btn_lecture_del.Name = "btn_lecture_del";
            this.btn_lecture_del.Size = new System.Drawing.Size(102, 29);
            this.btn_lecture_del.TabIndex = 28;
            this.btn_lecture_del.Text = "Delete";
            this.btn_lecture_del.UseVisualStyleBackColor = false;
            this.btn_lecture_del.Click += new System.EventHandler(this.btn_lecture_del_Click);
            // 
            // btn_lecture_edit
            // 
            this.btn_lecture_edit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_lecture_edit.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lecture_edit.Location = new System.Drawing.Point(631, 292);
            this.btn_lecture_edit.Name = "btn_lecture_edit";
            this.btn_lecture_edit.Size = new System.Drawing.Size(102, 30);
            this.btn_lecture_edit.TabIndex = 27;
            this.btn_lecture_edit.Text = "Edit";
            this.btn_lecture_edit.UseVisualStyleBackColor = false;
            this.btn_lecture_edit.Click += new System.EventHandler(this.btn_lecture_edit_Click);
            // 
            // btn_lecture_add
            // 
            this.btn_lecture_add.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_lecture_add.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lecture_add.Location = new System.Drawing.Point(631, 211);
            this.btn_lecture_add.Name = "btn_lecture_add";
            this.btn_lecture_add.Size = new System.Drawing.Size(102, 33);
            this.btn_lecture_add.TabIndex = 26;
            this.btn_lecture_add.Text = "Add";
            this.btn_lecture_add.UseVisualStyleBackColor = false;
            this.btn_lecture_add.Click += new System.EventHandler(this.button2_Click);
            // 
            // taddress
            // 
            this.taddress.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.taddress.Location = new System.Drawing.Point(300, 92);
            this.taddress.Name = "taddress";
            this.taddress.Size = new System.Drawing.Size(213, 20);
            this.taddress.TabIndex = 25;
            // 
            // tname
            // 
            this.tname.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tname.Location = new System.Drawing.Point(300, 47);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(213, 20);
            this.tname.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 30;
            this.label3.Text = "Phone";
            // 
            // tphone
            // 
            this.tphone.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tphone.Location = new System.Drawing.Point(300, 136);
            this.tphone.Name = "tphone";
            this.tphone.Size = new System.Drawing.Size(213, 20);
            this.tphone.TabIndex = 31;
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tphone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_details_lecturers);
            this.Controls.Add(this.btn_lecture_del);
            this.Controls.Add(this.btn_lecture_edit);
            this.Controls.Add(this.btn_lecture_add);
            this.Controls.Add(this.taddress);
            this.Controls.Add(this.tname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LecturerForm";
            this.Text = "LecturerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details_lecturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_details_lecturers;
        private System.Windows.Forms.Button btn_lecture_del;
        private System.Windows.Forms.Button btn_lecture_edit;
        private System.Windows.Forms.Button btn_lecture_add;
        private System.Windows.Forms.TextBox taddress;
        private System.Windows.Forms.TextBox tname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tphone;
    }
}