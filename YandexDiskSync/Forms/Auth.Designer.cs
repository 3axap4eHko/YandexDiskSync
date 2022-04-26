namespace YandexDiskSync.Forms
{
  partial class Auth
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
      this.Authorize = new System.Windows.Forms.Button();
      this.CodeInput = new System.Windows.Forms.TextBox();
      this.CodeLinkLabel = new System.Windows.Forms.LinkLabel();
      this.label1 = new System.Windows.Forms.Label();
      this.errorLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Authorize
      // 
      this.Authorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Authorize.Location = new System.Drawing.Point(95, 178);
      this.Authorize.Margin = new System.Windows.Forms.Padding(6);
      this.Authorize.Name = "Authorize";
      this.Authorize.Size = new System.Drawing.Size(128, 48);
      this.Authorize.TabIndex = 0;
      this.Authorize.Text = "Authorize";
      this.Authorize.UseVisualStyleBackColor = true;
      this.Authorize.Click += new System.EventHandler(this.Authorize_Click);
      // 
      // CodeInput
      // 
      this.CodeInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CodeInput.Location = new System.Drawing.Point(209, 71);
      this.CodeInput.Name = "CodeInput";
      this.CodeInput.Size = new System.Drawing.Size(113, 29);
      this.CodeInput.TabIndex = 1;
      // 
      // CodeLinkLabel
      // 
      this.CodeLinkLabel.AutoSize = true;
      this.CodeLinkLabel.Location = new System.Drawing.Point(12, 74);
      this.CodeLinkLabel.Name = "CodeLinkLabel";
      this.CodeLinkLabel.Size = new System.Drawing.Size(160, 24);
      this.CodeLinkLabel.TabIndex = 2;
      this.CodeLinkLabel.TabStop = true;
      this.CodeLinkLabel.Text = "Click to get CODE";
      this.CodeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CodeLinkLabel_LinkClicked);
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
      this.label1.TabIndex = 8;
      this.label1.Text = "Yandex.Disk.Sync";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // errorLabel
      // 
      this.errorLabel.ForeColor = System.Drawing.Color.Red;
      this.errorLabel.Location = new System.Drawing.Point(12, 117);
      this.errorLabel.Name = "errorLabel";
      this.errorLabel.Size = new System.Drawing.Size(310, 55);
      this.errorLabel.TabIndex = 9;
      this.errorLabel.Text = "Error";
      this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.errorLabel.Visible = false;
      // 
      // Auth
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(334, 241);
      this.Controls.Add(this.errorLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CodeLinkLabel);
      this.Controls.Add(this.CodeInput);
      this.Controls.Add(this.Authorize);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Auth";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Yandex.Disk.Sync Authorization";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Authorize;
    private System.Windows.Forms.TextBox CodeInput;
    private System.Windows.Forms.LinkLabel CodeLinkLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label errorLabel;
  }
}