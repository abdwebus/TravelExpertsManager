namespace TravelExpertsManager
{
    partial class ProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            this.prodCmBox = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.addTxtBox = new System.Windows.Forms.TextBox();
            this.edtBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // prodCmBox
            // 
            this.prodCmBox.FormattingEnabled = true;
            this.prodCmBox.Location = new System.Drawing.Point(143, 66);
            this.prodCmBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prodCmBox.Name = "prodCmBox";
            this.prodCmBox.Size = new System.Drawing.Size(96, 21);
            this.prodCmBox.TabIndex = 0;
            this.prodCmBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(302, 99);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(54, 26);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "ADD";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // addTxtBox
            // 
            this.addTxtBox.Location = new System.Drawing.Point(256, 67);
            this.addTxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addTxtBox.Name = "addTxtBox";
            this.addTxtBox.Size = new System.Drawing.Size(102, 20);
            this.addTxtBox.TabIndex = 3;
            this.addTxtBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // edtBtn
            // 
            this.edtBtn.Location = new System.Drawing.Point(293, 151);
            this.edtBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.edtBtn.Name = "edtBtn";
            this.edtBtn.Size = new System.Drawing.Size(65, 27);
            this.edtBtn.TabIndex = 4;
            this.edtBtn.Text = "UPDATE";
            this.edtBtn.UseVisualStyleBackColor = true;
            this.edtBtn.Click += new System.EventHandler(this.edtBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TravelExpertsManager.Properties.Resources.jay3;
            this.pictureBox1.Location = new System.Drawing.Point(2, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 145);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 225);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.edtBtn);
            this.Controls.Add(this.addTxtBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.prodCmBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox prodCmBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox addTxtBox;
        private System.Windows.Forms.Button edtBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}