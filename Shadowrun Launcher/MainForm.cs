using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Shadowrun_Launcher
{
    public partial class MainForm : Form
    {
        private string rootPath;
        private string onlineBuildZip = @"C:\Users\sfish\OneDrive\Desktop\build\build.zip";
        private string onlineVersionFile = @"C:\Users\sfish\OneDrive\Desktop\build\version.txt";
        private string releasefolderName = "shadowrun";
        private string gameZipFileName = "build.zip";
        private string versionFileName = "version.txt";
        private string gameExeFileName = "Shadowrun.exe";

        private string releaseFilesPath;
        private string gameZip;
        private string gameExe;
        private string localVersionFile;
        private LauncherStatus _status;

        public MainForm()
        {
            InitializeComponent();
            rootPath = Directory.GetCurrentDirectory();
            releaseFilesPath = Path.Combine(rootPath, releasefolderName);
            gameZip = Path.Combine(rootPath, gameZipFileName);
            gameExe = Path.Combine(releaseFilesPath, gameExeFileName);
            localVersionFile = Path.Combine(releaseFilesPath, versionFileName);
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
                Version localVersion = new Version(File.ReadAllText(localVersionFile));
                VersionText.Text = localVersion.ToString();
                try
                {
                    WebClient webClient = new WebClient();
                    Version onlineVersion = new Version(webClient.DownloadString(onlineVersionFile));

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
                    MessageBox.Show($"Error checking for game updates: {ex}");
                }
            }
            else
            {
                Status = LauncherStatus.download;
                //InstallGameFiles(false, Version.zero);
            }
        }

        private void InstallGameFiles(bool _isUpdate, Version _onlineVersion)
        {
            try
            {
                WebClient webClient = new WebClient();
                if (!_isUpdate)
                {
                    Status = LauncherStatus.downloadingUpdate;
                }
                else
                {
                    Status = LauncherStatus.downloadingGame;
                    _onlineVersion = new Version(webClient.DownloadString(onlineVersionFile));
                }
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);
                webClient.DownloadFileAsync(new Uri(onlineBuildZip), gameZip, _onlineVersion);
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error installing game files: {ex}");
            }
        }
        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                //ZipFile.ExtractToDirectory(gameZip, releaseFilesPath);
                ZipArchiveExtensions.ExtractToDirectory(sourceDirectoryName: gameZip, destinationDirectoryName: releaseFilesPath, overwrite: true);
                File.Delete(gameZip);

                File.WriteAllText(Path.Combine(releaseFilesPath, versionFileName), onlineVersion);

                VersionText.Text = onlineVersion;
                Status = LauncherStatus.ready;
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error finishing download: {ex}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
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

    struct Version
    {
        internal static Version zero = new Version(0, 0, 0);

        private short major;
        private short minor;
        private short subMinor;

        internal Version(short _major, short _minor, short _subMinor)
        {
            major = _major;
            minor = _minor;
            subMinor = _subMinor;
        }
        internal Version(string _version)
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

        internal bool IsDifferentThan(Version _otherVersion)
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
