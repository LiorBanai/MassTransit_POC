namespace MassTransit.Tests
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProducer = new System.Windows.Forms.Button();
            this.btnConsumer = new System.Windows.Forms.Button();
            this.rproducer = new System.Windows.Forms.RichTextBox();
            this.rconsumer = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnProducer
            // 
            this.btnProducer.Location = new System.Drawing.Point(12, 12);
            this.btnProducer.Name = "btnProducer";
            this.btnProducer.Size = new System.Drawing.Size(136, 46);
            this.btnProducer.TabIndex = 0;
            this.btnProducer.Text = "producer";
            this.btnProducer.UseVisualStyleBackColor = true;
            this.btnProducer.Click += new System.EventHandler(this.btnProducer_Click);
            // 
            // btnConsumer
            // 
            this.btnConsumer.Location = new System.Drawing.Point(12, 223);
            this.btnConsumer.Name = "btnConsumer";
            this.btnConsumer.Size = new System.Drawing.Size(136, 46);
            this.btnConsumer.TabIndex = 1;
            this.btnConsumer.Text = "Consumer";
            this.btnConsumer.UseVisualStyleBackColor = true;
            this.btnConsumer.Click += new System.EventHandler(this.btnConsumer_Click);
            // 
            // rproducer
            // 
            this.rproducer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rproducer.Location = new System.Drawing.Point(154, 12);
            this.rproducer.Name = "rproducer";
            this.rproducer.Size = new System.Drawing.Size(583, 201);
            this.rproducer.TabIndex = 2;
            this.rproducer.Text = "";
            // 
            // rconsumer
            // 
            this.rconsumer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rconsumer.Location = new System.Drawing.Point(154, 219);
            this.rconsumer.Name = "rconsumer";
            this.rconsumer.Size = new System.Drawing.Size(583, 201);
            this.rconsumer.TabIndex = 3;
            this.rconsumer.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 424);
            this.Controls.Add(this.rconsumer);
            this.Controls.Add(this.rproducer);
            this.Controls.Add(this.btnConsumer);
            this.Controls.Add(this.btnProducer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnProducer;
        private Button btnConsumer;
        private RichTextBox rproducer;
        private RichTextBox rconsumer;
    }
}