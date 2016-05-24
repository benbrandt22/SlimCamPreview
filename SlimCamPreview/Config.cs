using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Expression.Encoder.Devices;

namespace SlimCamPreview
{
    public class Config
    {
        public Config() {
            //defaults...
            Camera = null;
            Width = 1920;
            Height = 1080;
            FramesPerSecond = 30;

            LoadFromAppConfigFile();
        }

        public EncoderDevice Camera { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int FramesPerSecond { get; set; }


        private void LoadFromAppConfigFile() {
            var appSettings = ConfigurationManager.AppSettings;

            this.Camera = FindCamera(appSettings["camera"]);
            if (IsInt(appSettings["width"])) { Width = int.Parse(appSettings["width"]); }
            if (IsInt(appSettings["height"])) { Height = int.Parse(appSettings["height"]); }
            if (IsInt(appSettings["fps"])) { FramesPerSecond = int.Parse(appSettings["fps"]); }
        }
        
        private static bool IsInt(string str) {
            if (string.IsNullOrWhiteSpace(str)) { return false; }
            int value;
            return int.TryParse(str, out value);
        }

        private static EncoderDevice FindCamera(string camera)
        {
            var cameras = EncoderDevices.FindDevices(EncoderDeviceType.Video);

            if (string.IsNullOrWhiteSpace(camera) && cameras.Count == 1) {
                return cameras.First();
            }

            var device = cameras.FirstOrDefault(d => d.DevicePath == camera || d.Name == camera);
            return device;
        }

    }
}
