namespace WinBinFex
{
    partial class Form1
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
            this.button_convert = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox_file_path = new System.Windows.Forms.TextBox();
            this.button_explorer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button_convert
            // 
            this.button_convert.Location = new System.Drawing.Point(270, 188);
            this.button_convert.Margin = new System.Windows.Forms.Padding(4);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(103, 51);
            this.button_convert.TabIndex = 0;
            this.button_convert.Text = "Convert";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Click += new System.EventHandler(this.button_convert_OnClick);
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_file_path.Location = new System.Drawing.Point(32, 135);
            this.textBox_file_path.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.Size = new System.Drawing.Size(527, 24);
            this.textBox_file_path.TabIndex = 1;
            // 
            // button_explorer
            // 
            this.button_explorer.Location = new System.Drawing.Point(567, 135);
            this.button_explorer.Margin = new System.Windows.Forms.Padding(4);
            this.button_explorer.Name = "button_explorer";
            this.button_explorer.Size = new System.Drawing.Size(45, 24);
            this.button_explorer.TabIndex = 2;
            this.button_explorer.Text = "...";
            this.button_explorer.UseVisualStyleBackColor = true;
            this.button_explorer.Click += new System.EventHandler(this.button_fileExplorer_OnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Specify an input BIN or FEX file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Application that convert BIN to Fex and FEX to BIN files of Allwinner Sunxi SoCs";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(29, 296);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(56, 17);
            this.label_status.TabIndex = 14;
            this.label_status.Text = "Status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Version 1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 326);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_explorer);
            this.Controls.Add(this.textBox_file_path);
            this.Controls.Add(this.button_convert);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(681, 373);
            this.MinimumSize = new System.Drawing.Size(681, 373);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunxi Tools for Windows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_convert;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.Button button_explorer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

