
namespace DbApp
{
    partial class OptionForm
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
            this.okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sizebox = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.Label();
            this.sizepx = new System.Windows.Forms.Label();
            this.addcolumnbut = new System.Windows.Forms.Button();
            this.removecolumbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(631, 399);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(114, 39);
            this.okbutton.TabIndex = 1;
            this.okbutton.Text = "Ok";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(751, 399);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(114, 39);
            this.cancelbutton.TabIndex = 2;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(12, 62);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(100, 22);
            this.textbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // sizebox
            // 
            this.sizebox.Location = new System.Drawing.Point(71, 246);
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(100, 22);
            this.sizebox.TabIndex = 5;
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size.Location = new System.Drawing.Point(8, 246);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(47, 20);
            this.size.TabIndex = 6;
            this.size.Text = "Size:";
            // 
            // sizepx
            // 
            this.sizepx.AutoSize = true;
            this.sizepx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizepx.Location = new System.Drawing.Point(177, 246);
            this.sizepx.Name = "sizepx";
            this.sizepx.Size = new System.Drawing.Size(26, 20);
            this.sizepx.TabIndex = 7;
            this.sizepx.Text = "px";
            // 
            // addcolumnbut
            // 
            this.addcolumnbut.Location = new System.Drawing.Point(631, 159);
            this.addcolumnbut.Name = "addcolumnbut";
            this.addcolumnbut.Size = new System.Drawing.Size(114, 39);
            this.addcolumnbut.TabIndex = 8;
            this.addcolumnbut.Text = "Add";
            this.addcolumnbut.UseVisualStyleBackColor = true;
            this.addcolumnbut.Click += new System.EventHandler(this.addcolumnbut_Click);
            // 
            // removecolumbut
            // 
            this.removecolumbut.Location = new System.Drawing.Point(751, 159);
            this.removecolumbut.Name = "removecolumbut";
            this.removecolumbut.Size = new System.Drawing.Size(114, 39);
            this.removecolumbut.TabIndex = 9;
            this.removecolumbut.Text = "Remove";
            this.removecolumbut.UseVisualStyleBackColor = true;
            this.removecolumbut.Click += new System.EventHandler(this.removecolumbut_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 450);
            this.Controls.Add(this.removecolumbut);
            this.Controls.Add(this.addcolumnbut);
            this.Controls.Add(this.sizepx);
            this.Controls.Add(this.size);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.okbutton);
            this.Name = "OptionForm";
            this.Text = "OptionForm";
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizebox;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Label sizepx;
        private System.Windows.Forms.Button addcolumnbut;
        private System.Windows.Forms.Button removecolumbut;
    }
}