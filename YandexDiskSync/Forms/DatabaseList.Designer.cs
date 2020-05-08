namespace YandexDiskSync
{
  partial class DatabaseList
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseList));
      this.label1 = new System.Windows.Forms.Label();
      this.datebaseList = new System.Windows.Forms.ListView();
      this.database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.versionList = new System.Windows.Forms.ListView();
      this.databaseUploaded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.databaseSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.download = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Red;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
      this.label1.Size = new System.Drawing.Size(566, 50);
      this.label1.TabIndex = 8;
      this.label1.Text = "Yandex.Disk.Sync";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // datebaseList
      // 
      this.datebaseList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.database});
      this.datebaseList.HideSelection = false;
      this.datebaseList.Location = new System.Drawing.Point(4, 53);
      this.datebaseList.Name = "datebaseList";
      this.datebaseList.Size = new System.Drawing.Size(231, 328);
      this.datebaseList.TabIndex = 9;
      this.datebaseList.UseCompatibleStateImageBehavior = false;
      this.datebaseList.View = System.Windows.Forms.View.Details;
      this.datebaseList.SelectedIndexChanged += new System.EventHandler(this.datebaseList_SelectedIndexChanged);
      // 
      // database
      // 
      this.database.Text = "Database";
      this.database.Width = 202;
      // 
      // versionList
      // 
      this.versionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.databaseUploaded,
            this.databaseSize});
      this.versionList.Enabled = false;
      this.versionList.HideSelection = false;
      this.versionList.Location = new System.Drawing.Point(241, 53);
      this.versionList.Name = "versionList";
      this.versionList.Size = new System.Drawing.Size(325, 328);
      this.versionList.TabIndex = 10;
      this.versionList.UseCompatibleStateImageBehavior = false;
      this.versionList.View = System.Windows.Forms.View.Details;
      this.versionList.SelectedIndexChanged += new System.EventHandler(this.versionList_SelectedIndexChanged);
      // 
      // databaseUploaded
      // 
      this.databaseUploaded.Text = "Time";
      this.databaseUploaded.Width = 190;
      // 
      // databaseSize
      // 
      this.databaseSize.Text = "Size";
      this.databaseSize.Width = 108;
      // 
      // download
      // 
      this.download.Enabled = false;
      this.download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.download.Location = new System.Drawing.Point(438, 386);
      this.download.Margin = new System.Windows.Forms.Padding(6);
      this.download.Name = "download";
      this.download.Size = new System.Drawing.Size(128, 48);
      this.download.TabIndex = 11;
      this.download.Text = "Download";
      this.download.UseVisualStyleBackColor = true;
      this.download.Click += new System.EventHandler(this.download_Click);
      // 
      // DatabaseList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(570, 439);
      this.Controls.Add(this.download);
      this.Controls.Add(this.versionList);
      this.Controls.Add(this.datebaseList);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DatabaseList";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Yandex.Disk.Sync DatabaseList";
      this.Load += new System.EventHandler(this.DatabaseList_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView datebaseList;
    private System.Windows.Forms.ColumnHeader database;
    private System.Windows.Forms.ListView versionList;
    private System.Windows.Forms.ColumnHeader databaseUploaded;
    private System.Windows.Forms.ColumnHeader databaseSize;
    private System.Windows.Forms.Button download;
  }
}