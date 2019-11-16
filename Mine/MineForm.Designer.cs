namespace Mine
{
    partial class MineForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new System.Windows.Forms.Panel();
            this.lblOpenButon = new System.Windows.Forms.Label();
            this.lblOpenedButonCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(103, 103);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(543, 513);
            this.Panel.TabIndex = 2;
            // 
            // lblOpenButon
            // 
            this.lblOpenButon.AutoSize = true;
            this.lblOpenButon.Location = new System.Drawing.Point(121, 42);
            this.lblOpenButon.Name = "lblOpenButon";
            this.lblOpenButon.Size = new System.Drawing.Size(66, 13);
            this.lblOpenButon.TabIndex = 3;
            this.lblOpenButon.Text = "Açılan Alan :";
            // 
            // lblOpenedButonCount
            // 
            this.lblOpenedButonCount.AutoSize = true;
            this.lblOpenedButonCount.Location = new System.Drawing.Point(200, 42);
            this.lblOpenedButonCount.Name = "lblOpenedButonCount";
            this.lblOpenedButonCount.Size = new System.Drawing.Size(13, 13);
            this.lblOpenedButonCount.TabIndex = 4;
            this.lblOpenedButonCount.Text = "0";
            // 
            // MineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 659);
            this.Controls.Add(this.lblOpenedButonCount);
            this.Controls.Add(this.lblOpenButon);
            this.Controls.Add(this.Panel);
            this.Name = "MineForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label lblOpenButon;
        private System.Windows.Forms.Label lblOpenedButonCount;
    }
}

