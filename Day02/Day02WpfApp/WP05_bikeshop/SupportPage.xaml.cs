using System.Windows.Controls;
using System.Windows.Media;
using WP05_bikeshop.Logics;

namespace WP05_bikeshop
{
    /// <summary>
    /// SupportPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SupportPage : Page
    {
        Car myCar = null;

        public SupportPage()
        {
            InitializeComponent();
            InitCar();
        }

        private void InitCar()
        {
            // 일반적인 C#에서 클래스 객체 인스턴스 사용방법 동일
            myCar = new Car();
            myCar.Names = "아이오닉";
            myCar.Colors = Colors.White;
            myCar.Speed = 220;
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // TxtSample.Text = myCar.Speed.ToString(); // 전통적인 윈폼 방식
        }

        //private void SldValue_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        //{
        //    PgbValue.Value = SldValue.Value;
        //    LblValue.Content = SldValue.Value.ToString();
        //}
    }
}
