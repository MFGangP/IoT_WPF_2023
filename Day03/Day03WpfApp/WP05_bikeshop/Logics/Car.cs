using System.Windows.Media;

namespace WP05_bikeshop.Logics
{

    internal class Car : Notifier // 값이 바뀌는 걸 인지하여서 처리하겠다.
    {
        private string names;
        public string Names { 
            get => names;
            // 프로퍼티를 변경하는것 
            set
            {
                names = value;
                OnPropertyChanged("Names"); // Names 프로퍼티가 바뀌었다. 시스템한테 처리해달라 요청
            }
        }
        private double speed;
        public double Speed { 
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed)); // == "Speed"
            }
        }
        public Color Colorz { get; set; }
        public Human Driver { get; set; } // Auto Property
    }
}
