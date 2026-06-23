using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

public class LauncherForm : Form
{
    private Process serverProcess;

    public LauncherForm()
    {
        this.Text = "D-Mart Billing System";
        this.Size = new Size(400, 160);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        Label label = new Label();
        label.Text = "D-Mart Billing Server is running...\n\nAccess at: http://localhost:8080\n\nClose this window to stop the server.";
        label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        label.Size = new Size(360, 90);
        label.Location = new Point(12, 15);
        label.TextAlign = ContentAlignment.MiddleCenter;
        this.Controls.Add(label);

        this.Load += LauncherForm_Load;
        this.FormClosing += LauncherForm_FormClosing;
    }

    private void LauncherForm_Load(object sender, EventArgs e)
    {
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        string batchPath = Path.Combine(currentDir, "start.bat");

        if (!File.Exists(batchPath))
        {
            MessageBox.Show("start.bat not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            return;
        }

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "cmd.exe";
        psi.Arguments = "/c \"" + batchPath + "\"";
        psi.WindowStyle = ProcessWindowStyle.Hidden;
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;

        try
        {
            serverProcess = Process.Start(psi);
            
            // Open browser automatically after 2 seconds
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, args) => {
                timer.Stop();
                try {
                    Process.Start(new ProcessStartInfo("http://localhost:8080") { UseShellExecute = true });
                } catch {}
            };
            timer.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to start server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }

    private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (serverProcess != null)
        {
            try
            {
                // Force kill the process tree (cmd.exe, java.exe, mysqld.exe)
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "taskkill";
                psi.Arguments = "/F /T /PID " + serverProcess.Id;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit();
            }
            catch {}
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LauncherForm());
    }
}