using System.Windows.Input;

namespace PcControl {
    public class RelayCommand : ICommand {
        private readonly Predicate<object>? _canExecute;
        private readonly Action<object>? _execute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initiate an instance of the command with only execution action.
        /// </summary>
        /// <param name="execute">the action to execute</param>
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// Initiate an instance of the command with both excution action and condition.
        /// </summary>
        /// <param name="execute">the action to execute</param>
        /// <param name="canExecute">the execution condition</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Invoke the condition method
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Invoke the action method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => _execute(parameter);

        /// <summary>
        /// Notify the UI of the change in execution condition
        /// </summary>
        public void Notify() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
