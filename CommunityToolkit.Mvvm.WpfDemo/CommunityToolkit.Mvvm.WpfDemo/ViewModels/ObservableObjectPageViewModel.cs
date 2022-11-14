using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.WpfDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CommunityToolkit.Mvvm.WpfDemo.ViewModels
{
    public class ObservableObjectPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private string currentTime;

        public string CurrentTime { get => currentTime; set => SetProperty(ref currentTime, value); }


        private ObservableCollection<ObservableStudent> studentList;
        public ObservableCollection<ObservableStudent> StudentList { get => studentList; set => SetProperty(ref studentList, value); }


        private ObservableStudent selectedStudent;
        public ObservableStudent SelectedStudent { get => selectedStudent; set => SetProperty(ref selectedStudent, value); }


        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateNameCommand { get; set; }

        public ObservableObjectPageViewModel()
        {
            UpdateCommand = new RelayCommand(UpdateTime);
            UpdateNameCommand = new RelayCommand(UpdateName);
            InitStudentList();
        }

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("F");
        }

        private void InitStudentList()
        {
            StudentList = new ObservableCollection<ObservableStudent>();

            //假设这些数据来自数据库
            Student student1 = new Student() { ID = "1", Name = "相清" };
            Student student2 = new Student() { ID = "2", Name = "濮悦" };

            StudentList.Add(new ObservableStudent(student1));
            StudentList.Add(new ObservableStudent(student2));

        }

        private void UpdateName()
        {
            if (SelectedStudent == null)
                return;

            SelectedStudent.Name += "_修改";
        }
    }
}
