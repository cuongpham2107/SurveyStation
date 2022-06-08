using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PcControl {
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void Notify([CallerMemberName] string property = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void SetValue<T>(ref T field, T value, [CallerMemberName] string property = "") {
            field = value;
            Notify(property);
        }
    }
}
