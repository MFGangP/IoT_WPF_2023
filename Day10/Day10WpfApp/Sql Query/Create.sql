CREATE TABLE `stationinfo` (
  `idx` int NOT NULL AUTO_INCREMENT,
  `rail_opr_istt_cd` varchar(5) NOT NULL,
  `rail_opr_istt_nm` varchar(20) NOT NULL,
  `ln_cd` varchar(5) NOT NULL,
  `ln_nm` varchar(10) NOT NULL,
  `stin_cd` varchar(10) NOT NULL,
  `stin_nm` varchar(20) NOT NULL,
  PRIMARY KEY (`idx`)
)

CREATE TABLE `toiletinfo` (
  `idx` int NOT NULL AUTO_INCREMENT,
  `railopristtcd` varchar(10) DEFAULT NULL,
  `diapexchnum` varchar(40) DEFAULT NULL,
  `dtlloc` varchar(100) DEFAULT NULL,
  `exitno` varchar(20) DEFAULT NULL,
  `gateinotdvnm` varchar(40) DEFAULT NULL,
  `grnddvnm` varchar(40) DEFAULT NULL,
  `mlFmldvnm` varchar(40) DEFAULT NULL,
  `stincd` varchar(40) DEFAULT NULL,
  `stinflor` varchar(40) DEFAULT NULL,
  `toltnum` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`idx`)
)

