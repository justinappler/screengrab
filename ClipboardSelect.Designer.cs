namespace ScreenGrab
{
    partial class ClipboardSelect
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
            this.SuspendLayout();
            // 
            // ClipboardSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 186);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClipboardSelect";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clipboard Select";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ClipboardSelect_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClipboardSelect_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClipboardSelect_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClipboardSelect_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClipboardSelect_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ClipboardSelect_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClipboardSelect_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

    }
}