using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;

namespace OSU_Player.ViewModel 
{
    public class BaseVM : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class RelayCommand : ICommand {
        private Action<object?> execute;
        private Func<object?, bool> canExecute;
 
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
 
        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
 
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
 
        public void Execute(object? parameter)
        {
            this.execute(parameter);
        }

    }
}