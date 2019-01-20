namespace GTBay
{
    partial class Menu
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
            this.itemSearchButton = new System.Windows.Forms.Button();
            this.listItemButton = new System.Windows.Forms.Button();
            this.auctionResultsButton = new System.Windows.Forms.Button();
            this.categoryReportButton = new System.Windows.Forms.Button();
            this.userReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            // 
            // itemSearchButton
            // 
            this.itemSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSearchButton.Location = new System.Drawing.Point(112, 104);
            this.itemSearchButton.Name = "itemSearchButton";
            this.itemSearchButton.Size = new System.Drawing.Size(274, 74);
            this.itemSearchButton.TabIndex = 0;
            this.itemSearchButton.Text = "Search for Items";
            this.itemSearchButton.UseVisualStyleBackColor = true;
            this.itemSearchButton.Click += new System.EventHandler(this.itemSearchButton_Click);
            // 
            // listItemButton
            // 
            this.listItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listItemButton.Location = new System.Drawing.Point(112, 238);
            this.listItemButton.Name = "listItemButton";
            this.listItemButton.Size = new System.Drawing.Size(274, 74);
            this.listItemButton.TabIndex = 1;
            this.listItemButton.Text = "List an Item for Sale";
            this.listItemButton.UseVisualStyleBackColor = true;
            this.listItemButton.Click += new System.EventHandler(this.listItemButton_Click);
            // 
            // auctionResultsButton
            // 
            this.auctionResultsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auctionResultsButton.Location = new System.Drawing.Point(112, 378);
            this.auctionResultsButton.Name = "auctionResultsButton";
            this.auctionResultsButton.Size = new System.Drawing.Size(274, 74);
            this.auctionResultsButton.TabIndex = 2;
            this.auctionResultsButton.Text = "View Auction Results";
            this.auctionResultsButton.UseVisualStyleBackColor = true;
            this.auctionResultsButton.Click += new System.EventHandler(this.auctionResultsButton_Click);
            // 
            // categoryReportButton
            // 
            this.categoryReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryReportButton.Location = new System.Drawing.Point(112, 514);
            this.categoryReportButton.Name = "categoryReportButton";
            this.categoryReportButton.Size = new System.Drawing.Size(274, 74);
            this.categoryReportButton.TabIndex = 3;
            this.categoryReportButton.Text = "View Category Report";
            this.categoryReportButton.UseVisualStyleBackColor = true;
            this.categoryReportButton.Click += new System.EventHandler(this.categoryReportButton_Click);
            // 
            // userReportButton
            // 
            this.userReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userReportButton.Location = new System.Drawing.Point(112, 653);
            this.userReportButton.Name = "userReportButton";
            this.userReportButton.Size = new System.Drawing.Size(274, 74);
            this.userReportButton.TabIndex = 4;
            this.userReportButton.Text = "View User Report";
            this.userReportButton.UseVisualStyleBackColor = true;
            this.userReportButton.Click += new System.EventHandler(this.userReportButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 836);
            this.Controls.Add(this.userReportButton);
            this.Controls.Add(this.categoryReportButton);
            this.Controls.Add(this.auctionResultsButton);
            this.Controls.Add(this.listItemButton);
            this.Controls.Add(this.itemSearchButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button itemSearchButton;
        private System.Windows.Forms.Button listItemButton;
        private System.Windows.Forms.Button auctionResultsButton;
        private System.Windows.Forms.Button categoryReportButton;
        private System.Windows.Forms.Button userReportButton;
    }
}