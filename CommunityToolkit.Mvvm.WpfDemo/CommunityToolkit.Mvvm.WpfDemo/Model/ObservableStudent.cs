using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityToolkit.Mvvm.WpfDemo.Model
{
    public class ObservableStudent : ObservableObject
    {
        private readonly Student student;

        public ObservableStudent(Student student) => this.student = student;

        public string Name
        {
            get => student.Name;
            set => SetProperty(student.Name, value, student, (u, n) => u.Name = n);
        }

        public string ID
        {
            get => student.ID;
            set => SetProperty(student.ID, value, student, (u, n) => u.ID = n);
        }
    }
}
