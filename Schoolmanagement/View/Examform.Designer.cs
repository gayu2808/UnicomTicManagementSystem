namespace Schoolmanagement.View
{
    partial class Examform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Examform));
            this.label1 = new System.Windows.Forms.Label();
            this.texname = new System.Windows.Forms.TextBox();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.dgvname = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tsubid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvname)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam Name";
            // 
            // texname
            // 
            this.texname.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.texname.Location = new System.Drawing.Point(306, 98);
            this.texname.Name = "texname";
            this.texname.Size = new System.Drawing.Size(173, 20);
            this.texname.TabIndex = 8;
            // 
            // btnsub
            // 
            this.btnsub.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnsub.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsub.Location = new System.Drawing.Point(505, 204);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(114, 42);
            this.btnsub.TabIndex = 16;
            this.btnsub.Text = "Submit";
            this.btnsub.UseVisualStyleBackColor = false;
            this.btnsub.Click += new System.EventHandler(this.btnsub_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(505, 300);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(114, 42);
            this.btnclear.TabIndex = 17;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // dgvname
            // 
            this.dgvname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvname.Location = new System.Drawing.Point(83, 204);
            this.dgvname.Name = "dgvname";
            this.dgvname.Size = new System.Drawing.Size(377, 150);
            this.dgvname.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "SubjectId";
            // 
            // tsubid
            // 
            this.tsubid.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tsubid.Location = new System.Drawing.Point(306, 143);
            this.tsubid.Name = "tsubid";
            this.tsubid.Size = new System.Drawing.Size(173, 20);
            this.tsubid.TabIndex = 20;
            // 
            // Examform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(721, 461);
            this.Controls.Add(this.tsubid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvname);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsub);
            this.Controls.Add(this.texname);
            this.Controls.Add(this.label1);
            this.Name = "Examform";
            this.Text = "Examform";
            ((System.ComponentModel.ISupportInitialize)(this.dgvname)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox texname;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.DataGridView dgvname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tsubid;
    }
}