using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.WpfDemo.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommunityToolkit.Mvvm.WpfDemo.ViewModels
{
    public class LeftPanelViewModel : ObservableRecipient
    {
        private ObservableCollection<Patient> patientList;
        public ObservableCollection<Patient> PatientList { get => patientList; set => SetProperty(ref patientList, value); }

        public IRelayCommand<Patient> SendPatientMessageCommand { get; private set; }

        public LeftPanelViewModel()
        {
            SendPatientMessageCommand = new RelayCommand<Patient>(SendMessage);
            InitDemoData();
        }

        private void SendMessage(Patient selectedPatient)
        { 
            Messenger.Send(new PatientMessage(selectedPatient));
        }

        private void InitDemoData()
        {
            PatientList = new ObservableCollection<Patient>();
            PatientList.Add(new Patient() {ID = "1001",Name = "PE1" });
            PatientList.Add(new Patient() { ID = "1002", Name = "PE2" });
            PatientList.Add(new Patient() { ID = "1003", Name = "PE3" });
            PatientList.Add(new Patient() { ID = "1004", Name = "PE4" });
            PatientList.Add(new Patient() { ID = "1005", Name = "PE5" });
        }
    }

    public class RightPanelViewModel : ObservableRecipient
    {
        private Patient currentPatient;

        public Patient CurrentPatient { get => currentPatient; set => SetProperty(ref currentPatient, value); }

        public RightPanelViewModel()
        {
            Messenger.Register<RightPanelViewModel, PatientMessage>(this, OnReceivePatientChangedMessage);
        }

        private void OnReceivePatientChangedMessage(RightPanelViewModel rightPanelViewModel,PatientMessage patientMessage)
        {
            rightPanelViewModel.CurrentPatient = patientMessage.Value;
        }
    }
}
