using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WinBinFex
{
    public partial class Form1 : Form
    {
        /******************************************************************************/
        // Objects, Types, Constants, Variables

        Thread oThread;

        enum fileType { BIN, FEX, OTHER };

        fileType file_type;
        string exit_path;

        /******************************************************************************/
        // Form creation

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();

            exit_path = "";
            file_type = fileType.OTHER;
            label_status.ForeColor = System.Drawing.Color.Black;
            label_status.Text = "Status: Please, insert a BIN or FEX file";
        }

        /******************************************************************************/
        // Elements events

        private void button_fileExplorer_OnClick(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select a BIN or FEX file";
            openFileDialog.Filter = "All Files|*.*|BIN File|*.bin|FEX File|*.fex";
            openFileDialog.FileName = Path.GetFileName(textBox_file_path.Text);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button_explorer.Enabled = false;
                textBox_file_path.Text = openFileDialog.FileName;
            }
            button_explorer.Enabled = true;
        }

        private void button_convert_OnClick(object sender, EventArgs e)
        {
            string inputFile = textBox_file_path.Text;

            if (String.IsNullOrEmpty(inputFile))
            {
                label_status.ForeColor = System.Drawing.Color.Red;
                label_status.Text = "Status: The file path is empty";
            }
            else if (!File.Exists(inputFile))
            {
                label_status.ForeColor = System.Drawing.Color.Red;
                label_status.Text = "Status: The file does not exist";
            }
            else if (!is_BINFEX_file(inputFile))
            {
                label_status.ForeColor = System.Drawing.Color.Red;
                label_status.Text = "Status: Not a valid BIN or FEX file";
            }
            else
            {
                button_convert.Enabled = false;
                label_status.ForeColor = System.Drawing.Color.Black;
                label_status.Text = "Status: Converting...";

                oThread = new Thread(new ThreadStart(process));
                oThread.SetApartmentState(ApartmentState.STA);
                oThread.IsBackground = true;
                oThread.Start();
            }
        }

        /******************************************************************************/
        // Convertion Process (Thread)

        [STAThread] private void process()
        {
            string filePath = "";
            string exportPath = "";

            filePath = "\"" + textBox_file_path.Text + "\"";

            if (file_type == fileType.BIN)
            {
                saveFileDialog.Title = "Save location for generated FEX";
                saveFileDialog.Filter = "FEX File|*.fex";
                saveFileDialog.FileName = "script.fex";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    exit_path = saveFileDialog.FileName;
                    exportPath = "\"" + exit_path + "\"";
                }

                systemCall("bin\\fexc -I bin -O fex " + filePath + " " + exportPath);
            }
            else if (file_type == fileType.FEX)
            {
                saveFileDialog.Title = "Save location for generated BIN";
                saveFileDialog.Filter = "BIN File|*.bin";
                saveFileDialog.FileName = "script.bin";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    exit_path = saveFileDialog.FileName;
                    exportPath = "\"" + exit_path + "\"";
                }

                systemCall("bin\\fexc -I fex -O bin " + filePath + " " + exportPath);
            }
        }

        /******************************************************************************/
        // Functions

        private void systemCall(string cmd)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + cmd;
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    label_status.Invoke((Action)(() =>
                    {
                        MessageBox.Show("The file cannot be converted.\n\nError:\n\n" + error);
                        label_status.ForeColor = System.Drawing.Color.Red;
                        label_status.Text = "Status: Error, the file cannot be converted (malformed file)";
                    }));
                }
                else
                {
                    label_status.Invoke((Action)(() =>
                    {
                        label_status.ForeColor = System.Drawing.Color.ForestGreen;
                        label_status.Text = "Status: Success";
                    }));

                    Process.Start(Path.GetDirectoryName(exit_path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file cannot be converted.\n\nError:\n\n" + ex.ToString());
            }

            button_convert.Invoke((Action)(() =>
            {
                button_convert.Enabled = true;
            }));
        }
        
        private bool is_BIN_file(string file)
        {
            char[] extension = new char[4];

            extension[0] = file[file.Length - 4];
            extension[1] = file[file.Length - 3];
            extension[2] = file[file.Length - 2];
            extension[3] = file[file.Length - 1];

            if ((extension[0] == '.') && (extension[1] == 'b' || extension[1] == 'B') && (extension[2] == 'i' || extension[2] == 'I') && (extension[3] == 'n' || extension[3] == 'N'))
            {
                file_type = fileType.BIN;
                return true;
            }
            else
            {
                file_type = fileType.OTHER;
                return false;
            }
        }

        private bool is_FEX_file(string file)
        {
            char[] extension = new char[4];

            extension[0] = file[file.Length - 4];
            extension[1] = file[file.Length - 3];
            extension[2] = file[file.Length - 2];
            extension[3] = file[file.Length - 1];

            if ((extension[0] == '.') && (extension[1] == 'f' || extension[1] == 'F') && (extension[2] == 'e' || extension[2] == 'E') && (extension[3] == 'x' || extension[3] == 'X'))
            {
                file_type = fileType.FEX;
                return true;
            }
            else
            {
                file_type = fileType.OTHER;
                return false;
            }
        }

        private bool is_BINFEX_file(string file)
        {
            if (is_BIN_file(file) || is_FEX_file(file))
                return true;
            else
                return false;
        }
    }
}