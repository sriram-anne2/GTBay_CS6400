namespace GTBay
{
    partial class CategoryReport
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
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AveragePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Category,
            this.TotalItem,
            this.MinPrice,
            this.MaxPrice,
            this.AveragePrice});
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(545, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // TotalItem
            // 
            this.TotalItem.HeaderText = "Total Items";
            this.TotalItem.Name = "TotalItem";
            this.TotalItem.ReadOnly = true;
            // 
            // MinPrice
            // 
            this.MinPrice.HeaderText = "Min Price";
            this.MinPrice.Name = "MinPrice";
            this.MinPrice.ReadOnly = true;
            // 
            // MaxPrice
            // 
            this.MaxPrice.HeaderText = "Max Price";
            this.MaxPrice.Name = "MaxPrice";
            this.MaxPrice.ReadOnly = true;
            // 
            // AveragePrice
            // 
            this.AveragePrice.HeaderText = "Average Price";
            this.AveragePrice.Name = "AveragePrice";
            this.AveragePrice.ReadOnly = true;
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(446, 415);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(95, 32);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // CategoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 459);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CategoryReport";
            this.Text = "CategoryReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn AveragePrice;
        private System.Windows.Forms.Button doneButton;
    }
}