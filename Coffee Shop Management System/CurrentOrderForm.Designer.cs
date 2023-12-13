namespace Coffee_Shop_Management_System
{
    partial class CurrentOrderForm
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
            this.btnPrepare = new System.Windows.Forms.Button();
            this.tbxOrder = new System.Windows.Forms.RichTextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrepare
            // 
            this.btnPrepare.BackColor = System.Drawing.Color.Cyan;
            this.btnPrepare.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrepare.Location = new System.Drawing.Point(297, 348);
            this.btnPrepare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(181, 72);
            this.btnPrepare.TabIndex = 0;
            this.btnPrepare.Text = "Prepare";
            this.btnPrepare.UseVisualStyleBackColor = false;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // tbxOrder
            // 
            this.tbxOrder.Location = new System.Drawing.Point(12, 12);
            this.tbxOrder.Name = "tbxOrder";
            this.tbxOrder.ReadOnly = true;
            this.tbxOrder.Size = new System.Drawing.Size(743, 274);
            this.tbxOrder.TabIndex = 1;
            this.tbxOrder.Text = "";
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.Cyan;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.Black;
            this.btnOrder.Location = new System.Drawing.Point(46, 348);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(181, 72);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order ";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Cyan;
            this.btnPay.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(556, 348);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(181, 72);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Handle  payment";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // CurrentOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.tbxOrder);
            this.Controls.Add(this.btnPrepare);
            this.Name = "CurrentOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrentOrderForm";
            this.Load += new System.EventHandler(this.CurrentOrderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.RichTextBox tbxOrder;
        public System.Windows.Forms.Button btnOrder;
        public System.Windows.Forms.Button btnPay;
    }
}