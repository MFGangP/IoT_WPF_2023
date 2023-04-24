using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WP08_personalInfoApp_mvvm.Models;

namespace WP08_personalInfoApp_mvvm.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        // View에서 사용할 멤버변수 선언
        // 입력 쪽 변수
        private string inFirstName;
        private string inLastName;
        private string inEmail;
        private DateTime inDate = DateTime.Now; // 처음 값 현재 날짜로 세팅

        // 결과 출력 쪽 변수
        private string outFirstName;
        private string outLastName;
        private string outEmail;
        private string outDate; // 출력 할 때는 문자열로 대체
        private string outAdult;
        private string outBirthDay;
        private string outZodiac;
        // 일이 많아짐. 실제로 사용할 속성
        public string InFirstName 
        { 
            get => inFirstName; 
            set 
            { 
                inFirstName = value;
                RaisePropertyChanged(nameof(InFirstName)); // "InFirstName"이 바꼇다는걸 알려줌
            } 
        }

        public string InLastName
        {
            get => inLastName;
            set
            {
                inLastName = value;
                RaisePropertyChanged(nameof(inLastName));
            }
        }

        public string InEmail
        {
            get => inEmail;
            set
            {
                inEmail = value;
                RaisePropertyChanged(nameof(inEmail));
            }
        }
        public DateTime InDate
        {
            get => inDate;
            set
            {
                inDate = value;
                RaisePropertyChanged(nameof(inDate));
            }
        } 
        public string OutFirstName
        {
            get => outFirstName;
            set
            {
                outFirstName = value;
                RaisePropertyChanged(nameof(outFirstName));
            }
        }
        public string OutLastName
        {
            get => outLastName;
            set
            {
                outLastName = value;
                RaisePropertyChanged(nameof(outLastName));
            }
        }
        public string OutEmail
        {
            get => outEmail;
            set
            {
                outEmail = value;
                RaisePropertyChanged(nameof(outEmail));
            }
        }
        public string OutDate
        {
            get => outDate;
            set
            {
                outDate = value;
                RaisePropertyChanged(nameof(outDate));
            }
        }
        public string OutAdult
        {
            get => outAdult;
            set
            {
                outAdult = value;
                RaisePropertyChanged(nameof(outAdult));
            }
        }
        public string OutBirthDay
        {
            get => outBirthDay;
            set
            {
                outBirthDay = value;
                RaisePropertyChanged(nameof(outBirthDay));
            }
        }
        public string OutZodiac
        {
            get => outZodiac;
            set
            {
                outZodiac = value;
                RaisePropertyChanged(nameof(outZodiac));
            }
        }

        // 버튼 클릭에 대한 이벤트 처리 (명령)
        private ICommand proceedCommand;
        public ICommand ProceedCommand
        {
            get
            {
                // 모든 입력에 값이 들어가야지 버튼이 활성화 됨
                // 하나라도 비어있으면 버튼 비활성화
                return proceedCommand ?? (proceedCommand = new RelayCommand<object>(
                    o => Proceed(), o => !string.IsNullOrEmpty(inFirstName) &&
                                        !string.IsNullOrEmpty(inLastName) &&
                                        !string.IsNullOrEmpty(inEmail) &&
                                        !string.IsNullOrEmpty(inDate.ToString()))); 
            }
        }

        // 버튼 클릭 시 실제로 처리를 수행하는 메서드
        private void Proceed()
        {
            try
            {
                Person person = new Person(inLastName, inFirstName, inEmail, inDate);
                
                OutFirstName = person.FirstName;
                OutLastName = person.LastName;
                OutEmail = person.Email;
                OutDate = person.Date.ToString("yyyy년 MM월 dd일");
                OutAdult = person.IsAdult == true ? "성년" : "미성년";
                OutBirthDay = person.IsBirthDay == true ? "생일" : "-";
                OutZodiac = person.Zodiac;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예외발생 {ex.Message}");
            }
        }
    }
}
