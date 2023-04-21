using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WP08_personalInfoApp_mvvm.Logics;

namespace WP08_personalInfoApp_mvvm.Models
{
    internal class Person
    {
        // 외부에서 접근 불가
        private string email;
        private DateTime date;

        public string FirstName { get; set; } //Auto Property
        public string LastName { get; set; }
        public string Email { 
            get => email;
            set 
            { 
                if(Commons.IsValidEmail(value) != true) // 이메일이 형식에 일치하지 않음
                {
                    throw new Exception("유요하지 않은 이메일 형식");
                }
                else
                {
                    email = value;
                }
            } 
        }
        public DateTime Date
        {
            get => date;
            set
            {
                var result = Commons.GetAge(value);
                if (result > 120 || result < 0)
                {
                    throw new Exception("유효하지 않은 생일");
                }
                else
                {
                    date = value;
                }
            }
        }
        public bool IsAdult
        {
            get => Commons.GetAge(date) > 18; // 19살 이상이면 True
        }
        public  bool IsBirthDay
        {
            get
            {
                return DateTime.Now.Month == date.Month && // 오늘하고 비교 월 일이 같으면 생일
                       DateTime.Now.Day == date.Day;
            }
        }
        public string Zodiac
        {
            get => Commons.GetZodiac(date); // 12지로 띠를 받아옴
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }
    }
}
