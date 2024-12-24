﻿using System.ComponentModel;

namespace FNVCB.VIEWMODEL
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //property changed event handler

        public void NotifyPropertyChanged(string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}