using Common;
using System.IO;

namespace PcControl {

    public class CameraViewControl : BindableBase {

        private PcConfig controlConfig = ConfigManager<PcConfig>.Instance.Config;

        private readonly string gcodeTopic;
        private readonly int hStep, vStep, zStep, lStep;
        private readonly string vCode, hCode, zCode, lCode;
        private readonly int hMin, hMax, vMin, vMax, zMin, zMax, lMin, lMax;
        private readonly string ph0;
        private readonly RpcManagedClient mqtt;

        public CameraViewControl(string stationId, RpcManagedClient mqtt) {
            this.mqtt = mqtt;
            ph0 = controlConfig.Ph[0];
            gcodeTopic = controlConfig.SerialGcodeTopic.Replace(ph0, stationId);

            hStep = controlConfig.HStep;
            vStep = controlConfig.VStep;
            zStep = controlConfig.ZStep;
            lStep = controlConfig.LStep;

            vCode = controlConfig.VCode;
            hCode = controlConfig.HCode;
            lCode = controlConfig.LCode;
            zCode = controlConfig.ZCode;

            hMin = controlConfig.HMin;
            hMax = controlConfig.HMax;
            vMin = controlConfig.VMin;
            vMax = controlConfig.VMax;
            zMin = controlConfig.ZMin;
            zMax = controlConfig.ZMax;
            lMin = controlConfig.LMin;
            lMax = controlConfig.LMax;
        }

        private int horizontalValue = 0;
        public int HorizontalValue {
            get => horizontalValue;
            set {
                if (value >= hMin && value <= hMax) {
                    SetValue(ref horizontalValue, value, nameof(HorizontalValue));
                }
            }
        }

        private int verticalValue = 0;
        public int VerticalValue {
            get => verticalValue;
            set {
                if (value >= vMin && value <= vMax) {
                    SetValue(ref verticalValue, value, nameof(VerticalValue));
                }
            }
        }

        private int zoomValue = 0;
        public int ZoomValue {
            get => zoomValue;
            set {
                if (value >= zMin && value <= zMax) {
                    SetValue(ref zoomValue, value, nameof(ZoomValue));
                    Task.Run(() => mqtt.PublishStringAsync(gcodeTopic, zCode.Replace(ph0, value)));
                }
            }
        }

        private int lensValue = 0;
        public int LensValue {
            get => lensValue;
            set {
                if (value >= lMin && value <= lMax) {
                    SetValue(ref lensValue, value, nameof(LensValue));
                    Task.Run(() => mqtt.PublishStringAsync(gcodeTopic, lCode.Replace(ph0, value)));
                }
            }
        }

        public void MoveStep(Movement movement) {
            switch (movement) {
                case Movement.MoveUp: VerticalValue -= vStep; Move(vertical: true); break;
                case Movement.MoveDown: VerticalValue += vStep; Move(vertical: true); break;

                case Movement.MoveLeft: HorizontalValue -= hStep; Move(horizontal: true); break;
                case Movement.MoveRight: HorizontalValue += hStep; Move(horizontal: true); break;

                case Movement.ZoomIn: ZoomValue += zStep; break;
                case Movement.ZoomOut: ZoomValue -= zStep; break;

                case Movement.LensIn: LensValue += lStep; break;
                case Movement.LensOut: LensValue -= lStep; break;
            }
        }

        public void Move(bool horizontal = false, bool vertical = false) {
            if (horizontal)
                Task.Run(() => mqtt.PublishStringAsync(gcodeTopic, hCode.Replace(ph0, HorizontalValue)));
            if (vertical)
                Task.Run(() => mqtt.PublishStringAsync(gcodeTopic, vCode.Replace(ph0, VerticalValue)));
        }

        public void ReloadControlConfig() {
            ConfigManager<PcConfig>.Instance.Load();
            controlConfig = ConfigManager<PcConfig>.Instance.Config;
        }

    }
}
