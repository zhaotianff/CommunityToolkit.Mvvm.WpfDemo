using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityToolkit.Mvvm.WpfDemo.Messages
{
    public class Patient
    {
        public string ID { get; set; }

        public string Name { get; set; }
    }

    public class PatientMessage : ValueChangedMessage<Patient>
    {
        public PatientMessage(Patient value) : base(value)
        {
        }
    }

    public sealed class CurrentPatientRequestMessage : RequestMessage<Patient>
    {
    }
}
