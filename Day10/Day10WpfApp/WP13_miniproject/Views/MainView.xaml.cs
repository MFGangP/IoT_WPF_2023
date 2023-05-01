using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WP13_miniproject.Logics;
using WP13_miniproject.ViewModels;
using WP13_miniproject.Models;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace WP13_miniproject.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        static string railopristtcd = string.Empty;
        static string lncd = string.Empty;
        static string stincd = string.Empty;

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
            string RailOprLittNm_query = $@"SELECT rail_opr_istt_cd AS RailOprLittCd,
	                                                       rail_opr_istt_nm AS RailOprLittNm
                                                      FROM stationinfo
                                                     GROUP BY rail_opr_istt_cd,
	                                                       rail_opr_istt_nm";
            try
            {
                if (CboRailOprLittNm != null)
                {
                    CboDataLoad(RailOprLittNm_query, "RailOprLittNm", CboRailOprLittNm);
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 불러오기 오류! {ex.Message}");
            }

            string R_L_S_Infomation_Query = $@"SELECT rail_opr_istt_cd, ln_cd, stin_cd
                                                 FROM miniproject.stationinfo
                                                WHERE idx";

            string R_L_S_Make_Query = $@"SELECT rail_opr_istt_cd, ln_cd, stin_cd
                                               FROM miniproject.stationinfo
                                              WHERE rail_opr_istt_nm = '{CboRailOprLittNm.SelectedItem}'
                                                AND ln_nm = '{CboLnNm.SelectedItem}'
                                                AND stin_nm = '{CboStinNm.SelectedItem}'";

            string Data_Insert_Query = $@"INSERT INTO miniproject.toiletinfo
                                               ( idx
	                                           , railopristtcd
	                                           , diapexchnum
	                                           , dtlloc
	                                           , exitno
	                                           , gateinotdvnm
	                                           , grnddvnm
	                                           , mlFmldvnm
	                                           , stincd
	                                           , stinflor
	                                           , toltnum)
                                          VALUES
	                                           ( idx
	                                           , railopristtcd
	                                           , diapexchnum
	                                           , dtlloc
	                                           , exitno
	                                           , gateinotdvnm
	                                           , grnddvnm
	                                           , mlFmldvnm
	                                           , stincd
	                                           , stinflor
	                                           , toltnum);";

        }
        private async void CboRailOprLittNm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CboRailOprLittNm.SelectedItem != null)
                {
                    string CboRailOprLittNmSelected_Query = $@"SELECT DISTINCT ln_nm AS Ln_Nm
                                                             FROM miniproject.stationinfo
                                                            WHERE rail_opr_istt_nm  = '{CboRailOprLittNm.SelectedItem}'";
                    CboDataLoad(CboRailOprLittNmSelected_Query, "Ln_Nm", CboLnNm);
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 오류 : \n{ex.Message}");
            }

        }
        private async void CboLnNm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string CboLnNmSelected_Query = $@"SELECT Stin_Nm
                                                FROM (
	                                          SELECT DISTINCT ln_nm AS Ln_Nm
		                                           , stin_nm AS Stin_Nm
	                                            FROM miniproject.stationinfo
	                                           WHERE rail_opr_istt_nm  = '{CboRailOprLittNm.SelectedItem}' 
                                                   ) AS L_N
                                               WHERE Ln_Nm  = '{CboLnNm.SelectedItem}' ";
            try
            {
                if (CboRailOprLittNm.SelectedItem != null)
                {
                    CboDataLoad(CboLnNmSelected_Query, "Stin_Nm", CboStinNm);
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 오류 : \n{ex.Message}");
            }

        }
        private async void CboStinNm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string BtnSearchClick_Query = $@"SELECT rail_opr_istt_cd, ln_cd, stin_cd
                                               FROM miniproject.stationinfo
                                              WHERE rail_opr_istt_nm = '{CboRailOprLittNm.SelectedItem}'
                                                AND ln_nm = '{CboLnNm.SelectedItem}'
                                                AND stin_nm = '{CboStinNm.SelectedItem}'";

                using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                    MySqlCommand cmd = new MySqlCommand(BtnSearchClick_Query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "stationinfo");
                    List<string> stationinfo = new List<string>();
                    foreach (DataRow row in ds.Tables["stationinfo"].Rows)
                    {
                        railopristtcd = Convert.ToString(row[0]);
                        lncd = Convert.ToString(row[1]);
                        stincd = Convert.ToString(row[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"DB 오류 : \n{ex.Message}");
            }
        }
        // 버튼 클릭하면 해당하는 역 
        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            #region < 키워드 불러와서 API 호출 >
            string BtnSearchClick_Query = $@"SELECT rail_opr_istt_cd, ln_cd, stin_cd
                                               FROM miniproject.stationinfo
                                              WHERE rail_opr_istt_nm = '{CboRailOprLittNm.SelectedItem}'
                                                AND ln_nm = '{CboLnNm.SelectedItem}'
                                                AND stin_nm = '{CboStinNm.SelectedItem}'";

            using (MySqlConnection conn = new MySqlConnection(Commons.myConnString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new MySqlCommand(BtnSearchClick_Query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "stationinfo");
                List<string> stationinfo = new List<string>();

                foreach (DataRow row in ds.Tables["stationinfo"].Rows)
                {
                    railopristtcd = Convert.ToString(row[0]);
                    lncd = Convert.ToString(row[1]);
                    stincd = Convert.ToString(row[2]);
                }
            }
            string openApiUri = $@"https://openapi.kric.go.kr/openapi/vulnerableUserInfo/stationDisabledToilet?serviceKey=$2a$10$b3nGLYZFskgcY57.27bB9O1yMM9R8cCGjFfAQgbCaUo2GXUc9RKvS&format=json&railOprIsttCd={railopristtcd}&lnCd={lncd}&stinCd={stincd}";
            string result = string.Empty;

            // WebRequest, WebResponse 객체
            WebRequest req = null;
            WebResponse res = null;
            StreamReader reader = null;

            try
            {
                req = WebRequest.Create(openApiUri);
                res = await req.GetResponseAsync();
                reader = new StreamReader(res.GetResponseStream());
                result = reader.ReadToEnd();

                Debug.WriteLine(result);
            }

            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"OpenAPI 조회오류 {ex.Message}");
            }

            var jsonResult = JObject.Parse(result);
            var resultCnt = Convert.ToInt32(jsonResult["header"]["resultCnt"]);

            try
            {
                if (resultCnt == 1) // 정상이면 데이터받아서 처리
                {
                    var data = jsonResult["body"];
                    var json_array = data as JArray;

                    var toiletInfo = new List<ToiletInfo>();
                    foreach (var toilet in json_array)
                    {
                        toiletInfo.Add(new ToiletInfo
                        {
                            // idx, railopristtcd, diapexchnum, dtlloc, exitno, gateinotdvnm, grnddvnm, mlFmldvnm, stincd, stinflor, toltnum
                            idx = Convert.ToInt32(toilet["idx"]),
                            //railOprIsttCd = Convert.ToString(toilet["railOprIsttCd"]),
                            diapExchNum = Convert.ToString(toilet["diapExchNum"]),
                            //lnCd = Convert.ToString(toilet["lnCd"]),
                            //stinCd = Convert.ToString(toilet["stinCd"]),
                            grndDvNm = Convert.ToString(toilet["grndDvNm"]),
                            stinFlor = Convert.ToString(toilet["stinFlor"]),
                            gateInotDvNm = Convert.ToString(toilet["gateInotDvNm"]),
                            exitNo = Convert.ToString(toilet["exitNo"]),
                            dtlLoc = Convert.ToString(toilet["dtlLoc"]),
                            mlFmlDvNm = Convert.ToString(toilet["mlFmlDvNm"]),
                            toltNum = Convert.ToString(toilet["toltNum"]),
                        });

                        this.DataContext = toiletInfo;
                    }
                }
                else
                {
                    this.DataContext = null;
                    await Commons.ShowMessageAsync("오류", "API 오류 : 조회된 장애인 화장실 정보가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                await Commons.ShowMessageAsync("오류", $"JSON 처리오류 {ex.Message}");
            }
            #endregion

            MapBrowser.Address = "https://map.naver.com/v5/search/" + $"{CboStinNm.SelectedItem}역?c=18,0,0,0,dh";
        }
    }
}


