using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteKeeper.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Event to notify when a property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to set a property and notify of its change
        protected virtual bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return false;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

    }
}

