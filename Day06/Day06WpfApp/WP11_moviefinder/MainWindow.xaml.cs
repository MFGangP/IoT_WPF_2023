using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WP11_moviefinder.Logics;

namespace WP11_moviefinder
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnNaverMovie_Click(object sender, RoutedEventArgs e)
        {
            await Commons.ShowMessageAsync("네이버 영화", "네이버 영화로 이동합니다.");
        }

        // 입력 검증
        private async void BtnSearchMovie_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMovieName.Text))
            {
                await Commons.ShowMessageAsync("검색", "검색 할 영화명을 입력하세요.");
                return;
            }
            if (TxtMovieName.Text.Length <= 1)
            {
                await Commons.ShowMessageAsync("검색", "검색어를 2자 이상 입력하세요.");
                return;
            }
            try
            {
                SearchNaverMovie(TxtMovieName.Text);
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"오류발생 : {ex.Message}");
                throw;
            }
        }

        // 텍스트 박스에서 키를 입력할 때 엔터를 누르면 검색 시작
        private void TxtMovieName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSearchMovie_Click(sender, e);
            }
        }

        // 실제 검색 메서드
        private void SearchNaverMovie(string movieName)
        {
            string clientID = "LlKJbD39wVtTrcTbv9mD"; // 네이버 클라이언트 아이디 검색api
            string clientSecret = "O1Vnd0DC58"; // // 네이버 클라이언트 비밀번호
            string openApiUri = $"https://openapi.naver.com/v1/search/movie?start=1&display=30&query={movieName}";
            string result = string.Empty; // 결과값
            
            // API 실행할 객체
            WebRequest req = null;
            WebResponse res = null;

            // 네이버 API 요청
            try
            {
                req = WebRequest.Create(openApiUri); // URL을 넣어서 객체를 생성 
                // Naver API에서 제일 중요한 것 헤더 설정
                req.Headers.Add("X-Naver-Client-Id", clientID);
                req.Headers.Add("X-Naver-Client-Secret", clientSecret);

                res = req.GetResponse(); // 요청한 결과를 응답에 할당


                Debug.WriteLine(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
