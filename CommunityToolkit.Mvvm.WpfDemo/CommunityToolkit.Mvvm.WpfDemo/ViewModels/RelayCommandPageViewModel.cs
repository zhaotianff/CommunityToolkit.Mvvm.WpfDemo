using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.WpfDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CommunityToolkit.Mvvm.WpfDemo.ViewModels
{
    public class RelayCommandPageViewModel : ObservableObject
    {
        private string currentTime;
        public string CurrentTime { get => currentTime; set => SetProperty(ref currentTime, value); }


        private string inputText;

        public string InputText
        {
            get => inputText;
            set
            {
                SetProperty(ref inputText, value);
                MsgShowCommand.NotifyCanExecuteChanged();
            }
        }

        private ObservableStudent selectedStudent;
        public ObservableStudent SelectedStudent { get => selectedStudent; set => SetProperty(ref selectedStudent, value); }


        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateNameCommand { get; set; }

        public IRelayCommand MsgShowCommand { get; set; }


        public RelayCommandPageViewModel()
        {
            UpdateCommand = new RelayCommand(UpdateTime);
            UpdateNameCommand = new RelayCommand(UpdateName);
            MsgShowCommand = new RelayCommand(ShowMsg, CanShowMsgExecute);
        }

        private void ShowMsg() => MessageBox.Show(InputText);

        private bool CanShowMsgExecute() => !string.IsNullOrEmpty(InputText);


        private void UpdateName()
        {
            if (SelectedStudent == null)
                return;

            SelectedStudent.Name += "_修改";
        }

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("F");
        }
    }

    
}
