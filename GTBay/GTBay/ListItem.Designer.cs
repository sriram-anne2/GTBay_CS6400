namespace GTBay
{
    partial class ListItem
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
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.startBidLabel = new System.Windows.Forms.Label();
            this.minPriceLabel = new System.Windows.Forms.Label();
            this.auctionLengthLabel = new System.Windows.Forms.Label();
            this.getItNowLabel = new System.Windows.Forms.Label();
            this.returnLabel = new System.Windows.Forms.Label();
            this.returnCheckBox = new System.Windows.Forms.CheckBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.categoryDropDown = new System.Windows.Forms.ComboBox();
            this.conditionDropDown = new System.Windows.Forms.ComboBox();
            this.startBidTextBox = new System.Windows.Forms.TextBox();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.auctionLengthDropdown = new System.Windows.Forms.ComboBox();
            this.getItNowTextBox = new System.Windows.Forms.TextBox();
            this.optionalLabel = new System.Windows.Forms.Label();
            this.listItemButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.SuspendLayout();
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameLabel.Location = new System.Drawing.Point(41, 55);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(80, 18);
            this.itemNameLabel.TabIndex = 0;
            this.itemNameLabel.Text = "Item Name";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(41, 98);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(83, 18);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Description";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(41, 193);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(68, 18);
            this.categoryLabel.TabIndex = 2;
            this.categoryLabel.Text = "Category";
            // 
            // conditionLabel
            // 
            this.conditionLabel.AutoSize = true;
            this.conditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionLabel.Location = new System.Drawing.Point(41, 235);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(71, 18);
            this.conditionLabel.TabIndex = 3;
            this.conditionLabel.Text = "Condition";
            // 
            // startBidLabel
            // 
            this.startBidLabel.AutoSize = true;
            this.startBidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBidLabel.Location = new System.Drawing.Point(41, 278);
            this.startBidLabel.Name = "startBidLabel";
            this.startBidLabel.Size = new System.Drawing.Size(169, 18);
            this.startBidLabel.TabIndex = 4;
            this.startBidLabel.Text = "Start auction bidding at $";
            // 
            // minPriceLabel
            // 
            this.minPriceLabel.AutoSize = true;
            this.minPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minPriceLabel.Location = new System.Drawing.Point(41, 321);
            this.minPriceLabel.Name = "minPriceLabel";
            this.minPriceLabel.Size = new System.Drawing.Size(152, 18);
            this.minPriceLabel.TabIndex = 5;
            this.minPriceLabel.Text = "Minimum Sale Price $";
            // 
            // auctionLengthLabel
            // 
            this.auctionLengthLabel.AutoSize = true;
            this.auctionLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auctionLengthLabel.Location = new System.Drawing.Point(41, 370);
            this.auctionLengthLabel.Name = "auctionLengthLabel";
            this.auctionLengthLabel.Size = new System.Drawing.Size(110, 18);
            this.auctionLengthLabel.TabIndex = 6;
            this.auctionLengthLabel.Text = "Auction Ends in";
            // 
            // getItNowLabel
            // 
            this.getItNowLabel.AutoSize = true;
            this.getItNowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getItNowLabel.Location = new System.Drawing.Point(41, 413);
            this.getItNowLabel.Name = "getItNowLabel";
            this.getItNowLabel.Size = new System.Drawing.Size(126, 18);
            this.getItNowLabel.TabIndex = 7;
            this.getItNowLabel.Text = "Get It Now price $";
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnLabel.Location = new System.Drawing.Point(41, 459);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(133, 18);
            this.returnLabel.TabIndex = 8;
            this.returnLabel.Text = "Returns Accepted?";
            // 
            // returnCheckBox
            // 
            this.returnCheckBox.AutoSize = true;
            this.returnCheckBox.Location = new System.Drawing.Point(180, 463);
            this.returnCheckBox.Name = "returnCheckBox";
            this.returnCheckBox.Size = new System.Drawing.Size(15, 14);
            this.returnCheckBox.TabIndex = 9;
            this.returnCheckBox.UseVisualStyleBackColor = true;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(156, 56);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(375, 20);
            this.itemNameTextBox.TabIndex = 10;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.AcceptsReturn = true;
            this.descriptionTextBox.Location = new System.Drawing.Point(155, 101);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(375, 75);
            this.descriptionTextBox.TabIndex = 11;
            // 
            // categoryDropDown
            // 
            this.categoryDropDown.FormattingEnabled = true;
            this.categoryDropDown.Location = new System.Drawing.Point(156, 190);
            this.categoryDropDown.Name = "categoryDropDown";
            this.categoryDropDown.Size = new System.Drawing.Size(174, 21);
            this.categoryDropDown.TabIndex = 12;
            // 
            // conditionDropDown
            // 
            this.conditionDropDown.FormattingEnabled = true;
            this.conditionDropDown.Location = new System.Drawing.Point(156, 235);
            this.conditionDropDown.Name = "conditionDropDown";
            this.conditionDropDown.Size = new System.Drawing.Size(174, 21);
            this.conditionDropDown.TabIndex = 13;
            // 
            // startBidTextBox
            // 
            this.startBidTextBox.Location = new System.Drawing.Point(216, 278);
            this.startBidTextBox.Name = "startBidTextBox";
            this.startBidTextBox.Size = new System.Drawing.Size(148, 20);
            this.startBidTextBox.TabIndex = 14;
            this.startBidTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.startBidTextBox_KeyPress);
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Location = new System.Drawing.Point(199, 319);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(148, 20);
            this.minPriceTextBox.TabIndex = 15;
            this.minPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minPriceTextBox_KeyPress);
            // 
            // auctionLengthDropdown
            // 
            this.auctionLengthDropdown.FormattingEnabled = true;
            this.auctionLengthDropdown.Location = new System.Drawing.Point(157, 367);
            this.auctionLengthDropdown.Name = "auctionLengthDropdown";
            this.auctionLengthDropdown.Size = new System.Drawing.Size(174, 21);
            this.auctionLengthDropdown.TabIndex = 16;
            // 
            // getItNowTextBox
            // 
            this.getItNowTextBox.Location = new System.Drawing.Point(173, 411);
            this.getItNowTextBox.Name = "getItNowTextBox";
            this.getItNowTextBox.Size = new System.Drawing.Size(148, 20);
            this.getItNowTextBox.TabIndex = 17;
            this.getItNowTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.getItNowTextBox_KeyPress);
            // 
            // optionalLabel
            // 
            this.optionalLabel.AutoSize = true;
            this.optionalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionalLabel.Location = new System.Drawing.Point(340, 413);
            this.optionalLabel.Name = "optionalLabel";
            this.optionalLabel.Size = new System.Drawing.Size(70, 18);
            this.optionalLabel.TabIndex = 18;
            this.optionalLabel.Text = "(optional)";
            // 
            // listItemButton
            // 
            this.listItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listItemButton.Location = new System.Drawing.Point(391, 549);
            this.listItemButton.Name = "listItemButton";
            this.listItemButton.Size = new System.Drawing.Size(156, 34);
            this.listItemButton.TabIndex = 19;
            this.listItemButton.Text = "List My Item";
            this.listItemButton.UseVisualStyleBackColor = true;
            this.listItemButton.Click += new System.EventHandler(this.listItemButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(216, 549);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(156, 34);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.ForeColor = System.Drawing.Color.Maroon;
            this.messageLabel.Location = new System.Drawing.Point(108, 509);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(35, 13);
            this.messageLabel.TabIndex = 21;
            this.messageLabel.Text = "label1";
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 595);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.listItemButton);
            this.Controls.Add(this.optionalLabel);
            this.Controls.Add(this.getItNowTextBox);
            this.Controls.Add(this.auctionLengthDropdown);
            this.Controls.Add(this.minPriceTextBox);
            this.Controls.Add(this.startBidTextBox);
            this.Controls.Add(this.conditionDropDown);
            this.Controls.Add(this.categoryDropDown);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.returnCheckBox);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.getItNowLabel);
            this.Controls.Add(this.auctionLengthLabel);
            this.Controls.Add(this.minPriceLabel);
            this.Controls.Add(this.startBidLabel);
            this.Controls.Add(this.conditionLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Name = "ListItem";
            this.Text = "ListItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Label startBidLabel;
        private System.Windows.Forms.Label minPriceLabel;
        private System.Windows.Forms.Label auctionLengthLabel;
        private System.Windows.Forms.Label getItNowLabel;
        private System.Windows.Forms.Label returnLabel;
        private System.Windows.Forms.CheckBox returnCheckBox;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox categoryDropDown;
        private System.Windows.Forms.ComboBox conditionDropDown;
        private System.Windows.Forms.TextBox startBidTextBox;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.ComboBox auctionLengthDropdown;
        private System.Windows.Forms.TextBox getItNowTextBox;
        private System.Windows.Forms.Label optionalLabel;
        private System.Windows.Forms.Button listItemButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label messageLabel;
    }
}