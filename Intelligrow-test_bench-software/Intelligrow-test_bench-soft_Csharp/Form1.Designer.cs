namespace Intelligrow_test_bench_soft_Csharp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.MCP2210_connect_btn = new System.Windows.Forms.Button();
            this.MCP2210_disconnect_btn = new System.Windows.Forms.Button();
            this.DUT_enable_btn = new System.Windows.Forms.Button();
            this.DUT_disable_btn = new System.Windows.Forms.Button();
            this.ADC0_txtbox = new System.Windows.Forms.TextBox();
            this.ADC1_txtbox = new System.Windows.Forms.TextBox();
            this.ADC3_txtbox = new System.Windows.Forms.TextBox();
            this.ADC2_txtbox = new System.Windows.Forms.TextBox();
            this.ADC7_txtbox = new System.Windows.Forms.TextBox();
            this.ADC6_txtbox = new System.Windows.Forms.TextBox();
            this.ADC5_txtbox = new System.Windows.Forms.TextBox();
            this.ADC4_txtbox = new System.Windows.Forms.TextBox();
            this.ADC0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ADC_timer = new System.Windows.Forms.Timer(this.components);
            this.Main_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MCP2210_connect_btn
            // 
            this.MCP2210_connect_btn.Location = new System.Drawing.Point(337, 12);
            this.MCP2210_connect_btn.Name = "MCP2210_connect_btn";
            this.MCP2210_connect_btn.Size = new System.Drawing.Size(147, 23);
            this.MCP2210_connect_btn.TabIndex = 0;
            this.MCP2210_connect_btn.Text = "MCP2210 Connect";
            this.MCP2210_connect_btn.UseVisualStyleBackColor = true;
            this.MCP2210_connect_btn.Click += new System.EventHandler(this.MCP2210_connect_btn_Click);
            // 
            // MCP2210_disconnect_btn
            // 
            this.MCP2210_disconnect_btn.Location = new System.Drawing.Point(337, 58);
            this.MCP2210_disconnect_btn.Name = "MCP2210_disconnect_btn";
            this.MCP2210_disconnect_btn.Size = new System.Drawing.Size(147, 23);
            this.MCP2210_disconnect_btn.TabIndex = 1;
            this.MCP2210_disconnect_btn.Text = "MCP2210 Disconnect";
            this.MCP2210_disconnect_btn.UseVisualStyleBackColor = true;
            this.MCP2210_disconnect_btn.Click += new System.EventHandler(this.MCP2210_disconnect_btn_Click);
            // 
            // DUT_enable_btn
            // 
            this.DUT_enable_btn.Location = new System.Drawing.Point(87, 58);
            this.DUT_enable_btn.Name = "DUT_enable_btn";
            this.DUT_enable_btn.Size = new System.Drawing.Size(147, 23);
            this.DUT_enable_btn.TabIndex = 2;
            this.DUT_enable_btn.Text = "Enable DUT";
            this.DUT_enable_btn.UseVisualStyleBackColor = true;
            this.DUT_enable_btn.Click += new System.EventHandler(this.DUT_enable_btn_Click);
            // 
            // DUT_disable_btn
            // 
            this.DUT_disable_btn.Location = new System.Drawing.Point(87, 87);
            this.DUT_disable_btn.Name = "DUT_disable_btn";
            this.DUT_disable_btn.Size = new System.Drawing.Size(147, 23);
            this.DUT_disable_btn.TabIndex = 3;
            this.DUT_disable_btn.Text = "Disable DUT";
            this.DUT_disable_btn.UseVisualStyleBackColor = true;
            this.DUT_disable_btn.Click += new System.EventHandler(this.DUT_disable_btn_Click);
            // 
            // ADC0_txtbox
            // 
            this.ADC0_txtbox.Location = new System.Drawing.Point(619, 89);
            this.ADC0_txtbox.Name = "ADC0_txtbox";
            this.ADC0_txtbox.ReadOnly = true;
            this.ADC0_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC0_txtbox.TabIndex = 4;
            // 
            // ADC1_txtbox
            // 
            this.ADC1_txtbox.Location = new System.Drawing.Point(619, 124);
            this.ADC1_txtbox.Name = "ADC1_txtbox";
            this.ADC1_txtbox.ReadOnly = true;
            this.ADC1_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC1_txtbox.TabIndex = 5;
            // 
            // ADC3_txtbox
            // 
            this.ADC3_txtbox.Location = new System.Drawing.Point(619, 195);
            this.ADC3_txtbox.Name = "ADC3_txtbox";
            this.ADC3_txtbox.ReadOnly = true;
            this.ADC3_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC3_txtbox.TabIndex = 7;
            // 
            // ADC2_txtbox
            // 
            this.ADC2_txtbox.Location = new System.Drawing.Point(619, 160);
            this.ADC2_txtbox.Name = "ADC2_txtbox";
            this.ADC2_txtbox.ReadOnly = true;
            this.ADC2_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC2_txtbox.TabIndex = 6;
            // 
            // ADC7_txtbox
            // 
            this.ADC7_txtbox.Location = new System.Drawing.Point(619, 337);
            this.ADC7_txtbox.Name = "ADC7_txtbox";
            this.ADC7_txtbox.ReadOnly = true;
            this.ADC7_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC7_txtbox.TabIndex = 11;
            // 
            // ADC6_txtbox
            // 
            this.ADC6_txtbox.Location = new System.Drawing.Point(619, 302);
            this.ADC6_txtbox.Name = "ADC6_txtbox";
            this.ADC6_txtbox.ReadOnly = true;
            this.ADC6_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC6_txtbox.TabIndex = 10;
            // 
            // ADC5_txtbox
            // 
            this.ADC5_txtbox.Location = new System.Drawing.Point(619, 266);
            this.ADC5_txtbox.Name = "ADC5_txtbox";
            this.ADC5_txtbox.ReadOnly = true;
            this.ADC5_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC5_txtbox.TabIndex = 9;
            // 
            // ADC4_txtbox
            // 
            this.ADC4_txtbox.Location = new System.Drawing.Point(619, 231);
            this.ADC4_txtbox.Name = "ADC4_txtbox";
            this.ADC4_txtbox.ReadOnly = true;
            this.ADC4_txtbox.Size = new System.Drawing.Size(100, 20);
            this.ADC4_txtbox.TabIndex = 8;
            // 
            // ADC0
            // 
            this.ADC0.AutoSize = true;
            this.ADC0.Location = new System.Drawing.Point(725, 92);
            this.ADC0.Name = "ADC0";
            this.ADC0.Size = new System.Drawing.Size(35, 13);
            this.ADC0.TabIndex = 12;
            this.ADC0.Text = "ADC0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(725, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ADC1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(725, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "ADC3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(725, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "ADC2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(725, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "ADC7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(725, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "ADC6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(725, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "ADC5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(725, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "ADC4";
            // 
            // ADC_timer
            // 
            this.ADC_timer.Interval = 10;
            this.ADC_timer.Tick += new System.EventHandler(this.ADC_timer_Tick);
            // 
            // Main_timer
            // 
            this.Main_timer.Enabled = true;
            this.Main_timer.Interval = 1;
            this.Main_timer.Tick += new System.EventHandler(this.Main_timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ADC0);
            this.Controls.Add(this.ADC7_txtbox);
            this.Controls.Add(this.ADC6_txtbox);
            this.Controls.Add(this.ADC5_txtbox);
            this.Controls.Add(this.ADC4_txtbox);
            this.Controls.Add(this.ADC3_txtbox);
            this.Controls.Add(this.ADC2_txtbox);
            this.Controls.Add(this.ADC1_txtbox);
            this.Controls.Add(this.ADC0_txtbox);
            this.Controls.Add(this.DUT_disable_btn);
            this.Controls.Add(this.DUT_enable_btn);
            this.Controls.Add(this.MCP2210_disconnect_btn);
            this.Controls.Add(this.MCP2210_connect_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MCP2210_connect_btn;
        private System.Windows.Forms.Button MCP2210_disconnect_btn;
        private System.Windows.Forms.Button DUT_enable_btn;
        private System.Windows.Forms.Button DUT_disable_btn;
        private System.Windows.Forms.TextBox ADC0_txtbox;
        private System.Windows.Forms.TextBox ADC1_txtbox;
        private System.Windows.Forms.TextBox ADC3_txtbox;
        private System.Windows.Forms.TextBox ADC2_txtbox;
        private System.Windows.Forms.TextBox ADC7_txtbox;
        private System.Windows.Forms.TextBox ADC6_txtbox;
        private System.Windows.Forms.TextBox ADC5_txtbox;
        private System.Windows.Forms.TextBox ADC4_txtbox;
        private System.Windows.Forms.Label ADC0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer ADC_timer;
        private System.Windows.Forms.Timer Main_timer;
    }
}

