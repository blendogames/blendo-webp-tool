using System.Diagnostics;

namespace blendo_webp_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
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

            MakeWebp(files);
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
    }
}
