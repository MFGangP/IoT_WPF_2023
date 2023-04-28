using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP13_miniproject.Models
{
    internal class ToiletInfo
    {
        /* 역사별 장애인 화장실 위치
        <body>
            <item>
                <railOprIsttCd>BS</railOprIsttCd> 
                <lnCd>1</lnCd>
                <stinCd>101</stinCd>
                <grndDvNm>지하</grndDvNm>
                <stinFlor>1</stinFlor>
                <gateInotDvNm>외</gateInotDvNm>
                <exitNo>3,4,5</exitNo>
                <dtlLoc>(B1) 3,4,5 번 출입구 내려오는 방향</dtlLoc>
                <mlFmlDvNm>남자</mlFmlDvNm>
                <toltNum/>
                <diapExchNum/>
            </item>
        </body>
        */

        public int idx { get; set; }
        public string railopristtcd { get ; set; }
        public string diapexchnum { get; set;}
        public string dtlloc { get; set;}
        public string exitno { get; set;}
        public string gateinotdvnm { get; set;}
        public string grnddvnm { get; set;}
        public string mlFmldvnm { get; set;}
        public string stincd { get; set;}
        public string stinflor { get; set;}
        public string toltnum { get; set;}
    }
}
