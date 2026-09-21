namespace blendo_webp_tool
{
    partial class Form1
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
            listBox1 = new ListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            label1 = new Label();
            textBox_duration = new TextBox();
            button_applyduration = new Button();
            button_openfolder = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 485);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(960, 64);
            listBox1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(12, 60);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(960, 419);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(851, 3);
            button1.Name = "button1";
            button1.Size = new Size(121, 51);
            button1.TabIndex = 2;
            button1.Text = "Make Webp";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(168, 15);
            label1.TabIndex = 3;
            label1.Text = "Frame duration (milliseconds):";
            // 
            // textBox_duration
            // 
            textBox_duration.Enabled = false;
            textBox_duration.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_duration.Location = new Point(12, 27);
            textBox_duration.Name = "textBox_duration";
            textBox_duration.Size = new Size(53, 23);
            textBox_duration.TabIndex = 4;
            // 
            // button_applyduration
            // 
            button_applyduration.Enabled = false;
            button_applyduration.Location = new Point(71, 26);
            button_applyduration.Name = "button_applyduration";
            button_applyduration.Size = new Size(123, 24);
            button_applyduration.TabIndex = 5;
            button_applyduration.Text = "Apply to all frames";
            button_applyduration.UseVisualStyleBackColor = true;
            button_applyduration.Click += button_applyduration_Click;
            // 
            // button_openfolder
            // 
            button_openfolder.Enabled = false;
            button_openfolder.Location = new Point(758, 3);
            button_openfolder.Name = "button_openfolder";
            button_openfolder.Size = new Size(87, 51);
            button_openfolder.TabIndex = 6;
            button_openfolder.Text = "Open output folder";
            button_openfolder.UseVisualStyleBackColor = true;
            button_openfolder.Click += button_openfolder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(button_openfolder);
            Controls.Add(button_applyduration);
            Controls.Add(textBox_duration);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(listBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "blendo webp tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Label label1;
        private TextBox textBox_duration;
        private Button button_applyduration;
        private Button button_openfolder;
    }
}
