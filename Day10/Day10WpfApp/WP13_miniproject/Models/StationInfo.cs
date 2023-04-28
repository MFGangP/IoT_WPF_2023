using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP13_miniproject.Models
{
    internal class StationInfo
    {
        // 운영기관, 노선, 역 코드정보 리스트(2023.02.22) csv 파일 업로드
        public int idx { get; set; }
        public string rail_opr_istt_cd { get; set; }
        public string rail_opr_istt_nm { get; set; }
        public string ln_cd { get; set; }
        public string ln_nm { get; set; }
        public string stin_cd { get; set; }
        public string stin_nm { get; set; }
    }
}
