using Common;
using System.Text;

namespace PcControl {
    public partial class CameraView : DevExpress.XtraEditors.XtraForm {

        readonly PcConfig cfg = ConfigManager<PcConfig>.Instance.Config;

        readonly RpcManagedClient mqtt;
        readonly CameraViewControl vm;
        readonly CameraViewMedia vmm;

        private int hMin, hMax, vMin, vMax, zMin, zMax, lMin, lMax;

        // object Station do form chính cung cấp
        public Station Station { get; set; }

        public CameraView(Station station) {
            InitializeComponent();
            InitializeParams();

            Station = station;
            mqtt = new(cfg);
            vmm = new CameraViewMedia(Station.StationId, mqtt);
            vm = new CameraViewControl(Station.StationId, mqtt);

            // Control binding                     
            ControlBinding(vm);

            // Media binding
            MediaBinding(vmm);

            // Form UI event binding
            FormEventBiding();

            //Schedule();
        }

        // đặt giá trị giới hạn của các điều khiển
        private void InitializeParams() {
            hMin = cfg.HMin;
            hMax = cfg.HMax;
            vMin = cfg.VMin;
            vMax = cfg.VMax;
            zMin = cfg.ZMin;
            zMax = cfg.ZMax;
            lMin = cfg.LMin;
            lMax = cfg.LMax;

            tbLeftRight.Properties.Minimum = hMin;
            tbLeftRight.Properties.Maximum = hMax;
            tbUpDown.Properties.Minimum = vMin;
            tbUpDown.Properties.Maximum = vMax;
            tbZoom.Properties.Minimum = zMin;
            tbZoom.Properties.Maximum = zMax;
            tbLens.Properties.Minimum = lMin;
            tbLens.Properties.Maximum = lMax;
        }

        // các sự kiện của form 
        private void FormEventBiding() {
            logPanel.CustomButtonClick += (s, e) => lbLog.Items.Clear();
            Load += (s, e) => MqttBinding(mqtt);
            
            //TODO click đúp để mở file
            //lbImage.DoubleClick += (s, e) => { lbImage.SelectedValue};
        }

        // các sự kiện điều khiển media
        private void MediaBinding(CameraViewMedia vmm) {
            videoView.MediaPlayer = vmm.Player;
            btnPlay.Click += async (s, e) => await vmm.PlayAsync();
            btnPause.Click += async (s, e) => await vmm.PauseAsync();
            btnStream.Click += async (s, e) => await vmm.StartStreamingAsync();
            btnStop.Click += async (s, e) => await vmm.StopStreamingAsync();
            btnCapture.Click += async (s, e) => await vmm.CaptureAsync();
            cbbResolutions.DataSource = vmm.Resolutions;
            cbbResolutions.DisplayMember = nameof(VideoResolution.Description);
            cbbResolutions.DataBindings.Add("SelectedItem", vmm, nameof(CameraViewMedia.CurrentResolution));
        }

        // đăng ký sự kiện cho mqtt
        private void MqttBinding(RpcManagedClient mqtt) {
            var ph0 = cfg.Ph[0];
            var logTopic = cfg.LogTopic.Replace(ph0, Station.StationId);
            var imgTopic = cfg.ImageTopic.Replace(ph0, Station.StationId);

            mqtt.Client.ApplicationMessageReceivedAsync += LogHandling;
            mqtt.Client.ConnectedAsync += (e) => {
                Invoke(() => Text = $"{Station.Name} - CONNECTED");
                try {
                    var rpcRpiStatusTopic = cfg.RpcRpiStatusTopic.Replace(cfg.Ph[0], Station.StationId);
                    var res = mqtt.RpcCallNoPayload(rpcRpiStatusTopic); //TODO đặt command vào file config [OK]
                    if (res.Result.GetString() == "true") MessageBox.Show("Station connected");
                } catch (Exception) {
                    MessageBox.Show("Station disconnected");
                }
                return Task.CompletedTask;
            };
            mqtt.Client.DisconnectedAsync += (e) => { Invoke(() => Text = $"{Station.Name} - DISCONNECTED"); return Task.CompletedTask; };

            _ = mqtt.ConnectAsync();
            _ = mqtt.SubscribeAsync(logTopic);
            _ = mqtt.SubscribeAsync(imgTopic);

            // local function
            Task LogHandling(MQTTnet.Client.MqttApplicationMessageReceivedEventArgs arg) {
                string topic = arg.ApplicationMessage.Topic;
                // TODO cần xử lý cả log và tải ảnh [OK]
                if (topic == imgTopic) {
                    var fileName = Encoding.UTF8.GetString(arg.ApplicationMessage.CorrelationData);
                    var fullPath = Path.Combine(cfg.ImageFolder, fileName);
                    Invoke(() => { lbImage.Items.Add($"[{DateTime.Now}] {fullPath}"); });
                } else if (topic == logTopic) {
                    string payload = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
                    Invoke(() => { lbLog.Items.Add($"[{DateTime.Now}] {payload}"); });
                }
                return Task.CompletedTask;

            }
        }

        // binding chức năng điều khiển động cơ
        private void ControlBinding(CameraViewControl vm) {
            teLeftRight.DataBindings.Add("Text", vm, nameof(CameraViewControl.HorizontalValue), false, DataSourceUpdateMode.OnPropertyChanged);
            tbLeftRight.DataBindings.Add("Value", vm, nameof(CameraViewControl.HorizontalValue), false, DataSourceUpdateMode.OnPropertyChanged);

            teUpDown.DataBindings.Add("Text", vm, nameof(CameraViewControl.VerticalValue), false, DataSourceUpdateMode.OnPropertyChanged);
            tbUpDown.DataBindings.Add("Value", vm, nameof(CameraViewControl.VerticalValue), false, DataSourceUpdateMode.OnPropertyChanged);

            teZoom.DataBindings.Add("Text", vm, nameof(CameraViewControl.ZoomValue), false, DataSourceUpdateMode.OnPropertyChanged);
            tbZoom.DataBindings.Add("Value", vm, nameof(CameraViewControl.ZoomValue), false, DataSourceUpdateMode.OnPropertyChanged);

            teLens.DataBindings.Add("Text", vm, nameof(CameraViewControl.LensValue), false, DataSourceUpdateMode.OnPropertyChanged);
            tbLens.DataBindings.Add("Value", vm, nameof(CameraViewControl.LensValue), false, DataSourceUpdateMode.OnPropertyChanged);

            btnMoveUp.Click += (s, e) => vm.MoveStep(Movement.MoveUp);
            btnMoveDown.Click += (s, e) => vm.MoveStep(Movement.MoveDown);
            btnMoveLeft.Click += (s, e) => vm.MoveStep(Movement.MoveLeft);
            btnMoveRight.Click += (s, e) => vm.MoveStep(Movement.MoveRight);
            btnZoomIn.Click += (s, e) => vm.MoveStep(Movement.ZoomIn);
            btnZoomOut.Click += (s, e) => vm.MoveStep(Movement.ZoomOut);
            btnLensIn.Click += (s, e) => vm.MoveStep(Movement.LensIn);
            btnLensOut.Click += (s, e) => vm.MoveStep(Movement.LensOut);
            btnMove.Click += (s, e) => vm.Move(true, true);
        }

        private void Schedule() {
            System.Timers.Timer timer = new(60000);
            timer.Elapsed += (s, e) => {
                MessageBox.Show("Need to do something");
            };
            timer.Start();
        }
    }
}