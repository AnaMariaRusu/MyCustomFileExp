using System.ComponentModel;

namespace MyCustomFile.ViewModels
{
    // fire up an action 
    // for instance when a search click is performed
    // abstract because is depends on the UI component
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
                handler(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }
}
