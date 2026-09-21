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
            button_openfolder.Enabled = value;
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
                FileAttributes attr = File.GetAttributes(files[0]);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    files = Directory.GetFiles(files[0]);
                }
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
                    try
                    {
                        pb.Image = Image.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        AddLog("ERROR: failed to parse image: {0}", files[i]);
                        AddLog(ex.Message);
                    }
                }

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
                frames[i].textbox = textbox;

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

        void MakeWebp()
        {
            AddLog("------------------------- {0} -------------------------", DateTime.Now.ToShortTimeString());

            //Generate output file name
            string outputDir = Path.GetDirectoryName(frames[0].filename);
            string outputFilename = string.Format("output_{0}_{1}_{2}_{3}-{4}-{5}.webp", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string outputPath = Path.Combine(outputDir, outputFilename);


            string argument = "-loop 0 ";

            for (int i = 0; i < frames.Count; i++)
            {
                int duration = frames[i].durationMS;

                //string justFilename = Path.GetFileName(files[i]);
                argument += $"-d {duration} \"{frames[i].filename}\" ";
            }

            argument += $"-o \"{outputPath}\"";

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
                return;
            }

            AddLog(string.Empty);
            AddLog("Wrote file:");
            AddLog(outputPath);
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
            //Click the GO button
            MakeWebp();
        }

        private void button_applyduration_Click(object sender, EventArgs e)
        {
            int newDuration;
            if (int.TryParse(textBox_duration.Text, out newDuration))
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    frames[i].textbox.Text = newDuration.ToString();
                }

                return;
            }

            AddLog("ERROR: failed to parse duration: {0}", textBox_duration.Text);
        }

        private void button_openfolder_Click(object sender, EventArgs e)
        {
            if (frames == null)
                return;

            if (frames.Count <= 0)
                return;

            string dirName = Path.GetDirectoryName(frames[0].filename);

            if (!Directory.Exists(dirName))
            {
                AddLog("ERROR: directory doesn't exist: {0}", dirName);
                return;
            }


            DirectoryInfo dir = new DirectoryInfo(dirName);

            FileInfo newestCreated = dir.GetFiles("*.webp")
                              .OrderByDescending(f => f.LastWriteTime)
                              .FirstOrDefault();

            string filePath = Path.Combine(dirName, newestCreated.Name);

            string arguments = $"/select,\"{filePath}\"";

            Process.Start("explorer.exe", arguments);            
        }
    }

    public class FrameInfo
    {
        public string filename;
        public int durationMS;
        public TextBox textbox;
    }
}
