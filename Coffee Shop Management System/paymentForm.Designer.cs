namespace Coffee_Shop_Management_System
{
    partial class paymentForm
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbContact = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxContact = new System.Windows.Forms.TextBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tbxFeedback = new System.Windows.Forms.RichTextBox();
            this.lbFeedback = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rbnTransfer = new System.Windows.Forms.RadioButton();
            this.rbnCast = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(46, 49);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 16);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // lbContact
            // 
            this.lbContact.AutoSize = true;
            this.lbContact.Location = new System.Drawing.Point(46, 112);
            this.lbContact.Name = "lbContact";
            this.lbContact.Size = new System.Drawing.Size(52, 16);
            this.lbContact.TabIndex = 1;
            this.lbContact.Text = "Contact";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(129, 49);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(283, 22);
            this.tbxName.TabIndex = 2;
            // 
            // tbxContact
            // 
            this.tbxContact.Location = new System.Drawing.Point(129, 112);
            this.tbxContact.Name = "tbxContact";
            this.tbxContact.Size = new System.Drawing.Size(283, 22);
            this.tbxContact.TabIndex = 3;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoney.Location = new System.Drawing.Point(612, 49);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(46, 20);
            this.lbMoney.TabIndex = 4;
            this.lbMoney.Text = "Total";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmount.ForeColor = System.Drawing.Color.Red;
            this.lbAmount.Location = new System.Drawing.Point(612, 83);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(14, 16);
            this.lbAmount.TabIndex = 5;
            this.lbAmount.Text = "0";
            // 
            // tbxFeedback
            // 
            this.tbxFeedback.Location = new System.Drawing.Point(12, 240);
            this.tbxFeedback.Name = "tbxFeedback";
            this.tbxFeedback.Size = new System.Drawing.Size(776, 198);
            this.tbxFeedback.TabIndex = 6;
            this.tbxFeedback.Text = "";
            // 
            // lbFeedback
            // 
            this.lbFeedback.AutoSize = true;
            this.lbFeedback.Location = new System.Drawing.Point(13, 204);
            this.lbFeedback.Name = "lbFeedback";
            this.lbFeedback.Size = new System.Drawing.Size(69, 16);
            this.lbFeedback.TabIndex = 7;
            this.lbFeedback.Text = "Feedback";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(552, 177);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(201, 43);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rbnTransfer
            // 
            this.rbnTransfer.AutoSize = true;
            this.rbnTransfer.Location = new System.Drawing.Point(129, 159);
            this.rbnTransfer.Name = "rbnTransfer";
            this.rbnTransfer.Size = new System.Drawing.Size(112, 20);
            this.rbnTransfer.TabIndex = 9;
            this.rbnTransfer.TabStop = true;
            this.rbnTransfer.Text = "Bank Transfer";
            this.rbnTransfer.UseVisualStyleBackColor = true;
            this.rbnTransfer.CheckedChanged += new System.EventHandler(this.rbnTransfer_CheckedChanged);
            // 
            // rbnCast
            // 
            this.rbnCast.AutoSize = true;
            this.rbnCast.Location = new System.Drawing.Point(305, 159);
            this.rbnCast.Name = "rbnCast";
            this.rbnCast.Size = new System.Drawing.Size(59, 20);
            this.rbnCast.TabIndex = 10;
            this.rbnCast.TabStop = true;
            this.rbnCast.Text = "Cash";
            this.rbnCast.UseVisualStyleBackColor = true;
            // 
            // paymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.rbnCast);
            this.Controls.Add(this.rbnTransfer);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbFeedback);
            this.Controls.Add(this.tbxFeedback);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.tbxContact);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lbContact);
            this.Controls.Add(this.lbName);
            this.Name = "paymentForm";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.paymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbContact;
        private System.Windows.Forms.Label lbMoney;
        public System.Windows.Forms.Label lbAmount;
        public System.Windows.Forms.RichTextBox tbxFeedback;
        private System.Windows.Forms.Label lbFeedback;
        private System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.TextBox tbxName;
        public System.Windows.Forms.TextBox tbxContact;
        public System.Windows.Forms.RadioButton rbnTransfer;
        public System.Windows.Forms.RadioButton rbnCast;
    }
}