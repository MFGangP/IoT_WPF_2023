using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP13_miniproject.Models
{
    public class ToiletInfo
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
        public string railOprIsttCd { get ; set; }
        public string lnCd { get; set;}
        public string stinCd { get; set;}
        public string grndDvNm { get; set;}
        public string stinFlor { get; set;}
        public string gateInotDvNm { get; set;}
        public string exitNo { get; set;}
        public string dtlLoc { get; set;}
        public string mlFmlDvNm { get; set;}
        public string toltNum { get; set;}
        public string diapExchNum { get; set; }

    }
}
