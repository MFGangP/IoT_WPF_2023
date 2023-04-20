using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using WP05_bikeshop.Logics;

namespace WP05_bikeshop
{
    /// <summary>
    /// SupportPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        Car myCar = null;

        public TestPage()
        {
            InitializeComponent();
            InitCar();
        }

        private void InitCar()
        {
            // 일반적인 C#에서 클래스 객체 인스턴스 사용방법 동일
            myCar = new Car();
            myCar.Names = "아이오닉";
            myCar.Colorz = Colors.White;
            myCar.Speed = 220;

            // 리스트 박스에 바인딩 하기 위한 Car 리스트
            var rand = new Random(); // 랜덤 컬러
            List<Car> cars = new List<Car>();
            for(int i = 0; i < 10; i++)
            {
                cars.Add(new Car() {
                    Speed = i * 10,
                    Colorz = Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256))
                }) ;
            }
            // 테스트 페이지 전체 = this.DataContext 페이지 전체에 바인딩
            // 아래는 콤보 박스에만
            CtlCars.DataContext = cars; // 중요함 코드 비하인드에서 만든 데이터(DB, Excel...)를
                                     // xaml에 있는 컨트롤에 데이터 바인딩 하려면 어딘가에 값을 넣어야된다. 
                                     // xaml 내 모든 요소에 다 DataContext 가능함
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
