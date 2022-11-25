using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.WpfDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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


        public ObservableObjectPageViewModel()
        {
            InitStudentList();
            StartUpdateTimer();
        }

        private void StartUpdateTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += (a, b) => UpdateTime();
            dispatcherTimer.Start();
        }

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("F");
        }

        private void InitStudentList()
        {
            //假设这些数据来自数据库
            var dbStudentList = GetDemoData();

            StudentList = new ObservableCollection<ObservableStudent>(dbStudentList.Select(x => new ObservableStudent(x)));
        }

        private List<Student> GetDemoData()
        {
            var list = new List<Student>();
            Student student1 = new Student() { ID = "1", Name = "相清" };
            Student student2 = new Student() { ID = "2", Name = "濮悦" };
            list.Add(student1);
            list.Add(student2);
            return list;
        }

    }
}
