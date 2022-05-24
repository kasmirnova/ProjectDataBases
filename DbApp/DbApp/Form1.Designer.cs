
namespace DbApp
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
            this.save = new System.Windows.Forms.Button();
            this.saveas = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.option = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(866, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(125, 39);
            this.save.TabIndex = 0;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // saveas
            // 
            this.saveas.Location = new System.Drawing.Point(866, 57);
            this.saveas.Name = "saveas";
            this.saveas.Size = new System.Drawing.Size(125, 39);
            this.saveas.TabIndex = 1;
            this.saveas.Text = "Save as";
            this.saveas.UseVisualStyleBackColor = true;
            this.saveas.Click += new System.EventHandler(this.saveas_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(866, 102);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(125, 39);
            this.clear.TabIndex = 2;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(866, 147);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(125, 39);
            this.update.TabIndex = 3;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // option
            // 
            this.option.Location = new System.Drawing.Point(866, 192);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(125, 39);
            this.option.TabIndex = 5;
            this.option.Text = "Option";
            this.option.UseVisualStyleBackColor = true;
            this.option.Click += new System.EventHandler(this.option_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(848, 465);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 489);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.option);
            this.Controls.Add(this.update);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.saveas);
            this.Controls.Add(this.save);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button saveas;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button option;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

