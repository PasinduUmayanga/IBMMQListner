namespace IBMMQL.Main
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMQ1 = new System.Windows.Forms.Label();
            this.lblMQ2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Listner";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Listner);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message queue 01";
            // 
            // lblMQ1
            // 
            this.lblMQ1.AutoSize = true;
            this.lblMQ1.Location = new System.Drawing.Point(263, 189);
            this.lblMQ1.Name = "lblMQ1";
            this.lblMQ1.Size = new System.Drawing.Size(0, 13);
            this.lblMQ1.TabIndex = 2;
            // 
            // lblMQ2
            // 
            this.lblMQ2.AutoSize = true;
            this.lblMQ2.Location = new System.Drawing.Point(263, 217);
            this.lblMQ2.Name = "lblMQ2";
            this.lblMQ2.Size = new System.Drawing.Size(0, 13);
            this.lblMQ2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Message queue 02";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMQ2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMQ1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblMQ1;
        private System.Windows.Forms.Label lblMQ2;
        private System.Windows.Forms.Label label4;
    }
}

