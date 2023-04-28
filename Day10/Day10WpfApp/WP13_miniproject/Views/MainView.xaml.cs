using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WP13_miniproject.Logics;
using WP13_miniproject.Models;
using WP13_miniproject.ViewModels;

namespace WP13_miniproject.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
        #region <콤보박스에 데이터 넣는 함수 >
        private void CboDataLoad(string query, string dataname, ComboBox CboName)
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                List<string> saveDateList = new List<string>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    saveDateList.Add(Convert.ToString(row[dataname]));
                }
                CboName.ItemsSource = saveDateList;
            }
        }
        #endregion
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CboRailOprLittNm != null)
                {
                    // 콤보박스에 들어갈 날짜를 DB에서 불러와서 
                    string RailOprLittNm_query = $@"SELECT rail_opr_istt_cd AS RailOprLittCd,
	                                                       rail_opr_istt_nm AS RailOprLittNm
                                                      FROM stationinfo
                                                     GROUP BY rail_opr_istt_cd,
	                                                       rail_opr_istt_nm";
                    CboDataLoad(RailOprLittNm_query, "RailOprLittNm", CboRailOprLittNm);

                    string LnNm_query = $@"SELECT ln_cd AS Ln_Cd,
                                             ln_nm AS Ln_Nm
                                        FROM stationinfo
                                       GROUP BY ln_cd,
	                                         ln_nm";
                    CboDataLoad(LnNm_query, "Ln_Nm", CboLnNm);

                    string StinNm_query = $@"SELECT stin_cd AS Stin_Cd,
                                                    stin_nm AS Stin_Nm
                                               FROM stationinfo
                                              GROUP BY stin_cd,
                                                    stin_nm";
                    CboDataLoad(StinNm_query, "Stin_Nm", CboStinNm);
                }
                else
                {
                    this.DataContext = null;
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 불러오기 오류! {ex.Message}");
            }
        }

        private void CboRailOprLittNm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboRailOprLittNm != null)
            {
                string CboRailOprLittNmSelected = CboRailOprLittNm.ItemsSource.ToString();


            }
        }
    }
}
