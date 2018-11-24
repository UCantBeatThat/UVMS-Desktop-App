CREATE DATABASE `uvds_schemas` /*!40100 DEFAULT CHARACTER SET utf8 */;

CREATE TABLE `customer` (
  `C_ID` varchar(10) NOT NULL,
  `F_NAME` varchar(15) DEFAULT NULL,
  `L_NAME` varchar(15) DEFAULT NULL,
  `PHONE` varchar(10) DEFAULT NULL,
  `ADDRESS` varchar(50) DEFAULT NULL,
  `DOB` date DEFAULT NULL,
  `GENDER` varchar(1) DEFAULT NULL,
  `PASSWORD` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`C_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `manager` (
  `MAN_ID` varchar(10) NOT NULL,
  `F_NAME` varchar(15) DEFAULT NULL,
  `L_NAME` varchar(15) DEFAULT NULL,
  `PHONE` char(10) DEFAULT NULL,
  `ADDRESS` varchar(40) DEFAULT NULL,
  `SALARY` decimal(7,2) DEFAULT NULL,
  `AGE` date DEFAULT NULL,
  `GENDER` varchar(1) DEFAULT NULL,
  `PASSWORD` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`MAN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `order_in` (
  `ORDER_NO` varchar(10) DEFAULT NULL,
  `O_DATE` date DEFAULT NULL,
  `O_AMNT` decimal(8,2) DEFAULT NULL,
  `REG_NO` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ORDER_NO`),
  KEY `REG_NO` (`REG_NO`),
  CONSTRAINT `order_in_ibfk_1` FOREIGN KEY (`REG_NO`) REFERENCES `vehicle` (`REG_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8


CREATE TABLE `order_out` (
  `REG_NO` varchar(10) DEFAULT NULL,
  `ORDER_NO` varchar(10) DEFAULT NULL,
  `O_DATE` date DEFAULT NULL,
  `C_ID` varchar(10) DEFAULT NULL,
  `O_AMT` decimal(8,2) DEFAULT NULL,
  `REQ_DATE` date DEFAULT NULL,
  `SHIP_DATE` date DEFAULT NULL,
  PRIMARY KEY (`ORDER_NO`),
  KEY `REG_NO` (`REG_NO`),
  KEY `C_ID` (`C_ID`),
  CONSTRAINT `order_out_ibfk_1` FOREIGN KEY (`REG_NO`) REFERENCES `vehicle` (`REG_NO`),
  CONSTRAINT `order_out_ibfk_2` FOREIGN KEY (`C_ID`) REFERENCES `customer` (`C_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `worker` (
  `WORK_ID` varchar(10) NOT NULL,
  `F_NAME` varchar(15) DEFAULT NULL,
  `L_NAME` varchar(15) DEFAULT NULL,
  `PHONE` varchar(15) DEFAULT NULL,
  `ADDRESS` varchar(50) DEFAULT NULL,
  `SALARY` decimal(8,2) DEFAULT NULL,
  `AGE` date DEFAULT NULL,
  `GENDER` varchar(1) DEFAULT NULL,
  `PASSWORD` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`WORK_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `owns` (
  `C_ID` varchar(10) NOT NULL,
  `REG_NO` varchar(10) NOT NULL,
  PRIMARY KEY (`C_ID`,`REG_NO`),
  KEY `REG_NO` (`REG_NO`),
  CONSTRAINT `owns_ibfk_1` FOREIGN KEY (`C_ID`) REFERENCES `customer` (`C_ID`),
  CONSTRAINT `owns_ibfk_2` FOREIGN KEY (`REG_NO`) REFERENCES `vehicle` (`REG_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `vehicle` (
  `REG_NO` varchar(10) NOT NULL,
  `COST` decimal(8,2) DEFAULT NULL,
  `COND` varchar(20) DEFAULT NULL,
  `MODEL` varchar(20) DEFAULT NULL,
  `COMPANY` varchar(20) DEFAULT NULL,
  `DRIVEN_KM` int(11) DEFAULT NULL,
  `YEAR` int(11) DEFAULT NULL,
  `TYPE` varchar(20) DEFAULT NULL,
  `STATUS` varchar(10) DEFAULT 'Unsold',
  PRIMARY KEY (`REG_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `schematable` (
  `schemaname` varchar(20) NOT NULL,
  PRIMARY KEY (`schemaname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8


