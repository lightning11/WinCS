namespace TestEventHandler
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenSub = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenSub
            // 
            this.btnOpenSub.Location = new System.Drawing.Point(45, 34);
            this.btnOpenSub.Name = "btnOpenSub";
            this.btnOpenSub.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSub.TabIndex = 0;
            this.btnOpenSub.Text = "OpenSub";
            this.btnOpenSub.UseVisualStyleBackColor = true;
            this.btnOpenSub.Click += new System.EventHandler(this.btnOpenSub_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOpenSub);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSub;
    }
}

