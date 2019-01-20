namespace GTBay
{
    partial class SearchResults
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighBidder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetItNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuctionEnds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backToSearchButton = new System.Windows.Forms.Button();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.CurrentBid,
            this.HighBidder,
            this.GetItNow,
            this.AuctionEnds});
            this.dataGridView1.Location = new System.Drawing.Point(77, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(646, 331);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // CurrentBid
            // 
            this.CurrentBid.HeaderText = "Current Bid";
            this.CurrentBid.Name = "CurrentBid";
            this.CurrentBid.ReadOnly = true;
            // 
            // HighBidder
            // 
            this.HighBidder.HeaderText = "High Bidder";
            this.HighBidder.Name = "HighBidder";
            this.HighBidder.ReadOnly = true;
            // 
            // GetItNow
            // 
            this.GetItNow.HeaderText = "Get It Now Price";
            this.GetItNow.Name = "GetItNow";
            this.GetItNow.ReadOnly = true;
            // 
            // AuctionEnds
            // 
            this.AuctionEnds.HeaderText = "Auction Ends";
            this.AuctionEnds.Name = "AuctionEnds";
            this.AuctionEnds.ReadOnly = true;
            // 
            // backToSearchButton
            // 
            this.backToSearchButton.Location = new System.Drawing.Point(556, 405);
            this.backToSearchButton.Name = "backToSearchButton";
            this.backToSearchButton.Size = new System.Drawing.Size(211, 36);
            this.backToSearchButton.TabIndex = 1;
            this.backToSearchButton.Text = "Back to Search";
            this.backToSearchButton.UseVisualStyleBackColor = true;
            this.backToSearchButton.Click += new System.EventHandler(this.backToSearchButton_Click);
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backToSearchButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchResults";
            this.Text = "SearchResults";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighBidder;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetItNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuctionEnds;
        private System.Windows.Forms.Button backToSearchButton;
    }
}