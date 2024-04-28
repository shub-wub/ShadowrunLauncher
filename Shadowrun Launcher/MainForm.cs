using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Forms;

namespace Shadowrun_Launcher
{
    public partial class MainForm : Form
    {
        private string rootPath;
        private string onlineBuildZip = @"C:\Users\sfish\OneDrive\Desktop\build\build.zip";
        private string onlineGfwlZip = @"C:\Users\sfish\OneDrive\Desktop\build\gfwlivesetup.zip";
        private string onlineVersionFile = @"C:\Users\sfish\OneDrive\Desktop\build\version.txt";
        private string directXInstall = @"https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe";
        private string gfwlProgramFileExe = @"C:\Program Files (x86)\Microsoft Games for Windows - LIVE\Client\GFWLive.exe";
        private string releasefolderName = "shadowrun";
        private string gameZipFileName = "build.zip";
        private string gfwlZipFileName = "gfwlivesetup.zip";
        private string directXInstallFileName = "dxwebsetup.exe";
        private string versionFileName = "version.txt";
        private string gameExeFileName = "Shadowrun.exe";
        private string gfwlExeFileName = "gfwlivesetup.exe";

        private string releaseFilesPath;
        private string gameZip;
        private string gfwlZip;
        private string gameExe;
        private string gfwlExe;
        private string directXExe;
        private string localVersionFile;
        private LauncherStatus _status;

