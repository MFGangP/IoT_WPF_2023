using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF09_caliburnApp.Models;

namespace WF09_caliburnApp.ViewModels
{
    public class MainViewModel : Screen
    {
        // Caliburn version업으로 변경 x:Name이랑 같이 써야한다. 기본적으로 배운 방식을 써도 되고
        private string firstName = "SeongHyeon";
        public string FirstName 
        {
            get => firstName; 
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);// 속성값이 변경된 걸 시스템에다 알려주는 역할
                NotifyOfPropertyChange(nameof(CanClearName));
                NotifyOfPropertyChange(nameof(FullName));
                // 변경 되었다는걸 안 알려주면 안바뀐다.
            }
        }
        private string lastName = "Park";
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(nameof(CanClearName));
                NotifyOfPropertyChange(nameof(FullName)); // 변화 통보
            }
        }
        
        public string FullName
        {
            get => $"{LastName}{FirstName}";
        }

        // 콤보박스에 바인딩 할 속성
        // 이런 곳에서는 var를 쓸 수 없음
        private BindableCollection<Person> managers = new BindableCollection<Person>();
        
        public BindableCollection<Person> Managers
        {
            get { return managers; }
            set { managers = value; }
        }

        // 콤보 박스에서 선택된 값을 지정 할 속성
        private Person selectedManager;


        public Person SelectedManager
        {
            get => selectedManager;
            set
            {
                selectedManager = value;
                LastName = selectedManager.LastName;
                FirstName = selectedManager.FirstName;
                NotifyOfPropertyChange(nameof(SelectedManager));
            }
        }

        public MainViewModel()
        {
            // DB를 사용하면 여기서 DB접속 > 데이터 Select까지...
            Managers.Add(new Person { FirstName = "John", LastName = "Carmack"});
            Managers.Add(new Person { FirstName = "Steve", LastName = "Jobs"});
            Managers.Add(new Person { FirstName = "Bill", LastName = "Gates"});
            Managers.Add(new Person { FirstName = "Elon", LastName = "Musk"});
        }
        public void ClearName()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        // 메서드와 이름 동일하게 하고 앞에 Can을 붙임
        public bool CanClearName
        {
            get => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        }
    }
}
