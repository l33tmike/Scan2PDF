namespace Scan2PDF
{
    partial class frmConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.valJpegCompression = new System.Windows.Forms.NumericUpDown();
            this.txtSaveLoc = new System.Windows.Forms.TextBox();
            this.cmdBrowseForSaveLoc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.valJpegCompression)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "JPEG Compression Ratio";
            // 
            // valJpegCompression
            // 
            this.valJpegCompression.Location = new System.Drawing.Point(143, 148);
            this.valJpegCompression.Name = "valJpegCompression";
            this.valJpegCompression.Size = new System.Drawing.Size(120, 20);
            this.valJpegCompression.TabIndex = 1;
            // 
            // txtSaveLoc
            // 
            this.txtSaveLoc.Location = new System.Drawing.Point(143, 176);
            this.txtSaveLoc.Name = "txtSaveLoc";
            this.txtSaveLoc.Size = new System.Drawing.Size(120, 20);
            this.txtSaveLoc.TabIndex = 2;
            // 
            // cmdBrowseForSaveLoc
            // 
            this.cmdBrowseForSaveLoc.Location = new System.Drawing.Point(269, 174);
            this.cmdBrowseForSaveLoc.Name = "cmdBrowseForSaveLoc";
            this.cmdBrowseForSaveLoc.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseForSaveLoc.TabIndex = 3;
            this.cmdBrowseForSaveLoc.Text = "Browse";
            this.cmdBrowseForSaveLoc.UseVisualStyleBackColor = true;
            this.cmdBrowseForSaveLoc.Click += new System.EventHandler(this.cmdBrowseForSaveLoc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save Location";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scan2PDF";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 64);
            this.label5.TabIndex = 7;
            this.label5.Text = "Scan2PDF - Basic app that takes an image file, compresses it and embeds it into a" +
                " PDF and saves the file (using PdfSharp) with no interaction required!";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 94);
            this.label6.TabIndex = 8;
            this.label6.Text = "Provided free with no implied warranties and no support - use at your own risk!\r\n" +
                "\r\nFuture ideas: Scan2PDF+Email\r\n\r\n©2011 Michael Curry";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(331, 35);
            this.label7.TabIndex = 9;
            this.label7.Text = "Options";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(12, 203);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(331, 32);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 352);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBrowseForSaveLoc);
            this.Controls.Add(this.txtSaveLoc);
            this.Controls.Add(this.valJpegCompression);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.Text = "Scan2PDF Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valJpegCompression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown valJpegCompression;
        private System.Windows.Forms.TextBox txtSaveLoc;
        private System.Windows.Forms.Button cmdBrowseForSaveLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdSave;
    }
}