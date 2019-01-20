namespace GTBay
{
    partial class UserReport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Listed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purchased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doneButton = new System.Windows.Forms.Button();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Listed,
            this.Sold,
            this.Purchased,
            this.Rated});
            this.dataGridView1.Location = new System.Drawing.Point(29, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(544, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Listed
            // 
            this.Listed.HeaderText = "Listed";
            this.Listed.Name = "Listed";
            this.Listed.ReadOnly = true;
            // 
            // Sold
            // 
            this.Sold.HeaderText = "Sold";
            this.Sold.Name = "Sold";
            this.Sold.ReadOnly = true;
            // 
            // Purchased
            // 
            this.Purchased.HeaderText = "Purchased";
            this.Purchased.Name = "Purchased";
            this.Purchased.ReadOnly = true;
            // 
            // Rated
            // 
            this.Rated.HeaderText = "Rated";
            this.Rated.Name = "Rated";
            this.Rated.ReadOnly = true;
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(453, 377);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(119, 30);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // UserReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 424);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserReport";
            this.Text = "UserReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Listed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purchased;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rated;
        private System.Windows.Forms.Button doneButton;
    }
}