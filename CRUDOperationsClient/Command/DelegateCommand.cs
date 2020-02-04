using System;
using System.Windows.Input;

namespace CRUDOperationsClient.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly SimpleEventHandler _handler;

        public bool IsEnabled { get; } = true;

        public event EventHandler CanExecuteChanged;

        public delegate void SimpleEventHandler();

        public DelegateCommand(SimpleEventHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        void ICommand.Execute(object obj)
        {
            _handler();
        }

        bool ICommand.CanExecute(object obj)
        {
            return IsEnabled;
        }
    }
}