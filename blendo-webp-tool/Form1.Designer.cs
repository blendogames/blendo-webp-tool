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
            components = new System.ComponentModel.Container();
            listBox1 = new ListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            label_duration = new Label();
            textBox_duration = new TextBox();
            button_applyduration = new Button();
            button_openfolder = new Button();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            textBox_quality = new TextBox();
            radioButton_lossy = new RadioButton();
            radioButton_mixed = new RadioButton();
            radioButton_lossless = new RadioButton();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(954, 94);
            listBox1.TabIndex = 0;
            listBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(954, 377);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(746, 9);
            button1.Name = "button1";
            button1.Size = new Size(226, 48);
            button1.TabIndex = 7;
            button1.TabStop = false;
            button1.Text = "Make Webp";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label_duration
            // 
            label_duration.AutoSize = true;
            label_duration.Enabled = false;
            label_duration.Location = new Point(12, 9);
            label_duration.Name = "label_duration";
            label_duration.Size = new Size(168, 15);
            label_duration.TabIndex = 3;
            label_duration.Text = "Frame duration (milliseconds):";
            toolTip1.SetToolTip(label_duration, "1000 = 1 second");
            // 
            // textBox_duration
            // 
            textBox_duration.Enabled = false;
            textBox_duration.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_duration.Location = new Point(12, 27);
            textBox_duration.Name = "textBox_duration";
            textBox_duration.Size = new Size(53, 26);
            textBox_duration.TabIndex = 0;
            textBox_duration.TabStop = false;
            toolTip1.SetToolTip(textBox_duration, "1000 = 1 second");
            // 
            // button_applyduration
            // 
            button_applyduration.Enabled = false;
            button_applyduration.Location = new Point(71, 27);
            button_applyduration.Name = "button_applyduration";
            button_applyduration.Size = new Size(123, 26);
            button_applyduration.TabIndex = 1;
            button_applyduration.TabStop = false;
            button_applyduration.Text = "Apply to all frames";
            button_applyduration.UseVisualStyleBackColor = true;
            button_applyduration.Click += button_applyduration_Click;
            // 
            // button_openfolder
            // 
            button_openfolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_openfolder.Enabled = false;
            button_openfolder.Location = new Point(653, 9);
            button_openfolder.Name = "button_openfolder";
            button_openfolder.Size = new Size(87, 48);
            button_openfolder.TabIndex = 6;
            button_openfolder.TabStop = false;
            button_openfolder.Text = "Open output folder";
            button_openfolder.UseVisualStyleBackColor = true;
            button_openfolder.Click += button_openfolder_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 60);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listBox1);
            splitContainer1.Size = new Size(960, 489);
            splitContainer1.SplitterDistance = 383;
            splitContainer1.TabIndex = 7;
            splitContainer1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox_quality);
            groupBox1.Controls.Add(radioButton_lossy);
            groupBox1.Controls.Add(radioButton_mixed);
            groupBox1.Controls.Add(radioButton_lossless);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(211, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 54);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quality";
            // 
            // textBox_quality
            // 
            textBox_quality.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_quality.Location = new Point(372, 21);
            textBox_quality.Name = "textBox_quality";
            textBox_quality.Size = new Size(42, 23);
            textBox_quality.TabIndex = 5;
            textBox_quality.TabStop = false;
            textBox_quality.Text = "75";
            // 
            // radioButton_lossy
            // 
            radioButton_lossy.AutoSize = true;
            radioButton_lossy.Location = new Point(251, 22);
            radioButton_lossy.Name = "radioButton_lossy";
            radioButton_lossy.Size = new Size(123, 19);
            radioButton_lossy.TabIndex = 4;
            radioButton_lossy.Text = "Set quality (0-100):";
            radioButton_lossy.UseVisualStyleBackColor = true;
            // 
            // radioButton_mixed
            // 
            radioButton_mixed.AutoSize = true;
            radioButton_mixed.Location = new Point(105, 22);
            radioButton_mixed.Name = "radioButton_mixed";
            radioButton_mixed.Size = new Size(123, 19);
            radioButton_mixed.TabIndex = 3;
            radioButton_mixed.Text = "Mixed (automatic)";
            radioButton_mixed.UseVisualStyleBackColor = true;
            // 
            // radioButton_lossless
            // 
            radioButton_lossless.AutoSize = true;
            radioButton_lossless.Checked = true;
            radioButton_lossless.Location = new Point(11, 22);
            radioButton_lossless.Name = "radioButton_lossless";
            radioButton_lossless.Size = new Size(67, 19);
            radioButton_lossless.TabIndex = 2;
            radioButton_lossless.TabStop = true;
            radioButton_lossless.Text = "Lossless";
            radioButton_lossless.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(groupBox1);
            Controls.Add(splitContainer1);
            Controls.Add(button_openfolder);
            Controls.Add(button_applyduration);
            Controls.Add(textBox_duration);
            Controls.Add(label_duration);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "blendo webp tool";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Label label_duration;
        private TextBox textBox_duration;
        private Button button_applyduration;
        private Button button_openfolder;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private RadioButton radioButton_lossless;
        private RadioButton radioButton_mixed;
        private TextBox textBox_quality;
        private RadioButton radioButton_lossy;
        private ToolTip toolTip1;
    }
}
