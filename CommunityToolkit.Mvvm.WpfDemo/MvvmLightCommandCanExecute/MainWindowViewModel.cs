using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmLightCommandCanExecute
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string inputText;

        public string InputText { get => inputText; set => Set("InputText", ref inputText, value); }

        public ICommand MsgShowCommand { get; set; }

        public MainWindowViewModel()
        {
            MsgShowCommand = new RelayCommand(ShowMsg,CanShowMsgExecute);
        }

        private void ShowMsg() => MessageBox.Show(InputText);

        private bool CanShowMsgExecute() => !string.IsNullOrEmpty(InputText);
    }
}
