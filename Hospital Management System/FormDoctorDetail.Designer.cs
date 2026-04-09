namespace Hospital_Management_System
{
    partial class FormDoctorDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDetail = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataAppointmentsList = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetInfo = new System.Windows.Forms.Button();
            this.btnAnnouncment = new System.Windows.Forms.Button();
            this.btnInternet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAppointmentsList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doktor Bilgi";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(102, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 23);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Null Null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ad Soyad:";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(102, 56);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(120, 23);
            this.lblTC.TabIndex = 1;
            this.lblTC.Text = "00000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "T.C. No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDetail);
            this.groupBox2.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Randevu Detay";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(11, 30);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(222, 162);
            this.txtDetail.TabIndex = 0;
            this.txtDetail.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataAppointmentsList);
            this.groupBox3.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(257, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 527);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Listesi";
            // 
            // dataAppointmentsList
            // 
            this.dataAppointmentsList.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAppointmentsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataAppointmentsList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataAppointmentsList.Location = new System.Drawing.Point(3, 27);
            this.dataAppointmentsList.Name = "dataAppointmentsList";
            this.dataAppointmentsList.Size = new System.Drawing.Size(519, 497);
            this.dataAppointmentsList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAnnouncment);
            this.groupBox4.Controls.Add(this.btnInternet);
            this.groupBox4.Controls.Add(this.btnSetInfo);
            this.groupBox4.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox4.Location = new System.Drawing.Point(12, 378);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 161);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hızlı Erişim";
            // 
            // btnSetInfo
            // 
            this.btnSetInfo.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSetInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSetInfo.Location = new System.Drawing.Point(11, 30);
            this.btnSetInfo.Name = "btnSetInfo";
            this.btnSetInfo.Size = new System.Drawing.Size(222, 35);
            this.btnSetInfo.TabIndex = 0;
            this.btnSetInfo.Text = "BİLGİ DÜZENLE";
            this.btnSetInfo.UseVisualStyleBackColor = false;
            // 
            // btnAnnouncment
            // 
            this.btnAnnouncment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAnnouncment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnnouncment.Location = new System.Drawing.Point(11, 71);
            this.btnAnnouncment.Name = "btnAnnouncment";
            this.btnAnnouncment.Size = new System.Drawing.Size(222, 35);
            this.btnAnnouncment.TabIndex = 1;
            this.btnAnnouncment.Text = "DUYURULAR";
            this.btnAnnouncment.UseVisualStyleBackColor = false;
            // 
            // btnInternet
            // 
            this.btnInternet.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInternet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInternet.Location = new System.Drawing.Point(11, 112);
            this.btnInternet.Name = "btnInternet";
            this.btnInternet.Size = new System.Drawing.Size(222, 35);
            this.btnInternet.TabIndex = 2;
            this.btnInternet.Text = "İNTERNET";
            this.btnInternet.UseVisualStyleBackColor = false;
            // 
            // FormDoctorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(794, 547);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormDoctorDetail";
            this.Text = "Doktor Detay Ekranı";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAppointmentsList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataAppointmentsList;
        private System.Windows.Forms.RichTextBox txtDetail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAnnouncment;
        private System.Windows.Forms.Button btnInternet;
        private System.Windows.Forms.Button btnSetInfo;
    }
}