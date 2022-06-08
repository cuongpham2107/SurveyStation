using Common;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcControl {
    public partial class MainView : DevExpress.XtraEditors.XtraForm {

        readonly Station[] stations = ConfigManager<CustomerStations>.Instance.Config.Stations;
        readonly PcConfig config = ConfigManager<PcConfig>.Instance.Config;

        public MainView() {
            InitializeComponent();

            this.Load += (o, e) => {
                foreach (var s in stations) {
                    CameraView cam = new(s) {
                        MdiParent = this,
                    };
                    ribbonStationList.Strings.Add(s.Name);
                    cam.Show();
                }
            };

            RibbonBinding();

        }

        private void RibbonBinding() {
            ribbonStationList.ItemClick += (s, e) => {
                ProcessStartInfo psi = new(".pccontrol.customerstations.json") { UseShellExecute = true };
                Process.Start(psi);
            };

            ribbonStationList.ListItemClick += (s, e) => {
                CameraView cam = new(stations[e.Index]) {
                    MdiParent = this,
                };
                cam.Show();
            };

            ribbonCapturedImages.ItemClick += (s, e) => {
                Process.Start("explorer.exe", config.ImageFolder);
            };

            ribbonConfiguration.ItemClick += (s, e) => {
                ProcessStartInfo psi = new(".pccontrol.pcconfig.json") { UseShellExecute = true };
                Process.Start(psi);
            };
        }

    }
}