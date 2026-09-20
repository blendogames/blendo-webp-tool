using System.Diagnostics;

namespace blendo_webp_tool
{
    public partial class Form1 : Form
    {
        const int DEFAULT_FRAMEDURATION = 200;

        public List<FrameInfo> frames;

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            textBox_duration.Text = DEFAULT_FRAMEDURATION.ToString();

            AddLog("Drag in image files, or drag in folder of images.");
        }

        private void EnableButtons(bool value)
        {
            textBox_duration.Enabled = value;
            button1.Enabled = value;
            button_applyduration.Enabled = value;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length <= 0)
                return;

            //if a directory, then grab all files in directory.
            if (files.Length == 1)
            {

            }

            //Alphabetize
            Array.Sort(files);


            int frameDuration = DEFAULT_FRAMEDURATION;
            int.TryParse(textBox_duration.Text, out frameDuration);

            frames = new List<FrameInfo>();
            for (int i = 0; i < files.Length; i++)
            {
                FrameInfo frame = new FrameInfo();
                frame.filename = files[i];
                frame.durationMS = frameDuration;

                frames.Add(frame);
            }



            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < files.Length; i++)
            {
                Panel container = new Panel();
                container.Size = new Size(200, 250);
                container.Margin = new Padding(10);
                container.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pb = new PictureBox();
                pb.Width = 200;
                pb.Height = 200;
                pb.Margin = new Padding(10);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Location = new Point(0, 0);

                using (var stream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                {
                    pb.Image = Image.FromStream(stream);
                }

                //pb.Tag = "bla";

                Label label = new Label();
                label.Text = Path.GetFileName(files[i]);
                label.Font = new Font("Consolas", 9.0f);
                label.Size = new Size(200, 20);
                label.Location = new Point(0, 200);

                TextBox textbox = new TextBox();
                textbox.Text = frameDuration.ToString();
                textbox.Width = 40;
                textbox.Font = new Font("Consolas", 10.0f);
                textbox.Location = new Point(4, 220);
                textbox.Tag = i;
                textbox.Leave += Textbox_Leave;

                container.Controls.Add(pb);
                container.Controls.Add(label);
                container.Controls.Add(textbox);

                flowLayoutPanel1.Controls.Add(container);
            }

            EnableButtons(true);
        }

        private void Textbox_Leave(object? sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)            
                return;

            int imageIndex;
            if (!int.TryParse(textBox.Tag.ToString(), out imageIndex))
                return;

            int duration;
            if (!int.TryParse(textBox.Text, out duration))
                return;

            frames[imageIndex].durationMS = duration;
        }

        void MakeWebp(string[] files)
        {
            //img2webp -loop 2 in0.png -lossy in1.jpg -d 80 in2.tiff -o out.webp

            string argument = "-loop 0 ";

            for (int i = 0; i < files.Length; i++)
            {
                //string justFilename = Path.GetFileName(files[i]);
                argument += $"-d 80 \"{files[i]}\" ";
            }

            argument += "-o output.webp";

            string workingDirectory = Path.GetDirectoryName(files[0]);



            AddLog("Arguments: {0}", argument);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "img2webp.exe";
            startInfo.Arguments = argument;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            Process proc = new Process();

            try
            {
                proc.StartInfo = startInfo;
                proc.Start();

                //while (!proc.StandardOutput.EndOfStream)
                //{
                //    string line = proc.StandardOutput.ReadLine();
                //    AddLog_Invoked("    " + line);
                //}

                while (!proc.StandardError.EndOfStream)
                {
                    //Standard output.
                    string line = proc.StandardError.ReadLine();
                    AddLog_Invoked("    " + line);
                }
            }
            catch (Exception err)
            {
                AddLog_Invoked("------------------------------");
                AddLog_Invoked(string.Format("ERROR: {0}", err));
                AddLog_Invoked("------------------------------");
            }
        }



        private void AddLog_Invoked(string text, params string[] args)
        {
            AddLog(text, args);
        }

        private void AddLog(string text, params string[] args)
        {
            string displaytext = (args.Length > 0) ? string.Format(text, args) : text;
            listBox1.Items.Add(displaytext);

            int nItems = (int)(listBox1.Height / listBox1.ItemHeight);
            listBox1.TopIndex = listBox1.Items.Count - nItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_applyduration_Click(object sender, EventArgs e)
        {

        }
    }

    public class FrameInfo
    {
        public string filename;
        public int durationMS;
    }
}
