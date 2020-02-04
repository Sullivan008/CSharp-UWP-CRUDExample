using System.ComponentModel;

namespace CRUDOperationsClient.ViewModels.MainPage
{
    public class MainPageViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
