﻿namespace LoginForm
{
    partial class Form1
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
            this.ucLogin = new LoginControl.Login();
            this.SuspendLayout();
            // 
            // ucLogin
            // 
            this.ucLogin.Location = new System.Drawing.Point(26, 12);
            this.ucLogin.Name = "ucLogin";
            this.ucLogin.Size = new System.Drawing.Size(323, 212);
            this.ucLogin.TabIndex = 0;
            this.ucLogin.LoginOK += new LoginControl.LoginOKEventHandler(this.ucLogin_LoginOK);
            this.ucLogin.LoginNG += new System.EventHandler(this.ucLogin_LoginNG);
            this.ucLogin.LoginCancel += new System.EventHandler(this.ucLogin_LoginCancel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 317);
            this.Controls.Add(this.ucLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl.Login ucLogin;
    }
}

