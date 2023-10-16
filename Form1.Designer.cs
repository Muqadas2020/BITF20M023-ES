
namespace ASSIGNMENT_04
{
    partial class Calculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nclear = new System.Windows.Forms.Button();
            this.ndivide = new System.Windows.Forms.Button();
            this.nc = new System.Windows.Forms.Button();
            this.nminus = new System.Windows.Forms.Button();
            this.n7 = new System.Windows.Forms.Button();
            this.n8 = new System.Windows.Forms.Button();
            this.n9 = new System.Windows.Forms.Button();
            this.nmultiply = new System.Windows.Forms.Button();
            this.n1 = new System.Windows.Forms.Button();
            this.n2 = new System.Windows.Forms.Button();
            this.n3 = new System.Windows.Forms.Button();
            this.n4 = new System.Windows.Forms.Button();
            this.n5 = new System.Windows.Forms.Button();
            this.n6 = new System.Windows.Forms.Button();
            this.n0 = new System.Windows.Forms.Button();
            this.ndot = new System.Windows.Forms.Button();
            this.nequal = new System.Windows.Forms.Button();
            this.nplus = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DisplayHistory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nclear
            // 
            this.nclear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nclear.Location = new System.Drawing.Point(374, 137);
            this.nclear.Name = "nclear";
            this.nclear.Size = new System.Drawing.Size(70, 61);
            this.nclear.TabIndex = 0;
            this.nclear.Text = "backspace";
            this.nclear.UseVisualStyleBackColor = true;
            this.nclear.Click += new System.EventHandler(this.nbackspace_Click);
            // 
            // ndivide
            // 
            this.ndivide.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ndivide.Location = new System.Drawing.Point(298, 137);
            this.ndivide.Name = "ndivide";
            this.ndivide.Size = new System.Drawing.Size(70, 61);
            this.ndivide.TabIndex = 1;
            this.ndivide.Text = "/";
            this.ndivide.UseVisualStyleBackColor = true;
            this.ndivide.Click += new System.EventHandler(this.operators_click);
            // 
            // nc
            // 
            this.nc.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nc.Location = new System.Drawing.Point(146, 137);
            this.nc.Name = "nc";
            this.nc.Size = new System.Drawing.Size(70, 61);
            this.nc.TabIndex = 3;
            this.nc.Text = "C";
            this.nc.UseVisualStyleBackColor = true;
            this.nc.Click += new System.EventHandler(this.nclear_click);
            // 
            // nminus
            // 
            this.nminus.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nminus.Location = new System.Drawing.Point(222, 137);
            this.nminus.Name = "nminus";
            this.nminus.Size = new System.Drawing.Size(70, 61);
            this.nminus.TabIndex = 2;
            this.nminus.Text = "-";
            this.nminus.UseVisualStyleBackColor = true;
            this.nminus.Click += new System.EventHandler(this.operators_click);
            // 
            // n7
            // 
            this.n7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n7.Location = new System.Drawing.Point(146, 204);
            this.n7.Name = "n7";
            this.n7.Size = new System.Drawing.Size(70, 61);
            this.n7.TabIndex = 7;
            this.n7.Text = "7";
            this.n7.UseVisualStyleBackColor = true;
            this.n7.Click += new System.EventHandler(this.n_click);
            // 
            // n8
            // 
            this.n8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n8.Location = new System.Drawing.Point(222, 204);
            this.n8.Name = "n8";
            this.n8.Size = new System.Drawing.Size(70, 61);
            this.n8.TabIndex = 6;
            this.n8.Text = "8";
            this.n8.UseVisualStyleBackColor = true;
            this.n8.Click += new System.EventHandler(this.n_click);
            // 
            // n9
            // 
            this.n9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n9.Location = new System.Drawing.Point(298, 204);
            this.n9.Name = "n9";
            this.n9.Size = new System.Drawing.Size(70, 61);
            this.n9.TabIndex = 5;
            this.n9.Text = "9";
            this.n9.UseVisualStyleBackColor = true;
            this.n9.Click += new System.EventHandler(this.n_click);
            // 
            // nmultiply
            // 
            this.nmultiply.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nmultiply.Location = new System.Drawing.Point(374, 204);
            this.nmultiply.Name = "nmultiply";
            this.nmultiply.Size = new System.Drawing.Size(70, 61);
            this.nmultiply.TabIndex = 4;
            this.nmultiply.Text = "X";
            this.nmultiply.UseVisualStyleBackColor = true;
            this.nmultiply.Click += new System.EventHandler(this.operators_click);
            // 
            // n1
            // 
            this.n1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n1.Location = new System.Drawing.Point(146, 338);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(70, 61);
            this.n1.TabIndex = 10;
            this.n1.Text = "1";
            this.n1.UseVisualStyleBackColor = true;
            this.n1.Click += new System.EventHandler(this.n_click);
            // 
            // n2
            // 
            this.n2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n2.Location = new System.Drawing.Point(222, 338);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(70, 61);
            this.n2.TabIndex = 9;
            this.n2.Text = "2";
            this.n2.UseVisualStyleBackColor = true;
            this.n2.Click += new System.EventHandler(this.n_click);
            // 
            // n3
            // 
            this.n3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n3.Location = new System.Drawing.Point(298, 338);
            this.n3.Name = "n3";
            this.n3.Size = new System.Drawing.Size(70, 61);
            this.n3.TabIndex = 8;
            this.n3.Text = "3";
            this.n3.UseVisualStyleBackColor = true;
            this.n3.Click += new System.EventHandler(this.n_click);
            // 
            // n4
            // 
            this.n4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n4.Location = new System.Drawing.Point(146, 271);
            this.n4.Name = "n4";
            this.n4.Size = new System.Drawing.Size(70, 61);
            this.n4.TabIndex = 13;
            this.n4.Text = "4";
            this.n4.UseVisualStyleBackColor = true;
            this.n4.Click += new System.EventHandler(this.n_click);
            // 
            // n5
            // 
            this.n5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n5.Location = new System.Drawing.Point(222, 271);
            this.n5.Name = "n5";
            this.n5.Size = new System.Drawing.Size(70, 61);
            this.n5.TabIndex = 12;
            this.n5.Text = "5";
            this.n5.UseVisualStyleBackColor = true;
            this.n5.Click += new System.EventHandler(this.n_click);
            // 
            // n6
            // 
            this.n6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n6.Location = new System.Drawing.Point(298, 271);
            this.n6.Name = "n6";
            this.n6.Size = new System.Drawing.Size(70, 61);
            this.n6.TabIndex = 11;
            this.n6.Text = "6";
            this.n6.UseVisualStyleBackColor = true;
            this.n6.Click += new System.EventHandler(this.n_click);
            // 
            // n0
            // 
            this.n0.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n0.Location = new System.Drawing.Point(146, 405);
            this.n0.Name = "n0";
            this.n0.Size = new System.Drawing.Size(146, 61);
            this.n0.TabIndex = 16;
            this.n0.Text = "0";
            this.n0.UseVisualStyleBackColor = true;
            this.n0.Click += new System.EventHandler(this.n_click);
            // 
            // ndot
            // 
            this.ndot.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ndot.Location = new System.Drawing.Point(298, 405);
            this.ndot.Name = "ndot";
            this.ndot.Size = new System.Drawing.Size(70, 61);
            this.ndot.TabIndex = 15;
            this.ndot.Text = ".";
            this.ndot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ndot.UseVisualStyleBackColor = true;
            this.ndot.Click += new System.EventHandler(this.n_click);
            // 
            // nequal
            // 
            this.nequal.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nequal.Location = new System.Drawing.Point(374, 405);
            this.nequal.Name = "nequal";
            this.nequal.Size = new System.Drawing.Size(70, 61);
            this.nequal.TabIndex = 14;
            this.nequal.Text = "=";
            this.nequal.UseVisualStyleBackColor = true;
            this.nequal.Click += new System.EventHandler(this.nequal_Click);
            // 
            // nplus
            // 
            this.nplus.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nplus.Location = new System.Drawing.Point(374, 271);
            this.nplus.Name = "nplus";
            this.nplus.Size = new System.Drawing.Size(70, 128);
            this.nplus.TabIndex = 17;
            this.nplus.Text = "+";
            this.nplus.UseVisualStyleBackColor = true;
            this.nplus.Click += new System.EventHandler(this.operators_click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(13, 51);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(431, 71);
            this.textBox.TabIndex = 18;
            this.textBox.Text = "0";
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 19;
            // 
            // DisplayHistory
            // 
            this.DisplayHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DisplayHistory.Location = new System.Drawing.Point(13, 137);
            this.DisplayHistory.Name = "DisplayHistory";
            this.DisplayHistory.Size = new System.Drawing.Size(127, 329);
            this.DisplayHistory.TabIndex = 20;
            this.DisplayHistory.Text = "No History yet.";
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 477);
            this.Controls.Add(this.DisplayHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.nplus);
            this.Controls.Add(this.n0);
            this.Controls.Add(this.ndot);
            this.Controls.Add(this.nequal);
            this.Controls.Add(this.n4);
            this.Controls.Add(this.n5);
            this.Controls.Add(this.n6);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.n3);
            this.Controls.Add(this.n7);
            this.Controls.Add(this.n8);
            this.Controls.Add(this.n9);
            this.Controls.Add(this.nmultiply);
            this.Controls.Add(this.nc);
            this.Controls.Add(this.nminus);
            this.Controls.Add(this.ndivide);
            this.Controls.Add(this.nclear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "calculator";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nclear;
        private System.Windows.Forms.Button ndivide;
        private System.Windows.Forms.Button nc;
        private System.Windows.Forms.Button nminus;
        private System.Windows.Forms.Button n7;
        private System.Windows.Forms.Button n8;
        private System.Windows.Forms.Button n9;
        private System.Windows.Forms.Button nmultiply;
        private System.Windows.Forms.Button n1;
        private System.Windows.Forms.Button n2;
        private System.Windows.Forms.Button n3;
        private System.Windows.Forms.Button n4;
        private System.Windows.Forms.Button n5;
        private System.Windows.Forms.Button n6;
        private System.Windows.Forms.Button n0;
        private System.Windows.Forms.Button ndot;
        private System.Windows.Forms.Button nequal;
        private System.Windows.Forms.Button nplus;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox DisplayHistory;
    }
}

