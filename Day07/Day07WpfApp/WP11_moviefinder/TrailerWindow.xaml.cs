﻿using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WP11_moviefinder.Models;

namespace WP11_moviefinder
{
    /// <summary>
    /// TrailerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TrailerWindow : MetroWindow
    {
        List<YoutubeItem> youtubeItems = null;
        public TrailerWindow()
        {
            InitializeComponent();
        }

        // 부모에서 데이터를 가져오려면 재정의 생성자
        public TrailerWindow(string movieName) : this() // 이 창의 InitializeComponent
        {
            LblMovieName.Content = $"{movieName} 예고편";
        }
        
        // 부모에서 객체를 통채로 전달받을 수 있음
        public TrailerWindow(MovieItem movie) : this()
        {
            LblMovieName.Content = $"{movie.Title} 예고편";
        }
        // 화면 로드 완료 후에 바로 YoutubeAPI 실행
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            youtubeItems = new List<YoutubeItem>(); // 초기화
            SearchYoutubeApi();
        }

        private async void SearchYoutubeApi()
        {
            await LoadDataCollection();
            LsvResult.ItemsSource = youtubeItems; // direct binding
        }

        private async Task LoadDataCollection()
        {
            var youtubeService = new YouTubeService(
                new BaseClientService.Initializer()
                { 
                    ApiKey = "AIzaSyCcWTgzw8_DxtqvyMHHjC5cMy42jzceEDE",
                    ApplicationName = this.GetType().ToString()
                });

            var req = youtubeService.Search.List("snippet");
            req.Q = LblMovieName.Content.ToString();
            req.MaxResults = 10;

            var res = await req.ExecuteAsync(); // 검색 결과를 받아옴

            Debug.WriteLine("유튜브 검색 결과 ----------");
            foreach (var item in res.Items)
            {
                Debug.WriteLine(item.Snippet.Title);
                if (item.Id.Kind.Equals("youtube#video")) // youtube#video만 동영상 플레이 가능
                {
                    YoutubeItem youtube = new YoutubeItem()
                    {
                        Title = item.Snippet.Title,
                        ChannelItem = item.Snippet.ChannelTitle,
                        URL = $"https://www.youtube.com/watch?v={item.Id.VideoId}" // 유튜브 플레이 링크
                        // Author = item.Snippet.ChannelTitle
                    };

                    youtube.Thumbnail = new BitmapImage(new Uri(item.Snippet.Thumbnails.Default__.Url,
                                                                UriKind.RelativeOrAbsolute));
                    youtubeItems.Add(youtube);
                }

            }
        }

        private void LsvResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LsvResult.SelectedItem is YoutubeItem) 
            {
                var video = LsvResult.SelectedItem as YoutubeItem;
                BrsYoutube.Address = video.URL;
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BrsYoutube.Address = string.Empty;
            BrsYoutube.Dispose(); // 리소스 해제

        }
    }
}
