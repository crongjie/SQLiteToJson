namespace SQLiteToJson
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "output";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(393, 476);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(118, 27);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Output:";
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(27, 68);
            this.tb_output.MaxLength = 3276700;
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_output.Size = new System.Drawing.Size(484, 398);
            this.tb_output.TabIndex = 8;
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(258, 476);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(118, 27);
            this.btn_process.TabIndex = 11;
            this.btn_process.Text = "Process";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(437, 8);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(110, 26);
            this.btn_browse.TabIndex = 12;
            this.btn_browse.Text = "Browse DB";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(27, 12);
            this.tb_file.Name = "tb_file";
            this.tb_file.ReadOnly = true;
            this.tb_file.Size = new System.Drawing.Size(404, 19);
            this.tb_file.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "sqlite";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 516);
            this.Controls.Add(this.tb_file);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

