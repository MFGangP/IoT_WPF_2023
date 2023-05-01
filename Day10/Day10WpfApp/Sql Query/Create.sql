CREATE TABLE `stationinfo` (
  `idx` int NOT NULL AUTO_INCREMENT,
  `rail_opr_istt_cd` varchar(5) NOT NULL,
  `rail_opr_istt_nm` varchar(20) NOT NULL,
  `ln_cd` varchar(5) NOT NULL,
  `ln_nm` varchar(10) NOT NULL,
  `stin_cd` varchar(10) NOT NULL,
  `stin_nm` varchar(20) NOT NULL,
  PRIMARY KEY (`idx`)
);

CREATE TABLE `toiletinfo` (
  `idx` int NOT NULL AUTO_INCREMENT,
  `railOprIsttCd` varchar(10) DEFAULT NULL,
  `lnCd` varchar(10) DEFAULT NULL,
  `stinCd` varchar(10) DEFAULT NULL,
  `grndDvNm` varchar(20) DEFAULT NULL,
  `stinFlor` varchar(5) DEFAULT NULL,
  `gateInotDvNm` varchar(10) DEFAULT NULL,
  `exitNo` varchar(20) DEFAULT NULL,
  `dtlLoc` varchar(10) DEFAULT NULL,
  `mlFmlDvNm` varchar(10) DEFAULT NULL,
  `toltNum` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`idx`)
);

