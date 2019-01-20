namespace GTBay
{
    partial class ItemSearch
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
            this.keywordLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.minPriceLabel = new System.Windows.Forms.Label();
            this.maxPriceLabel = new System.Windows.Forms.Label();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.categoryDropDown = new System.Windows.Forms.ComboBox();
            this.conditionDropDown = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // keywordLabel
            // 
            this.keywordLabel.AutoSize = true;
            this.keywordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keywordLabel.Location = new System.Drawing.Point(49, 42);
            this.keywordLabel.Name = "keywordLabel";
            this.keywordLabel.Size = new System.Drawing.Size(66, 18);
            this.keywordLabel.TabIndex = 0;
            this.keywordLabel.Text = "Keyword";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(49, 86);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(68, 18);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Category";
            // 
            // minPriceLabel
            // 
            this.minPriceLabel.AutoSize = true;
            this.minPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minPriceLabel.Location = new System.Drawing.Point(49, 130);
            this.minPriceLabel.Name = "minPriceLabel";
            this.minPriceLabel.Size = new System.Drawing.Size(119, 18);
            this.minPriceLabel.TabIndex = 2;
            this.minPriceLabel.Text = "Minimum Price $";
            // 
            // maxPriceLabel
            // 
            this.maxPriceLabel.AutoSize = true;
            this.maxPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPriceLabel.Location = new System.Drawing.Point(49, 174);
            this.maxPriceLabel.Name = "maxPriceLabel";
            this.maxPriceLabel.Size = new System.Drawing.Size(123, 18);
            this.maxPriceLabel.TabIndex = 3;
            this.maxPriceLabel.Text = "Maximum Price $";
            // 
            // conditionLabel
            // 
            this.conditionLabel.AutoSize = true;
            this.conditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionLabel.Location = new System.Drawing.Point(49, 225);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(122, 18);
            this.conditionLabel.TabIndex = 4;
            this.conditionLabel.Text = "Condition at least";
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(178, 40);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(359, 20);
            this.keywordTextBox.TabIndex = 5;
            // 
            // categoryDropDown
            // 
            this.categoryDropDown.FormattingEnabled = true;
            this.categoryDropDown.Location = new System.Drawing.Point(178, 83);
            this.categoryDropDown.Name = "categoryDropDown";
            this.categoryDropDown.Size = new System.Drawing.Size(160, 21);
            this.categoryDropDown.TabIndex = 8;
            // 
            // conditionDropDown
            // 
            this.conditionDropDown.FormattingEnabled = true;
            this.conditionDropDown.Location = new System.Drawing.Point(178, 222);
            this.conditionDropDown.Name = "conditionDropDown";
            this.conditionDropDown.Size = new System.Drawing.Size(160, 21);
            this.conditionDropDown.TabIndex = 9;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(435, 272);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(145, 34);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(260, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(145, 34);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Location = new System.Drawing.Point(178, 130);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(154, 20);
            this.minPriceTextBox.TabIndex = 12;
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Location = new System.Drawing.Point(178, 172);
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(154, 20);
            this.maxPriceTextBox.TabIndex = 13;
            // 
            // ItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 322);
            this.Controls.Add(this.maxPriceTextBox);
            this.Controls.Add(this.minPriceTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.conditionDropDown);
            this.Controls.Add(this.categoryDropDown);
            this.Controls.Add(this.keywordTextBox);
            this.Controls.Add(this.conditionLabel);
            this.Controls.Add(this.maxPriceLabel);
            this.Controls.Add(this.minPriceLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.keywordLabel);
            this.Name = "ItemSearch";
            this.Text = "ItemSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keywordLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label minPriceLabel;
        private System.Windows.Forms.Label maxPriceLabel;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.ComboBox categoryDropDown;
        private System.Windows.Forms.ComboBox conditionDropDown;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.TextBox maxPriceTextBox;
    }
}