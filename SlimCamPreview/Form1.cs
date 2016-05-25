using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;

namespace SlimCamPreview
{
    public partial class Form1 : Form {

        private LiveDeviceSource liveDeviceSource;
        private LiveJob job;
        private Config configuration;
        private System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            try {
                SaveCameraInfoToFile();
            }
            catch (Exception ex) {
                var msg = $"Unable to save connected camera info to text file: {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            init_timer();
            
            configuration = new Config();

            StartVideo();
        }

        private void StartVideo() {

            StopVideo();

            job = new LiveJob();
            liveDeviceSource = job.AddDeviceSource(configuration.Camera, null);

            if (configuration.Camera != null) {
                liveDeviceSource.PickBestVideoFormat(new Size(configuration.Width, configuration.Height), configuration.FramesPerSecond);

                // Get the properties of the device video
                SourceProperties sp = liveDeviceSource.SourcePropertiesSnapshot();
                
                // Setup the output video resolution file as the preview
                job.OutputFormat.VideoProfile.Size = new Size(sp.Size.Width, sp.Size.Height);

                // Sets preview window to winform panel hosted by window
                liveDeviceSource.PreviewWindow = new PreviewWindow(new HandleRef(videoPanel, videoPanel.Handle));
            }
            
            // Make this source the active one
            job.ActivateSource(liveDeviceSource);

        }

        void StopVideo()
        {
            // Has the Job already been created ?
            if (job != null)
            {
                job.StopEncoding();

                // Remove the Device Source and destroy the job
                job.RemoveDeviceSource(liveDeviceSource);

                // Destroy the device source
                liveDeviceSource.PreviewWindow = null;
                liveDeviceSource = null;
            }
        }

        private void SaveCameraInfoToFile() {
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var cameraFilePath = System.IO.Path.Combine(appDirectory, "Cameras.txt");

            var cameraInfo = new StringBuilder();
            cameraInfo.AppendLine($"Available cameras as of {DateTime.Now} :");
            cameraInfo.AppendLine();
            cameraInfo.AppendLine("To use a camera, put its name or device path into the \"camera\" setting in the config file.");
            cameraInfo.AppendLine();

            var cameras = EncoderDevices.FindDevices(EncoderDeviceType.Video).ToList();
            int cameraNameMaxLength = cameras.Max(c => c.Name.Length);
            foreach (var camera in cameras) {
                cameraInfo.AppendLine($"{camera.Name.PadRight(cameraNameMaxLength)}  |  {camera.DevicePath}");
            }

            System.IO.File.WriteAllText(cameraFilePath, cameraInfo.ToString());
        }

        private void init_timer() {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (o, args) => { timer_elapsed(); };
            timer.Start();
        }

        private void timer_elapsed() {
            if (liveDeviceSource == null || configuration.Camera == null) {
                this.Text = "";
                return;
            }

            SourceProperties sp = liveDeviceSource.SourcePropertiesSnapshot();
            this.Text = $"SlimCamPreview | {configuration.Camera.Name} | {sp.Size.Width}x{sp.Size.Height} {sp.FrameRate:N2}fps | Double-click to hide/show chrome | PgUp/PgDn to cycle cameras";
        }

        public bool ChromeVisible {
            get { return (this.FormBorderStyle != FormBorderStyle.None); }
            set
            {
                // note the location of the window client rectangle
                var oldPosition = this.PointToScreen(new Point(0,0));
                // change the form border
                this.FormBorderStyle = (value ? FormBorderStyle.Sizable : FormBorderStyle.None);
                // see how the client rectangle moved
                var newPosition = this.PointToScreen(new Point(0, 0));
                var moved = new Point(newPosition.X - oldPosition.X, newPosition.Y - oldPosition.Y);
                // move the window so the client rectangle is in the same place as before
                this.Location = new Point(Location.X - moved.X, Location.Y - moved.Y);
            }
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            liveDeviceSource?.PreviewWindow?.SetSize(videoPanel.Size);
        }

        private void clickPanel_DoubleClick(object sender, EventArgs e) {
            ChromeVisible = !ChromeVisible;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp) {
                IncrementCamera(-1);
            }

            if (e.KeyCode == Keys.PageDown) {
                IncrementCamera(1);
            }
        }

        private void IncrementCamera(int increment) {
            // get index of the current camera
            var cameras = EncoderDevices.FindDevices(EncoderDeviceType.Video).ToList();
            int currentIndex = cameras.FindIndex(c => c.DevicePath == configuration.Camera?.DevicePath);

            if (currentIndex < 0) {
                // no camera currently in use, jump to the first one in the list
                SwitchCamera(cameras.FirstOrDefault());
                return;
            }

            int newIndex = (currentIndex + increment);
            if (increment < 0 && newIndex < 0) { newIndex = (cameras.Count - 1); }
            if (increment > 0 && newIndex > (cameras.Count - 1)) { newIndex = 0; }

            SwitchCamera(cameras[newIndex]);
        }

        private void SwitchCamera(EncoderDevice camera) {
            configuration.Camera = camera;
            StartVideo();
        }

        private void SwitchCamera(string cameraName, string cameraDevicePath)
        {
            var cameras = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            var device = cameras.FirstOrDefault(d => d.DevicePath == cameraDevicePath && d.Name == cameraName);
            SwitchCamera(device);
        }

        private void RightClickMenu_Opening(object sender, CancelEventArgs e)
        {
            // Update checkmarks to reflect current reality
            miWindowBorderVisible.Checked = ChromeVisible;
            miKeepOnTop.Checked = this.TopMost;

            // update the Choose Camera dropdown with a current list of cameras
            miChooseCamera.DropDownItems.Clear();
            var cameras = EncoderDevices.FindDevices(EncoderDeviceType.Video).ToList();
            cameras.Select(c => {
                var cameraMenuItem = new ToolStripMenuItem(c.Name) {
                    Tag = new KeyValuePair<string,string>(c.Name, c.DevicePath),
                    Checked = (c.Name == configuration?.Camera?.Name && c.DevicePath == configuration?.Camera?.DevicePath)
                };
                cameraMenuItem.Click += CameraMenuItemOnClick;
                return cameraMenuItem;
            })
            .ToList().ForEach(mi => miChooseCamera.DropDownItems.Add(mi));
            
        }

        private void CameraMenuItemOnClick(object sender, EventArgs eventArgs) {
            var menuItemTag = (KeyValuePair<string, string>)((ToolStripMenuItem)sender).Tag;
            string cameraName = menuItemTag.Key;
            string cameraDevicePath = menuItemTag.Value;
            SwitchCamera(cameraName, cameraDevicePath);
        }

        private void miWindowBorderVisible_Click(object sender, EventArgs e) {
            this.ChromeVisible = miWindowBorderVisible.Checked;
        }

        private void miChooseCamera_DropDownOpening(object sender, EventArgs e)
        {

        }

        private void miKeepOnTop_Click(object sender, EventArgs e) {
            this.TopMost = miKeepOnTop.Checked;
        }
    }
}
