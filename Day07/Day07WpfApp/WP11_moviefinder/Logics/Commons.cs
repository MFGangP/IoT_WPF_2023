using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WP11_moviefinder.Logics
{
    // 메트로 다이얼 로그 창을 위한 정적 메서드
    internal class Commons
    {
        // 연결 문자열 담는 변수 // 청크로 이루어져있음 Key, Value
        public static readonly string conString = "Data Source=localhost;" +
                                                  "Initial Catalog=pknu;" +
                                                  "Persist Security Info=True;" +
                                                  "User ID=sa;" +
                                                  "Password=12345";


        public static async Task<MessageDialogResult> ShowMessageAsync(string title, string message, 
            MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            return await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(title, message, style, null);
        }
        
    }
}