        public MainForm()
        {
            InitializeComponent();
            rootPath = Directory.GetCurrentDirectory();
            releaseFilesPath = Path.Combine(rootPath, releasefolderName);
            gameZip = Path.Combine(rootPath, gameZipFileName);
            gfwlZip = Path.Combine(rootPath, gfwlZipFileName);
            gameExe = Path.Combine(releaseFilesPath, gameExeFileName);
            gfwlExe = Path.Combine(releaseFilesPath, gfwlExeFileName);
            directXExe = Path.Combine(releaseFilesPath, directXInstallFileName);
            localVersionFile = Path.Combine(releaseFilesPath, versionFileName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void PlayButton_Click(object sender, System.EventArgs e)
        {
            if (File.Exists(gameExe) && Status == LauncherStatus.ready)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(gameExe)
                {
                    WorkingDirectory = releaseFilesPath
                };
                Process.Start(startInfo);

                Close();
            }
            else if (Status == LauncherStatus.download)
            {
                CheckForUpdates();
            }
            /*else
            {
                CheckForUpdates();
            }*/
        }
        private void CheckForUpdates()
        {
            if (File.Exists(localVersionFile))
            {
                GameVersion localVersion = new GameVersion(File.ReadAllText(localVersionFile));
                VersionText.Text = localVersion.ToString();
                try
                {
                    WebClient webClient = new WebClient();
                    GameVersion onlineVersion = new GameVersion(webClient.DownloadString(onlineVersionFile));

                    if (onlineVersion.IsDifferentThan(localVersion))
                    {
                        InstallGameFiles(true, onlineVersion);
                    }
                    else
                    {
                        Status = LauncherStatus.ready;
                    }
                }
                catch (Exception ex)
                {
                    Status = LauncherStatus.failed;
                    System.Windows.Forms.MessageBox.Show($"Error checking for game updates: {ex}");
                }
            }
            else if (Status == LauncherStatus.download)
            {
                Status = LauncherStatus.download;
                InstallGameFiles(false, GameVersion.zero);
            }
            else
            {
                Status = LauncherStatus.download;
                //InstallGameFiles(false, Version.zero);
            }
        }

        private void InstallGameFiles(bool _isUpdate, GameVersion _onlineVersion)
        {
            try
            {
                WebClient webClientGame = new WebClient();
                WebClient webClientGfwl = new WebClient();
                WebClient webClientDirectX = new WebClient();
                if (!_isUpdate)
                {
                    Status = LauncherStatus.downloadingUpdate;
                }
                else
                {
                    Status = LauncherStatus.downloadingGame;
                    _onlineVersion = new GameVersion(webClientGame.DownloadString(onlineVersionFile));
                }
                webClientGame.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);
                webClientGame.DownloadFileAsync(new Uri(onlineBuildZip), gameZip, _onlineVersion);

                // if the user doesn't already have gfwl install it
                if (File.Exists(gfwlProgramFileExe) == false)
                {
                    webClientGfwl.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGfwlCompletedCallback);
                    webClientGfwl.DownloadFileAsync(new Uri(onlineGfwlZip), gfwlZip);
                }

                if(!IsDirectX9Installed())
                {
                    webClientDirectX.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadDirectXCompletedCallback);
                    webClientDirectX.DownloadFileAsync(new Uri(directXInstall), directXInstallFileName);
                }
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                System.Windows.Forms.MessageBox.Show($"Error installing game files: {ex}");
            }
        }
        private void DownloadDirectXCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Console.WriteLine($"Attempting to run: {directXInstallFileName}");

                if (Directory.Exists(releaseFilesPath))
                {
                    if (File.Exists(directXExe))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(directXExe);
                        startInfo.Verb = "runas"; // Run as administrator
                        Process directxProcess = Process.Start(startInfo);

                        // Wait for the process to finish
                        directxProcess.WaitForExit();

                        // Close the process
                        directxProcess.Close();
                    }
                    else
                    {
                        Status = LauncherStatus.failed;
                        System.Windows.Forms.MessageBox.Show("DirectX exe not found in releases directory", "Warning", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    Status = LauncherStatus.failed;
                    System.Windows.Forms.MessageBox.Show("Your game is not installed", "Warning", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                System.Windows.Forms.MessageBox.Show($"Error finishing DirectX download: {ex}");
            }
        }
        private void DownloadGfwlCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                ZipArchiveExtensions.ExtractToDirectory(sourceDirectoryName: gfwlZip, destinationDirectoryName: releaseFilesPath, overwrite: true);
                File.Delete(gfwlZip);

                Console.WriteLine($"Attempting to run: {gfwlExe}");

                if (Directory.Exists(releaseFilesPath))
                {
                    if (File.Exists(gfwlExe))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(gfwlExe);
                        startInfo.Verb = "runas"; // Run as administrator
                        Process gfwlProcess = Process.Start(startInfo);

                        // Wait for the process to finish
                        gfwlProcess.WaitForExit();

                        // Close the process
                        gfwlProcess.Close();
                    }
                    else
                    {
                        Status = LauncherStatus.failed;
                        System.Windows.Forms.MessageBox.Show("GFWL exe not found in releases directory", "Warning", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    Status = LauncherStatus.failed;
                    System.Windows.Forms.MessageBox.Show("Your game is not installed", "Warning", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                System.Windows.Forms.MessageBox.Show($"Error finishing GFWL download: {ex}");
            }
        }
        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

            try
            {
                string onlineVersion = ((GameVersion)e.UserState).ToString();
                ZipArchiveExtensions.ExtractToDirectory(sourceDirectoryName: gameZip, destinationDirectoryName: releaseFilesPath, overwrite: true);
                File.Delete(gameZip);

                File.WriteAllText(Path.Combine(releaseFilesPath, versionFileName), onlineVersion);

                VersionText.Text = onlineVersion;
                Status = LauncherStatus.ready;
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                System.Windows.Forms.MessageBox.Show($"Error finishing game download: {ex}");
            }
        }

        public static bool IsDirectX9Installed()
        {
            string system32Directory = Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "System32");
            bool foundD3dx9 = false;
            bool foundD3d9 = false;

            foreach (string filename in Directory.GetFiles(system32Directory, "*.dll"))
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                if (fileNameWithoutExtension.StartsWith("d3dx9_", StringComparison.OrdinalIgnoreCase))
                {
                    foundD3dx9 = true;
                }
                else if (fileNameWithoutExtension.Equals("d3d9", StringComparison.OrdinalIgnoreCase))
                {
                    foundD3d9 = true;
                }

                if (foundD3dx9 && foundD3d9)
                {
                    return true; // Both DirectX 9 DLLs found
                }
            }
            return false; // Either or both DLLs are missing
        }

        internal LauncherStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case LauncherStatus.ready:
                        button1.Text = "Play";
                        break;
                    case LauncherStatus.download:
                        button1.Text = "Download";
                        break;
                    case LauncherStatus.failed:
                        button1.Text = "Update Failed - Retry";
                        break;
                    case LauncherStatus.downloadingGame:
                        button1.Text = "Downloading Game";
                        break;
                    case LauncherStatus.downloadingUpdate:
                        button1.Text = "Downloading Update";
                        break;
                    default:
                        break;
                }
            }
        }
    }

    enum LauncherStatus
    {
        ready, download, failed, downloadingGame, downloadingUpdate
    }

    struct GameVersion
    {
        internal static GameVersion zero = new GameVersion(0, 0, 0);

        private short major;
        private short minor;
        private short subMinor;

        internal GameVersion(short _major, short _minor, short _subMinor)
        {
            major = _major;
            minor = _minor;
            subMinor = _subMinor;
        }
        internal GameVersion(string _version)
        {
            string[] versionStrings = _version.Split('.');
            if (versionStrings.Length != 3)
            {
                major = 0;
                minor = 0;
                subMinor = 0;
                return;
            }

            major = short.Parse(versionStrings[0]);
            minor = short.Parse(versionStrings[1]);
            subMinor = short.Parse(versionStrings[2]);
        }

        internal bool IsDifferentThan(GameVersion _otherVersion)
        {
            if (major != _otherVersion.major)
            {
                return true;
            }
            else
            {
                if (minor != _otherVersion.minor)
                {
                    return true;
                }
                else
                {
                    if (subMinor != _otherVersion.subMinor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{subMinor}";
        }
    }
}
