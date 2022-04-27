namespace YandexDiskSync.Forms
{
  partial class Options
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
      this.limitHistory = new System.Windows.Forms.CheckBox();
      this.limitHistorySize = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.openSync = new System.Windows.Forms.CheckBox();
      this.saveSync = new System.Windows.Forms.CheckBox();
      this.closeSync = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.limitHistorySize)).BeginInit();
      this.SuspendLayout();
      // 
      // limitHistory
      // 
      this.limitHistory.AutoSize = true;
      this.limitHistory.Location = new System.Drawing.Point(15, 56);
      this.limitHistory.Margin = new System.Windows.Forms.Padding(6);
      this.limitHistory.Name = "limitHistory";
      this.limitHistory.Size = new System.Drawing.Size(146, 28);
      this.limitHistory.TabIndex = 5;
      this.limitHistory.Text = "Limit history to";
      this.limitHistory.UseVisualStyleBackColor = true;
      // 
      // limitHistorySize
      // 
      this.limitHistorySize.Enabled = false;
      this.limitHistorySize.Location = new System.Drawing.Point(202, 55);
      this.limitHistorySize.Margin = new System.Windows.Forms.Padding(6);
      this.limitHistorySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.limitHistorySize.Name = "limitHistorySize";
      this.limitHistorySize.Size = new System.Drawing.Size(117, 29);
      this.limitHistorySize.TabIndex = 6;
      this.limitHistorySize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Red;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
      this.label1.Size = new System.Drawing.Size(334, 50);
      this.label1.TabIndex = 7;
      this.label1.Text = "Yandex.Disk.Sync";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // openSync
      // 
      this.openSync.AutoSize = true;
      this.openSync.Location = new System.Drawing.Point(12, 119);
      this.openSync.Name = "openSync";
      this.openSync.Size = new System.Drawing.Size(151, 28);
      this.openSync.TabIndex = 8;
      this.openSync.Text = "Sync on Open";
      this.openSync.UseVisualStyleBackColor = true;
      // 
      // saveSync
      // 
      this.saveSync.AutoSize = true;
      this.saveSync.Location = new System.Drawing.Point(12, 153);
      this.saveSync.Name = "saveSync";
      this.saveSync.Size = new System.Drawing.Size(145, 28);
      this.saveSync.TabIndex = 9;
      this.saveSync.Text = "Sync on Save";
      this.saveSync.UseVisualStyleBackColor = true;
      // 
      // closeSync
      // 
      this.closeSync.AutoSize = true;
      this.closeSync.Location = new System.Drawing.Point(12, 187);
      this.closeSync.Name = "closeSync";
      this.closeSync.Size = new System.Drawing.Size(151, 28);
      this.closeSync.TabIndex = 10;
      this.closeSync.Text = "Sync on Close";
      this.closeSync.UseVisualStyleBackColor = true;
      // 
      // Options
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(334, 221);
      this.Controls.Add(this.closeSync);
      this.Controls.Add(this.saveSync);
      this.Controls.Add(this.openSync);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.limitHistorySize);
      this.Controls.Add(this.limitHistory);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Options";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Yandex.Disk.Sync Options";
      this.Load += new System.EventHandler(this.Options_Load);
      ((System.ComponentModel.ISupportInitialize)(this.limitHistorySize)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.CheckBox limitHistory;
    private System.Windows.Forms.NumericUpDown limitHistorySize;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox openSync;
    private System.Windows.Forms.CheckBox saveSync;
    private System.Windows.Forms.CheckBox closeSync;
  }
}