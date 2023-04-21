using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP08_personalInfoApp_mvvm.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        // View에서 사용할 멤버변수 선언
        // 입력 쪽 변수
        private string inFirstName;
        private string inLastName;
        private string inEmail;
        private DateTime inDate;
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
            get => InLastName;
            set
            {
                InLastName = value;
                RaisePropertyChanged(nameof(InLastName));
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
    }
}
