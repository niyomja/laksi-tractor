# Host: 192.168.1.40  (Version: 5.6.26-log)
# Date: 2015-08-22 13:32:11
# Generator: MySQL-Front 5.3  (Build 4.175)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "tk_brand"
#

DROP TABLE IF EXISTS `tk_brand`;
CREATE TABLE `tk_brand` (
  `brandId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brandname` varchar(200) NOT NULL DEFAULT '',
  `description` text,
  `create_at` varchar(20) NOT NULL DEFAULT '0000-00-00 00:00:00',
  `update_at` varchar(20) NOT NULL DEFAULT '0000-00-00 00:00:00',
  `create_by` int(11) unsigned NOT NULL DEFAULT '0',
  `update_by` int(11) unsigned DEFAULT NULL,
  `is_delete` int(1) unsigned NOT NULL DEFAULT '0',
  `status` int(1) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`brandId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

#
# Data for table "tk_brand"
#

INSERT INTO `tk_brand` VALUES (1,'Komatsu','Komatsu 55','2015-08-15 11:09:25','0000-00-00 00:00:00',1,NULL,0,1),(2,'CAT','CAT','2015-08-15 11:10:03','0000-00-00 00:00:00',1,NULL,0,1),(3,'Kobelco','','2015-08-17 13:52:29','0000-00-00 00:00:00',8,NULL,0,1),(4,'Bearing','Bearing','2015-08-17 13:58:19','0000-00-00 00:00:00',8,NULL,0,1);

#
# Structure for table "tk_company"
#

DROP TABLE IF EXISTS `tk_company`;
CREATE TABLE `tk_company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `companyName` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `locationG` varchar(20) DEFAULT '',
  `locationIM` varchar(20) DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for table "tk_company"
#

INSERT INTO `tk_company` VALUES (1,'หจก. หลักสี่แทรคเตอร์','จำหน่ายอะไหล่ แทรคเตอร์ อื่นๆ','3B5','2A6');

#
# Structure for table "tk_customer"
#

DROP TABLE IF EXISTS `tk_customer`;
CREATE TABLE `tk_customer` (
  `customerId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `customerName` varchar(200) NOT NULL DEFAULT '',
  `contact` text,
  `create_by` int(11) unsigned NOT NULL DEFAULT '0',
  `create_at` varchar(20) NOT NULL DEFAULT '',
  `update_by` int(11) unsigned DEFAULT NULL,
  `update_at` varchar(20) DEFAULT NULL,
  `is_delete` int(1) unsigned NOT NULL DEFAULT '0',
  `address` text,
  `fax` varchar(20) DEFAULT NULL,
  `tax_no` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`customerId`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8;

#
# Data for table "tk_customer"
#

INSERT INTO `tk_customer` VALUES (1,'BMW','02000',1,'2015-08-15 11:25:19',8,'2015-08-17 12:10:15',1,NULL,NULL,NULL),(2,'ES Motor',NULL,1,'2015-08-15 11:25:44',8,'2015-08-17 12:10:26',1,NULL,NULL,NULL),(3,'BMC',NULL,1,'2015-08-15 11:25:56',8,'2015-08-17 12:10:30',1,NULL,NULL,NULL),(4,'ถาวร',NULL,1,'2015-08-15 11:26:03',8,'2015-08-17 12:10:35',1,NULL,NULL,NULL),(5,'ไทยนคร',NULL,1,'2015-08-15 11:26:07',8,'2015-08-17 12:10:41',1,NULL,NULL,NULL),(6,'กษิดิศ บจก.',NULL,8,'2015-08-17 12:29:06',8,'2015-08-17 12:57:43',1,NULL,NULL,NULL),(7,'กิตติรัชต์',NULL,8,'2015-08-17 12:29:25',8,'2015-08-17 12:57:37',1,NULL,NULL,NULL),(8,'ม.เกษตรศาสตร์','02xxxx',8,'2015-08-17 12:29:41',1,'2015-08-21 12:16:54',0,'ที่อยู่','02xxx','xxxxxx'),(9,'ก้องเกียรติ เกตุสมบัติ(โอ)',NULL,8,'2015-08-17 12:31:19',NULL,NULL,0,NULL,NULL,NULL),(10,'เจนเนอรอลโลจิสติกส์ บจก.',NULL,8,'2015-08-17 12:32:12',8,'2015-08-17 12:57:29',1,NULL,NULL,NULL),(11,'ไชน่าสเตท คอนสตรัคชั่น เอ็นจิเนียริ่ง บจก.',NULL,8,'2015-08-17 12:33:05',NULL,NULL,0,NULL,NULL,NULL),(12,'ไชนีสคอนกรีตปั้ม บจก.',NULL,8,'2015-08-17 12:33:43',NULL,NULL,0,NULL,NULL,NULL),(13,'ชาญนครวิศวกรรม',NULL,8,'2015-08-17 12:34:02',NULL,NULL,0,NULL,NULL,NULL),(14,'ซี.เอส.มอเตอร์ พาร์ท แอนด์ เซอร์วิส บจก.',NULL,8,'2015-08-17 12:35:01',NULL,NULL,0,NULL,NULL,NULL),(15,'ซี.วี.แอล',NULL,8,'2015-08-17 12:35:24',8,'2015-08-17 12:57:20',1,NULL,NULL,NULL),(16,'ดอนเมืองแทรคเตอร์ หจก.',NULL,8,'2015-08-17 12:35:48',8,'2015-08-17 12:57:12',1,NULL,NULL,NULL),(17,'ทวีศักดิ์แทรคเตอร์ หจก.',NULL,8,'2015-08-17 12:36:16',NULL,NULL,0,NULL,NULL,NULL),(18,'ธนภูมิ แทรคเตอร์',NULL,8,'2015-08-17 12:37:06',NULL,NULL,0,NULL,NULL,NULL),(19,'ธนบดีศิลา หจก.',NULL,8,'2015-08-17 12:37:28',8,'2015-08-17 12:57:05',1,NULL,NULL,NULL),(20,'คุณนุยุทธ์ พัฒนาวงค์ (โกเหนียว)',NULL,8,'2015-08-17 12:38:55',NULL,NULL,0,NULL,NULL,NULL),(21,'นภาพล หจก.',NULL,8,'2015-08-17 12:39:10',NULL,NULL,0,NULL,NULL,NULL),(22,'น้ำตาลบ้านโป่ง บจก.',NULL,8,'2015-08-17 12:39:34',NULL,NULL,0,NULL,NULL,NULL),(23,'น้ำตาลนครเพชร บจก.',NULL,8,'2015-08-17 12:40:04',8,'2015-08-17 12:56:49',1,NULL,NULL,NULL),(24,'บริหารและพัฒนาเพื่ออนุรักษ์ฯ บจก.',NULL,8,'2015-08-17 12:43:11',8,'2015-08-17 12:56:43',1,NULL,NULL,NULL),(25,'บางกอกโคมัตสุเซลส์ บจก. (BKS)','',8,'2015-08-17 12:43:53',8,'2015-08-17 13:27:11',0,NULL,NULL,NULL),(26,'บางกอกโคมัตสุ ฟอร์คลิฟท์ บจก.',NULL,8,'2015-08-17 12:44:36',8,'2015-08-17 12:56:34',1,NULL,NULL,NULL),(27,'บูรพาอุตสาหกรรม บจก.',NULL,8,'2015-08-17 12:45:19',NULL,NULL,0,NULL,NULL,NULL),(28,'บางกอกไทยแทรคเตอร์ (กรุงไทยกลการ)',NULL,8,'2015-08-17 12:45:56',NULL,NULL,0,NULL,NULL,NULL),(29,'กำนัน บุญเรือง ชั่งสี',NULL,8,'2015-08-17 12:46:24',8,'2015-08-17 12:56:19',1,NULL,NULL,NULL),(30,'ปอนด์ (อู่ เบนซ์)',NULL,8,'2015-08-17 12:46:54',8,'2015-08-17 12:56:10',1,NULL,NULL,NULL),(31,'ประโยชน์การโยธา',NULL,8,'2015-08-17 12:47:10',NULL,NULL,0,NULL,NULL,NULL),(32,'พี แอนด์ เอส โรด คอนสตรัคชั่น บจก.',NULL,8,'2015-08-17 12:47:42',NULL,NULL,0,NULL,NULL,NULL),(33,'พารากอน แมซีนเนอร์ บจก.',NULL,8,'2015-08-17 12:48:23',8,'2015-08-17 12:56:02',1,NULL,NULL,NULL),(34,'พิพัฒน์อะไหล่ยนต์',NULL,8,'2015-08-17 12:48:52',NULL,NULL,0,NULL,NULL,NULL),(35,'บุ้งแทรคเตอร์',NULL,8,'2015-08-17 12:49:16',8,'2015-08-17 12:55:53',1,NULL,NULL,NULL),(36,'มหาจักรทรัค',NULL,8,'2015-08-17 12:49:31',NULL,NULL,0,NULL,NULL,NULL),(37,'ครูมล (นครศรีธรรมราช)',NULL,8,'2015-08-17 12:49:55',NULL,NULL,0,NULL,NULL,NULL),(38,'คุณมานะ',NULL,8,'2015-08-17 12:50:09',NULL,NULL,0,NULL,NULL,NULL),(39,'ยนต์ประทีป เอ็นจีเนียริ่ง บจก.',NULL,8,'2015-08-17 12:50:37',8,'2015-08-17 12:55:45',1,NULL,NULL,NULL),(40,'ระยองซิลิก้าอินดัสตรี บจก.',NULL,8,'2015-08-17 12:51:11',NULL,NULL,0,NULL,NULL,NULL),(41,'วัฒนะแทรคเตอร์ หจก.',NULL,8,'2015-08-17 12:51:32',NULL,NULL,0,NULL,NULL,NULL),(42,'วี.เอ็น.มอเตอร์',NULL,8,'2015-08-17 12:51:57',NULL,NULL,0,NULL,NULL,NULL),(43,'วิทัย ไบโอเพาเวอร์ บจก.',NULL,8,'2015-08-17 12:52:23',NULL,NULL,0,NULL,NULL,NULL),(44,'วรกิจ(เจ้รถเครน)',NULL,8,'2015-08-17 12:53:15',NULL,NULL,0,NULL,NULL,NULL),(45,'สยามแทรค (SYT)',NULL,8,'2015-08-17 12:58:26',NULL,NULL,0,NULL,NULL,NULL),(46,'สินสยามแทรคเตอร์ บจก.',NULL,8,'2015-08-17 12:58:57',NULL,NULL,0,NULL,NULL,NULL),(47,'ส่งเสริมแทรคเตอร์ (บางกอกปทุม ,S,SMT)','',8,'2015-08-17 13:00:01',8,'2015-08-17 13:49:00',0,NULL,NULL,NULL),(48,'สยามทรีดีเวลลอปเม้นต์ บจก.',NULL,8,'2015-08-17 13:11:14',NULL,NULL,0,NULL,NULL,NULL),(49,'สหพันธ์ปิโตรเลียม บจก.',NULL,8,'2015-08-17 13:12:10',NULL,NULL,0,NULL,NULL,NULL),(50,'สมบุญ คุณโฑ',NULL,8,'2015-08-17 13:12:38',NULL,NULL,0,NULL,NULL,NULL),(51,'ใหญ่ หนองแซง',NULL,8,'2015-08-17 13:12:53',NULL,NULL,0,NULL,NULL,NULL),(52,'เอ็ม.ที.กรุ๊ป การโยธา บจก.',NULL,8,'2015-08-17 13:13:34',NULL,NULL,0,NULL,NULL,NULL),(53,'อังเชิดไทย',NULL,8,'2015-08-17 13:13:58',NULL,NULL,0,NULL,NULL,NULL),(54,'เค.ที อินเตอร์กร๊ป',NULL,8,'2015-08-17 13:14:38',NULL,NULL,0,NULL,NULL,NULL),(55,'เจ-เทค ออโต้ พาร์ท บจก.',NULL,8,'2015-08-17 13:15:21',NULL,NULL,0,NULL,NULL,NULL),(56,'ซี.วี.แอล',NULL,8,'2015-08-17 13:16:25',NULL,NULL,0,NULL,NULL,NULL),(57,'เซเว่น อินดัสเตรียล',NULL,8,'2015-08-17 13:16:59',NULL,NULL,0,NULL,NULL,NULL),(58,'ซี.เอส.มอเตอร์',NULL,8,'2015-08-17 13:17:47',NULL,NULL,0,NULL,NULL,NULL),(59,'ซีดี กร๊ป (บจก.สหการอินเตอร์เทรด) (CD)',NULL,8,'2015-08-17 13:18:34',NULL,NULL,0,NULL,NULL,NULL),(60,'ชันเวย์ มาร์เก็ตติ้ง (ประเทศไทย)',NULL,8,'2015-08-17 13:19:30',NULL,NULL,0,NULL,NULL,NULL),(61,'ตากสิน เทรดดิ้ง',NULL,8,'2015-08-17 13:20:27',NULL,NULL,0,NULL,NULL,NULL),(62,'ถาวรแทรคเตอร์เอ็นจิเนียริ่ง',NULL,8,'2015-08-17 13:21:15',NULL,NULL,0,NULL,NULL,NULL),(63,'ถาวรแทรคเตอร์แมชชีนเนอรี',NULL,8,'2015-08-17 13:22:46',NULL,NULL,0,NULL,NULL,NULL),(64,'ทวีศักดิ์แทรคเตอร์',NULL,8,'2015-08-17 13:23:13',NULL,NULL,0,NULL,NULL,NULL),(65,'ไทยธนากร','',8,'2015-08-17 13:23:30',8,'2015-08-17 13:23:37',0,NULL,NULL,NULL),(66,'ไทยแสงเจริญไดนาโม',NULL,8,'2015-08-17 13:25:11',NULL,NULL,0,NULL,NULL,NULL),(67,'แทรคอีควิปเมนท์',NULL,8,'2015-08-17 13:25:52',NULL,NULL,0,NULL,NULL,NULL),(68,'บางชันแทรคเตอร์','',8,'2015-08-17 13:29:01',8,'2015-08-17 13:29:12',0,NULL,NULL,NULL),(69,'บิสเอเชียอุตสาหกรรมเครื่องมือกล',NULL,8,'2015-08-17 13:29:56',NULL,NULL,0,NULL,NULL,NULL),(70,'ป.ไพศาล',NULL,8,'2015-08-17 13:30:16',NULL,NULL,0,NULL,NULL,NULL),(71,'บ.พี.พี.แอ็น เอ็กซ์เพิรท',NULL,8,'2015-08-17 13:35:35',NULL,NULL,0,NULL,NULL,NULL),(72,'มหกิจแทรคเตอร์',NULL,8,'2015-08-17 13:36:04',NULL,NULL,0,NULL,NULL,NULL),(73,'มีนทองซัพพลาย',NULL,8,'2015-08-17 13:36:37',NULL,NULL,0,NULL,NULL,NULL),(74,'ยิ่งยงกลการ',NULL,8,'2015-08-17 13:37:30',NULL,NULL,0,NULL,NULL,NULL),(75,'รอยัลเอ็นจิเนียริ่ง',NULL,8,'2015-08-17 13:38:10',NULL,NULL,0,NULL,NULL,NULL),(76,'สหยนต์วัฒนา',NULL,8,'2015-08-17 13:38:53',NULL,NULL,0,NULL,NULL,NULL),(77,'สหรุ่งเรืองอะไหล่',NULL,8,'2015-08-17 13:39:30',NULL,NULL,0,NULL,NULL,NULL),(78,'แสงอุดมอิควิปเมนท์ (SUD)',NULL,8,'2015-08-17 13:40:37',NULL,NULL,0,NULL,NULL,NULL),(79,'สุริยะยนต์ เอ็นเตอร์ไพรส์',NULL,8,'2015-08-17 13:41:20',NULL,NULL,0,NULL,NULL,NULL),(80,'สหะสินอีควิปเมนท์',NULL,8,'2015-08-17 13:41:56',NULL,NULL,0,NULL,NULL,NULL),(81,'เอ็ม.เอ็นแมชชีนเนอร์',NULL,8,'2015-08-17 13:42:47',NULL,NULL,0,NULL,NULL,NULL),(82,'อุ้ย ชัย มี',NULL,8,'2015-08-17 13:43:05',NULL,NULL,0,NULL,NULL,NULL),(83,'อาร์.พี.เอ็นอีควิปเมนท์',NULL,8,'2015-08-17 13:44:03',NULL,NULL,0,NULL,NULL,NULL),(84,'เอส.วี.เอ็นจิเนียริ่ง',NULL,8,'2015-08-17 13:44:32',NULL,NULL,0,NULL,NULL,NULL),(85,'ออโต้ แอนต์ แทรกเตอร์',NULL,8,'2015-08-17 13:44:59',NULL,NULL,0,NULL,NULL,NULL),(86,'ออโต้โปร อินเตอร์แทรด',NULL,8,'2015-08-17 13:45:26',NULL,NULL,0,NULL,NULL,NULL),(87,'เอส.ที โปรดักส์ทีฟ',NULL,8,'2015-08-17 13:45:54',NULL,NULL,0,NULL,NULL,NULL),(88,'L.N.H',NULL,8,'2015-08-17 13:46:09',NULL,NULL,0,NULL,NULL,NULL),(89,'เอส.เค.ที แทรคเตอร์',NULL,8,'2015-08-17 13:46:39',NULL,NULL,0,NULL,NULL,NULL),(90,'เฮช.ที.ผิวโลหะกรรม',NULL,8,'2015-08-17 13:47:09',NULL,NULL,0,NULL,NULL,NULL),(91,'กิ่งแก้ว(KK)',NULL,8,'2015-08-17 13:47:31',NULL,NULL,0,NULL,NULL,NULL),(92,'ธนกิจ',NULL,8,'2015-08-17 13:48:01',NULL,NULL,0,NULL,NULL,NULL);

#
# Structure for table "tk_part"
#

DROP TABLE IF EXISTS `tk_part`;
CREATE TABLE `tk_part` (
  `partId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `brandId` int(11) unsigned NOT NULL DEFAULT '0',
  `partno` varchar(20) NOT NULL DEFAULT '',
  `partname` varchar(200) NOT NULL DEFAULT '',
  `model` varchar(200) DEFAULT NULL,
  `gsp` decimal(10,2) DEFAULT NULL,
  `imsp` decimal(10,2) DEFAULT NULL,
  `is_delete` int(1) unsigned NOT NULL DEFAULT '0',
  `create_by` int(11) unsigned NOT NULL DEFAULT '0',
  `create_at` varchar(20) NOT NULL DEFAULT '',
  `update_by` int(11) unsigned DEFAULT NULL,
  `update_at` varchar(20) DEFAULT NULL,
  `status` int(1) unsigned NOT NULL DEFAULT '0',
  `locG` varchar(20) DEFAULT NULL,
  `locIM` varchar(20) DEFAULT NULL,
  `comment` text,
  PRIMARY KEY (`partId`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

#
# Data for table "tk_part"
#

INSERT INTO `tk_part` VALUES (1,1,'01010-30855','Bolt','',0.00,0.00,0,9,'2015-08-22 10:11:48',9,'2015-08-22 11:26:16',1,'','','check 17/10/43'),(2,1,'01010-60825','Bolt','',29.10,0.00,0,9,'2015-08-22 10:26:34',9,'2015-08-22 11:28:11',1,' ','',''),(3,1,'01010-61685','Bolt','',254.00,0.00,0,9,'2015-08-22 10:46:24',9,'2015-08-22 11:28:50',1,'3C-3','','check 26/10/43'),(4,1,'01010-31030','Bolt','',0.00,6.95,0,9,'2015-08-22 10:48:01',9,'2015-08-22 11:25:49',1,'','',''),(5,4,'1111','test','test',10.01,11.09,1,1,'2015-08-22 10:53:13',1,'2015-08-22 11:24:42',1,'','',''),(6,1,'01010-31035','Bolt','',0.00,7.81,0,9,'2015-08-22 10:58:57',9,'2015-08-22 11:46:06',1,'','',' '),(7,1,'01010-31235','Bolt','',0.00,0.00,1,9,'2015-08-22 11:03:39',9,'2015-08-22 11:04:21',1,'','','see 01010-31035'),(8,1,'01010-31055','Bolt','',0.00,0.00,0,9,'2015-08-22 11:05:18',9,'2015-08-22 11:32:29',1,'C3-16','',''),(9,1,'01010-31485','Bolt','PC300',26.75,0.00,0,9,'2015-08-22 11:06:13',9,'2015-08-22 11:35:17',1,'','',''),(10,1,'01010-62080','Bolt','',68.00,0.00,0,9,'2015-08-22 11:08:34',9,'2015-08-22 11:36:52',1,'J2','',''),(11,1,'01011-32015','Bolt','',186.00,0.00,0,9,'2015-08-22 11:10:08',9,'2015-08-22 11:37:49',1,'D5 กล่องกระดาษ','','check 13/10/43'),(12,1,'01011-32030','Bolt',NULL,204.60,0.00,0,9,'2015-08-22 11:11:29',9,'2015-08-22 13:13:49',1,'D5-6','','check 13/10/2543'),(13,1,'01010-30830','Bolt','',0.00,7.43,0,9,'2015-08-22 11:14:47',9,'2015-08-22 11:40:10',1,'','',''),(14,1,'01011-31200','Bolt','',119.84,0.00,0,9,'2015-08-22 11:16:21',9,'2015-08-22 11:41:02',1,'D3-27','',''),(15,1,'01010-31235','Bolt+Nut','',0.00,10.70,0,9,'2015-08-22 11:19:47',9,'2015-08-22 11:48:11',1,'','','Sale -Bolt          = 18.-\r\n            Washer  =   6.-'),(16,4,'111','test','test',10.09,11.09,1,1,'2015-08-22 11:26:48',1,'2015-08-22 11:27:12',1,'11','11','11'),(17,1,'01010-31025','Bolt+Washer','',0.00,8.30,0,9,'2015-08-22 11:49:58',9,'2015-08-22 11:50:34',1,'','',''),(18,1,'01010-31045','Bolt','',0.00,4.49,0,9,'2015-08-22 11:53:02',9,'2015-08-22 11:53:24',1,'','',''),(19,1,'01010-31225','Bolt+Nut','',0.00,7.49,0,9,'2015-08-22 11:55:58',9,'2015-08-22 11:57:19',1,'','','Sale - Bolt         =   15.-\r\n             Washer =     6.-'),(20,1,'01010-31230','Bolt','',9.63,10.17,0,9,'2015-08-22 12:31:16',9,'2015-08-22 12:33:02',1,'','','G=เกลียวละเอียด\r\nOEM=เกลียวหยาบ'),(21,1,'01010-00820','Bolt+Washer','',0.00,3.65,0,9,'2015-08-22 12:35:17',9,'2015-08-22 12:35:33',1,'','',''),(22,1,'01010-31245','Bolt','',0.00,8.56,0,9,'2015-08-22 12:36:55',9,'2015-08-22 12:37:13',1,'','',''),(23,1,'01010-31250','Bolt','',8.10,0.00,0,9,'2015-08-22 12:38:03',9,'2015-08-22 12:38:16',1,'','',''),(24,1,'01010-31255','Bolt','',0.00,8.03,0,9,'2015-08-22 12:39:07',9,'2015-08-22 12:40:19',1,'','',''),(25,1,'01010-31260','Bolt','',0.00,5.50,0,9,'2015-08-22 12:42:23',9,'2015-08-22 12:42:42',1,'','D5',''),(26,1,'01010-31425','Bolt+Nut','',0.00,12.84,0,9,'2015-08-22 12:43:51',9,'2015-08-22 12:44:23',1,'','',''),(27,1,'01010-31430','Bolt+Nut','',0.00,16.32,0,9,'2015-08-22 12:45:33',9,'2015-08-22 12:45:59',1,'','',''),(28,1,'01010-31435','Bolt+Washer','',0.00,18.19,0,9,'2015-08-22 12:47:13',9,'2015-08-22 12:47:28',1,'','',''),(29,1,'01010-31440','Bolt+Nut','',0.00,16.05,0,9,'2015-08-22 12:48:36',9,'2015-08-22 12:48:51',1,'','',''),(30,1,'01010-31445','Bolt+Nut','',0.00,18.19,0,9,'2015-08-22 12:49:45',9,'2015-08-22 12:49:56',1,'','',''),(31,1,'01010-31450','Bolt','',0.00,20.33,0,9,'2015-08-22 12:51:27',9,'2015-08-22 12:52:05',1,'ก.8','',''),(32,1,'01010-31460','Bolt','',0.00,22.47,0,9,'2015-08-22 12:53:19',9,'2015-08-22 12:53:29',1,'','',''),(33,1,'01010-31640','Bolt+Washer','',0.00,19.96,0,9,'2015-08-22 12:54:10',9,'2015-08-22 13:02:57',1,'','','ที่ร้านมี 74 ตัว\r\nที่สโตร์มี 189 ตัว\r\nรวม 298 ตัว ณ.31/3/2551'),(34,1,'01010-31645','Bolt+Nut','',20.65,16.05,0,9,'2015-08-22 13:09:23',9,'2015-08-22 13:09:38',1,'','',''),(35,1,'01010-31650','Bolt+Nut','',0.00,21.40,0,9,'2015-08-22 13:10:47',9,'2015-08-22 13:11:15',1,'','',''),(36,1,'01010-61655','Bolt+Nut (5/8*5\")',NULL,0.00,21.40,0,9,'2015-08-22 13:13:38',9,'2015-08-22 13:18:16',1,'','',''),(37,1,'01010-31660','Bolt','',0.00,16.58,0,9,'2015-08-22 13:18:31',9,'2015-08-22 13:18:42',1,'','',''),(38,1,'01010-31665','Bolt','',0.00,16.00,0,9,'2015-08-22 13:19:18',9,'2015-08-22 13:19:28',1,'','',''),(39,1,'01010-31670','Bolt+Washer','',0.00,28.89,0,9,'2015-08-22 13:20:41',9,'2015-08-22 13:20:51',1,'','',''),(40,1,'01010-31680','Bolt+Nut','',0.00,31.03,0,9,'2015-08-22 13:24:11',9,'2015-08-22 13:25:34',1,'','',''),(41,1,'01010-31675','Bolt+Nut','',0.00,29.98,0,9,'2015-08-22 13:28:08',9,'2015-08-22 13:28:22',1,'','',''),(42,1,'01010-31840','Bolt','',0.00,31.03,0,9,'2015-08-22 13:30:19',9,'2015-08-22 13:30:33',1,'','',''),(43,1,'01010-31845','Bolt+Washer','',0.00,33.17,0,9,'2015-08-22 13:31:59',9,'2015-08-22 13:32:31',1,'','','');

#
# Structure for table "tk_part_inventory"
#

DROP TABLE IF EXISTS `tk_part_inventory`;
CREATE TABLE `tk_part_inventory` (
  `partInventoryId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `partId` int(11) unsigned NOT NULL DEFAULT '0',
  `regDate` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DOInvoiceNo` varchar(200) DEFAULT NULL,
  `customerId` int(11) unsigned DEFAULT NULL,
  `create_by` int(11) unsigned NOT NULL DEFAULT '0',
  `create_at` varchar(20) NOT NULL DEFAULT '',
  `update_by` int(11) unsigned DEFAULT NULL,
  `update_at` varchar(20) DEFAULT NULL,
  `is_delete` int(1) unsigned NOT NULL DEFAULT '0',
  `recd` int(11) NOT NULL DEFAULT '0',
  `lSold` int(11) NOT NULL DEFAULT '0',
  `gOnHand` int(11) NOT NULL DEFAULT '0',
  `price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `rSold` int(11) NOT NULL DEFAULT '0',
  `imOnHand` int(11) NOT NULL DEFAULT '0',
  `price2` decimal(10,2) NOT NULL DEFAULT '0.00',
  `totalAvailabel` int(11) NOT NULL DEFAULT '0',
  `totalDemand` int(11) NOT NULL DEFAULT '0',
  `detail` text,
  `oemRecd` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`partInventoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

#
# Data for table "tk_part_inventory"
#

INSERT INTO `tk_part_inventory` VALUES (1,2,'2015-08-22 10:41:03',' ',0,9,'2015-08-22 10:41:22',9,'2015-08-22 11:28:19',0,6,0,6,0.00,0,0,0.00,6,0,'',0),(2,3,'2015-08-22 10:47:06',' ',0,9,'2015-08-22 10:47:13',9,'2015-08-22 11:29:10',0,3,0,3,0.00,0,0,0.00,3,0,'',0),(3,4,'2015-08-22 10:51:51',' ',0,9,'2015-08-22 10:51:58',9,'2015-08-22 11:29:35',0,0,0,0,0.00,0,146,0.00,146,0,'',146),(4,5,'2015-08-22 10:53:08','test',44,1,'2015-08-22 10:53:22',1,'2015-08-22 11:25:54',1,1,1,0,29.01,0,0,20.90,0,1,'',0),(5,6,'2015-08-22 10:59:39',' ',0,9,'2015-08-22 10:59:42',9,'2015-08-22 11:30:42',0,0,0,0,0.00,0,76,22.00,76,0,'',76),(6,9,'2015-08-22 11:07:13',' ',0,9,'2015-08-22 11:07:18',9,'2015-08-22 11:36:22',0,176,0,176,55.00,0,0,0.00,176,0,'',0),(7,10,'2015-08-22 11:09:26',' ',0,9,'2015-08-22 11:09:29',9,'2015-08-22 11:37:20',0,19,0,19,0.00,0,0,0.00,19,0,'',0),(8,11,'2015-08-22 11:10:51',' ',0,9,'2015-08-22 11:10:54',9,'2015-08-22 11:39:02',0,13,0,13,0.00,0,0,0.00,13,0,'',0),(9,12,'2015-08-22 11:12:24',' ',0,9,'2015-08-22 11:12:28',9,'2015-08-22 11:39:28',0,2,0,2,0.00,0,0,0.00,2,0,'',0),(10,13,'2015-08-22 11:15:19',' ',0,9,'2015-08-22 11:15:24',9,'2015-08-22 11:40:26',0,0,0,0,0.00,0,144,15.00,144,0,'',144),(11,14,'2015-08-22 11:16:56',' ',0,9,'2015-08-22 11:16:58',9,'2015-08-22 11:41:09',0,3,0,3,0.00,0,0,0.00,3,0,'',0),(12,1,'2015-08-22 11:26:21',' ',0,9,'2015-08-22 11:26:30',9,'2015-08-22 11:26:45',0,0,0,0,0.00,0,11,0.00,11,0,'',11),(13,16,'2015-08-22 11:26:55','11',34,1,'2015-08-22 11:27:15',1,'2015-08-22 11:28:17',1,1,0,1,128.90,0,0,129.99,1,0,'',0),(14,8,'2015-08-22 11:31:44',' ',0,9,'2015-08-22 11:31:48',9,'2015-08-22 11:31:50',0,4,0,4,0.00,0,0,0.00,4,0,'',0),(15,15,'2015-08-22 11:48:10',' ',0,9,'2015-08-22 11:48:16',9,'2015-08-22 11:48:49',0,0,0,0,0.00,0,389,24.00,389,0,'',389),(16,17,'2015-08-22 11:50:34',' ',0,9,'2015-08-22 11:50:55',9,'2015-08-22 11:52:12',0,0,0,0,0.00,0,140,20.00,140,0,'',140),(17,18,'2015-08-22 11:53:24',' ',0,9,'2015-08-22 11:53:29',9,'2015-08-22 11:53:59',0,0,0,0,0.00,0,78,24.00,78,0,'',78),(18,19,'2015-08-22 11:57:18',' ',0,9,'2015-08-22 11:57:21',9,'2015-08-22 11:57:32',0,0,0,0,0.00,0,97,21.00,97,0,'',97),(19,20,'2015-08-22 12:33:01',' ',0,9,'2015-08-22 12:33:04',9,'2015-08-22 12:34:33',0,84,0,84,25.00,0,121,25.00,205,0,'',121),(20,21,'2015-08-22 12:35:33',' ',0,9,'2015-08-22 12:35:39',9,'2015-08-22 12:35:46',0,0,0,0,0.00,0,222,12.00,222,0,'',222),(21,22,'2015-08-22 12:37:14',' ',0,9,'2015-08-22 12:37:19',9,'2015-08-22 12:37:30',0,0,0,0,0.00,0,106,28.00,106,0,'',106),(22,23,'2015-08-22 12:38:16',' ',0,9,'2015-08-22 12:38:19',9,'2015-08-22 12:38:26',0,650,0,650,25.00,0,0,0.00,650,0,'',0),(23,24,'2015-08-22 12:40:20',' ',0,9,'2015-08-22 12:41:43',9,'2015-08-22 12:41:56',0,0,0,0,0.00,0,45,30.00,45,0,'',45),(24,25,'2015-08-22 12:42:41',' ',0,9,'2015-08-22 12:42:44',9,'2015-08-22 12:43:09',0,0,0,0,0.00,0,64,18.00,64,0,'',64),(25,26,'2015-08-22 12:44:23',' ',0,9,'2015-08-22 12:44:29',9,'2015-08-22 12:44:41',0,0,0,0,0.00,0,192,24.00,192,0,'',192),(26,27,'2015-08-22 12:46:00',' ',0,9,'2015-08-22 12:46:04',9,'2015-08-22 12:46:10',0,0,0,0,0.00,0,181,0.00,181,0,'',181),(27,28,'2015-08-22 12:47:29',' ',0,9,'2015-08-22 12:47:33',9,'2015-08-22 12:47:38',0,0,0,0,0.00,0,180,0.00,180,0,'',180),(28,29,'2015-08-22 12:48:51',' ',0,9,'2015-08-22 12:48:56',9,'2015-08-22 12:49:04',0,0,0,0,0.00,0,254,25.00,254,0,'',254),(29,30,'2015-08-22 12:49:56',' ',0,9,'2015-08-22 12:49:59',9,'2015-08-22 12:50:36',0,0,0,0,0.00,0,92,34.00,92,0,'',92),(30,31,'2015-08-22 12:52:04',' ',0,9,'2015-08-22 12:52:10',9,'2015-08-22 12:52:24',0,0,0,0,0.00,0,168,0.00,168,0,'',168),(31,32,'2015-08-22 12:53:29',' ',0,9,'2015-08-22 12:53:33',9,'2015-08-22 12:53:43',0,0,0,0,0.00,0,153,35.00,153,0,'',153),(32,33,'2015-08-22 12:59:31',' ',0,9,'2015-08-22 12:59:37',9,'2015-08-22 12:59:48',0,0,0,0,0.00,0,383,37.00,383,0,'',383),(33,34,'2015-08-22 13:09:38',' ',0,9,'2015-08-22 13:09:44',9,'2015-08-22 13:09:57',0,101,0,101,47.00,0,87,38.00,188,0,'',87),(34,35,'2015-08-22 13:11:15',' ',0,9,'2015-08-22 13:11:17',9,'2015-08-22 13:11:33',0,0,0,0,0.00,0,83,38.00,83,0,'',83),(35,36,'2015-08-22 13:14:11',' ',0,9,'2015-08-22 13:14:17',9,'2015-08-22 13:14:24',0,0,0,0,0.00,0,118,55.00,118,0,'',118),(36,37,'2015-08-22 13:18:43',' ',0,9,'2015-08-22 13:18:46',9,'2015-08-22 13:18:51',0,0,0,0,0.00,0,573,0.00,573,0,'',573),(37,38,'2015-08-22 13:19:29',' ',0,9,'2015-08-22 13:19:38',9,'2015-08-22 13:27:00',0,0,0,0,0.00,0,1,38.00,1,0,'',1),(38,39,'2015-08-22 13:20:51',' ',0,9,'2015-08-22 13:21:22',9,'2015-08-22 13:21:27',0,0,0,0,0.00,0,88,38.00,88,0,'',88),(39,40,'2015-08-22 13:25:35',' ',0,9,'2015-08-22 13:25:43',9,'2015-08-22 13:25:53',0,0,0,0,0.00,0,134,42.00,134,0,'',134),(40,41,'2015-08-22 13:28:22',' ',0,9,'2015-08-22 13:28:31',9,'2015-08-22 13:29:37',0,0,0,0,0.00,0,75,46.00,75,0,'',75),(41,42,'2015-08-22 13:30:34',' ',0,9,'2015-08-22 13:30:41',9,'2015-08-22 13:30:51',0,0,0,0,0.00,0,90,65.00,90,0,'',90),(42,43,'2015-08-22 13:32:31',' ',0,9,'2015-08-22 13:32:37',9,'2015-08-22 13:32:40',0,0,0,0,0.00,0,45,0.00,45,0,'',45);

#
# Structure for table "tk_user"
#

DROP TABLE IF EXISTS `tk_user`;
CREATE TABLE `tk_user` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(200) DEFAULT NULL,
  `lastname` varchar(200) DEFAULT NULL,
  `username` varchar(100) NOT NULL DEFAULT '',
  `password` varchar(200) NOT NULL DEFAULT '',
  `email` varchar(200) DEFAULT NULL,
  `mobile` varchar(20) DEFAULT NULL,
  `lastaccess` varchar(20) DEFAULT '0000-00-00 00:00:00',
  `status` int(1) unsigned NOT NULL DEFAULT '0',
  `is_delete` int(1) unsigned NOT NULL DEFAULT '0',
  `create_by` int(11) unsigned NOT NULL DEFAULT '0',
  `create_at` varchar(20) NOT NULL DEFAULT '',
  `update_by` int(11) unsigned DEFAULT NULL,
  `update_at` varchar(20) DEFAULT NULL,
  `role_admin` int(1) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='user';

#
# Data for table "tk_user"
#

INSERT INTO `tk_user` VALUES (1,'นิยม','จามะรีย์','admin','admin','niyomja@gmail.com','0890306711','2015-08-22 13:27:36',1,0,0,'',1,'2015-08-15 15:17:37',1),(2,'User',NULL,'user','user','test@mil.com',NULL,'2015-08-15 04:58:29',1,1,1,'2015-08-15 03:14:41',1,'2015-08-15 11:05:51',0),(7,'ttt','rrr','tum','6967','','','0000-00-00 00:00:00',1,1,1,'2015-08-15 11:06:35',1,'2015-08-17 11:18:31',1),(8,'tum','tum','tum','6927','','','2015-08-22 12:41:15',1,0,1,'2015-08-17 11:18:44',1,'2015-08-17 11:18:58',0),(9,'Apiwan','Yamano','tikapiwan','kenyumai123','tikapiwan@hotmail.com','0819253850','2015-08-22 10:38:28',1,0,1,'2015-08-17 11:21:16',1,'2015-08-17 11:22:05',0),(10,NULL,NULL,'test','test',NULL,NULL,'0000-00-00 00:00:00',0,1,1,'2015-08-21 09:41:35',1,'2015-08-21 09:41:39',0);

#
# Procedure "CreateBrand"
#

DROP PROCEDURE IF EXISTS `CreateBrand`;
CREATE PROCEDURE `CreateBrand`(

IN     
_UserID         int,
_BrandName      varchar(200),
_Description    text

)
BEGIN

INSERT INTO tk_brand(brandname, description, create_at, create_by, `status`) 
VALUES(_BrandName, _Description, now(), _UserID, 1);

END;

#
# Procedure "CreateCustomer"
#

DROP PROCEDURE IF EXISTS `CreateCustomer`;
CREATE PROCEDURE `CreateCustomer`(

IN     
_CustomerName                 varchar(200),
_Contact                      text,
_UserID                       int
)
BEGIN

INSERT INTO tk_customer(customerName, contact, create_by, create_at) 
VALUES(_CustomerName, _Contact, _UserID, Now());

END;

#
# Procedure "CreatePart"
#

DROP PROCEDURE IF EXISTS `CreatePart`;
CREATE PROCEDURE `CreatePart`(

IN     
_BrandID        int,
_PartNo         varchar(20),
_PartName       varchar(200),
_Model          varchar(200),
_GSP            decimal(10, 2),
_IMSP           decimal(10, 2),
_UserID         int

)
BEGIN

INSERT INTO tk_part(brandId, partNo, partName, model, gsp, imsp, create_by, create_at, `status`)
VALUES(_BrandID, _PartNo, _PartName, _Model, _GSP, _IMSP, _UserID, Now(), 1);

END;

#
# Procedure "CreatePartInventory"
#

DROP PROCEDURE IF EXISTS `CreatePartInventory`;
CREATE PROCEDURE `CreatePartInventory`(

IN     
_PartID                       int,
_Date                         datetime,
_DOInvoiceNo                  varchar(100),

_UserID                       int
)
BEGIN

INSERT INTO tk_part_inventory(partId, `regDate`, DOInvoiceNo, create_by, create_at) 
VALUES(_PartID, _Date, _DOInvoiceNo, _UserID, Now());

END;

#
# Procedure "CreateUser"
#

DROP PROCEDURE IF EXISTS `CreateUser`;
CREATE PROCEDURE `CreateUser`(

IN     
_FirstName                 varchar(200),
_LastName                  varchar(200),
_Username                  varchar(100),
_Password                  varchar(200),
_Email                     varchar(200),
_Mobile                    varchar(20),
_Status                    int,
_CreateUserID               int
)
BEGIN

INSERT INTO tk_user(firstname, lastname, username, `password`, email, mobile, `status`, create_by, create_at) 
VALUES(_FirstName, _LastName, _Username, _Password, _Email, _Mobile, _Status, _CreateUserID, Now());

END;

#
# Procedure "DeleteCustomer"
#

DROP PROCEDURE IF EXISTS `DeleteCustomer`;
CREATE PROCEDURE `DeleteCustomer`(

IN   
_CustomerID                       int,
_UserID                       int
)
BEGIN

UPDATE tk_customer SET is_delete=1, update_by=_UserID, update_at= Now()
WHERE customerId=_CustomerID;

END;

#
# Procedure "DeletePart"
#

DROP PROCEDURE IF EXISTS `DeletePart`;
CREATE PROCEDURE `DeletePart`(
IN _PartID int, _UserID int
)
BEGIN

UPDATE tk_part
SET is_delete = 1, update_by = _UserID
WHERE partId=_PartID;

END;

#
# Procedure "DeletePartInventory"
#

DROP PROCEDURE IF EXISTS `DeletePartInventory`;
CREATE PROCEDURE `DeletePartInventory`(

IN   
_PartInventoryID              int,  
_UserID                       int
)
BEGIN

UPDATE tk_part_inventory SET is_delete=1, update_by=_UserID, update_at= Now()
WHERE partInventoryId=_PartInventoryID;

END;

#
# Procedure "DeleteUser"
#

DROP PROCEDURE IF EXISTS `DeleteUser`;
CREATE PROCEDURE `DeleteUser`(

IN   
_UserID                       int,
_UpdateUserID                 int
)
BEGIN

UPDATE tk_user SET is_delete=1, update_by=_UpdateUserID, update_at= Now()
WHERE userId=_UserID;

END;

#
# Procedure "SelectAllBrand"
#

DROP PROCEDURE IF EXISTS `SelectAllBrand`;
CREATE PROCEDURE `SelectAllBrand`()
BEGIN

SELECT * FROM tk_brand WHERE `status`=1 ORDER BY brandname ASC;

END;

#
# Procedure "SelectAllCustomers"
#

DROP PROCEDURE IF EXISTS `SelectAllCustomers`;
CREATE PROCEDURE `SelectAllCustomers`()
BEGIN

SELECT *
FROM tk_customer
WHERE is_delete=0
ORDER BY `customerID` ASC;

END;

#
# Procedure "SelectAllUsers"
#

DROP PROCEDURE IF EXISTS `SelectAllUsers`;
CREATE PROCEDURE `SelectAllUsers`()
BEGIN

SELECT *
FROM tk_user
WHERE is_delete=0
ORDER BY `userId` ASC;

END;

#
# Procedure "SelectBalanceReport"
#

DROP PROCEDURE IF EXISTS `SelectBalanceReport`;
CREAT` PROCEDURE `SelectBalanceReport`(
IN 
   _StartDate datetime,
   _EndDate   datetime,
   _BrandID   int
)
BEGIN

SELECT * FROM tk_company LIMIT 0,1;
SELECT b.brandName, p.partNo, p.partName, p.model, SUM(p.gsp) AS price, SUM(p.imsp) AS price2, SUM(pn.recd - pn.lSold) AS `GBalance`, SUM(pn.oemRecd - pn.rSold) AS `OEMBalance`
FROM tk_part p
INNER JOIN tk_part_inventory pn ON pn.partId = p.partId
INNER JOIN tk_brand b ON b.brandId = p.brandId
WHERE pn.is_delete = 0 AND p.is_delete = 0 AND (_BrandID=0 OR b.brandId=_BrandID) AND DATE_FORMAT(pn.regDate, '%dd/%mm/%yyyy') BETWEEN DATE_FORMAT(_StartDate, '%dd/%mm/%yyyy') AND DATE_FORMAT(_EndDate, '%dd/%mm/%yyyy')
GROUP BY b.brandName, p.partNo
ORDER BY b.brandName ASC;

END;

#
# Procedure "SelectCompany"
#

DROP PROCEDURE IF EXISTS `SelectCompany`;
CREATE PROCEDURE `SelectCompany`(
)
BEGIN

SELECT *
FROM tk_company 
LIMIT 0,1;

END;

#
# Procedure "SelectCustomerReport"
#

DROP PROCEDURE IF EXISTS `SelectCustomerReport`;
CREATE PROCEDURE `SelectCustomerReport`()
BEGIN

SELECT * FROM tk_company LIMIT 0,1;
SELECT * 
FROM tk_customer
WHERE is_delete = 0
ORDER BY customerName ASC;

END;

#
# Procedure "SelectPartByBrandId"
#

DROP PROCEDURE IF EXISTS `SelectPartByBrandId`;
CREATE PROCEDURE `SelectPartByBrandId`(
IN _BrandID int
)
BEGIN

SELECT * FROM tk_part WHERE `status`=1 AND is_delete = 0 AND brandId=_BrandID ORDER BY partno ASC;

END;

#
# Procedure "SelectPartByBrandIdPartNo"
#

DROP PROCEDURE IF EXISTS `SelectPartByBrandIdPartNo`;
CREATE PROCEDURE `SelectPartByBrandIdPartNo`(
IN _BrandID int,
   _PartNo varchar(200)
)
BEGIN

SELECT * FROM tk_part 
WHERE `status`=1 AND is_delete = 0 AND brandId=_BrandID AND partno LIKE CONCAT('%',_PartNo,'%')
ORDER BY partno ASC;

END;

#
# Procedure "SelectPartInventoryByPartId"
#

DROP PROCEDURE IF EXISTS `SelectPartInventoryByPartId`;
CREATE PROCEDURE `SelectPartInventoryByPartId`(
IN _PartID int
)
BEGIN

SELECT p.*, DATE_FORMAT(NULLIF(p.regDate, ''),'%d-%m-%Y %H:%i:%s') AS fDate, c.customerName
FROM tk_part_inventory p
LEFT JOIN tk_customer c ON c.customerId=p.customerId
WHERE partId=_PartID AND p.is_delete = 0
ORDER BY p.`regDate` ASC;

END;

#
# Procedure "SelectSaleReport"
#

DROP PROCEDURE IF EXISTS `SelectSaleReport`;
CREATE PROCEDURE `SelectSaleReport`(
IN 
   _StartDate datetime,
   _EndDate   datetime,
   _BrandID   int
)
BEGIN
SELECT * FROM tk_company LIMIT 0,1;
SELECT b.brandName, pn.regDate, p.partNo, pn.DOInvoiceNo, c.customerName, pn.recd, pn.lsold, pn.price, pn.oemRecd, pn.rSold, pn.price2, CONCAT(u.firstname, ' ', u.lastname) AS username
FROM tk_part p
 INNER JOIN tk_part_inventory pn ON pn.partId = p.partId
 INNER JOIN tk_brand b ON b.brandId = p.brandId
 INNER JOIN tk_customer c ON c.customerId = pn.customerId
 INNER JOIN tk_user u ON u.userId = pn.update_by
WHERE pn.is_delete = 0 AND (_BrandID=0 OR p.brandId=_BrandID) AND DATE_FORMAT(pn.regDate, '%dd/%mm/%yyyy') BETWEEN DATE_FORMAT(_StartDate, '%dd/%mm/%yyyy') AND DATE_FORMAT(_EndDate, '%dd/%mm/%yyyy')
ORDER BY b.brandName, pn.regDate ASC;

END;

#
# Procedure "SelectUserByUsernamePassword"
#

DROP PROCEDURE IF EXISTS `SelectUserByUsernamePassword`;
CREATE PROCEDURE `SelectUserByUsernamePassword`(

IN     
_UserName                             varchar(200),
_Password                             varchar(200)

)
BEGIN

SELECT *

       FROM

       tk_user

       WHERE

       `username` =_UserName  AND `password` = _Password
       
       LIMIT 0, 1;

END;

#
# Procedure "UpdateCompany"
#

DROP PROCEDURE IF EXISTS `UpdateCompany`;
CREATE PROCEDURE `UpdateCompany`(

IN   
_ID                    int,
_CompanyName           varchar(255),
_Description           text,
_LocG                  varchar(20),
_LocIM                 varchar(20),
_UserID                 int
)
BEGIN

UPDATE tk_company SET companyName=_CompanyName, description=_Description, locationG=_LocG, locationIM=_LocIM
WHERE Id=_ID;

END;

#
# Procedure "UpdateCustomer"
#

DROP PROCEDURE IF EXISTS `UpdateCustomer`;
CREATE PROCEDURE `UpdateCustomer`(

IN   
_CustomerID                       int,
_CustomerName                 varchar(200),
_Contact                      text,
_Address                      text,
_Fax                          varchar(20),
_TaxNo                        varchar(100),
_UserID                       int
)
BEGIN

UPDATE tk_customer SET customerName=_CustomerName , contact=_Contact, update_by=_UserID, update_at= Now()
                        , address=_Address, fax=_Fax, tax_no=_TaxNo
WHERE customerId=_CustomerID;

END;

#
# Procedure "UpdatePart"
#

DROP PROCEDURE IF EXISTS `UpdatePart`;
CREATE PROCEDURE `UpdatePart`(

IN     
_PartID         int,
_BrandID        int,
_PartNo         varchar(20),
_PartName       varchar(200),
_Model          varchar(200),
_GSP            decimal(10, 2),
_IMSP           decimal(10, 2),
_LocG         varchar(20),
_LocIM         varchar(20),
_Comment         text,
_UserID         int

)
BEGIN

UPDATE tk_part SET brandId=_BrandID, partNo=_PartNo, partName=_PartName, model=_Model, gsp=_GSP, imsp=_IMSP, locG=_LocG, locIM=_LocIM, `comment`=_Comment, update_by=_UserID, update_at=NOW()
WHERE partId = _PartID;

END;

#
# Procedure "UpdatePartInventory"
#

DROP PROCEDURE IF EXISTS `UpdatePartInventory`;
CREATE PROCEDURE `UpdatePartInventory`(

IN   
_PartInventoryID              int,  
_PartID                       int,
_CustomerID                       int,
_Date                         datetime,
_DOInvoiceNo                  varchar(100),
_Recd                         int,
_LSold                        int,
_GOnHand                      int,
_Price                        decimal(10,2),
_OEMRecd                      int,
_RSold                        int,
_IMOnHand                     int,
_Price2                       decimal(10,2),
_TotalAvailabel               int,
_TotalDemand                  int,
_UserID                       int,
_Detail                      text
)
BEGIN

UPDATE tk_part_inventory SET partId=_PartID, `regDate`=_Date, DOInvoiceNo=_DOInvoiceNo, customerId=_CustomerID, update_by=_UserID, update_at= Now(),
                             recd=_Recd, lSold=_LSold, gOnHand=_GOnHand, price=_Price, price2=_Price2, rSold=_RSold, imOnHand=_IMOnHand, totalDemand=_TotalDemand, 
                             totalAvailabel=_TotalAvailabel, detail=_Detail, oemRecd=_OEMRecd
WHERE partInventoryId=_PartInventoryID;

END;

#
# Procedure "UpdateUser"
#

DROP PROCEDURE IF EXISTS `UpdateUser`;
CREATE PROCEDURE `UpdateUser`(

IN   
_UserID                       int,
_FirstName                 varchar(200),
_LastName                  varchar(200),
_Username                  varchar(100),
_Password                  varchar(200),
_Email                     varchar(200),
_Mobile                    varchar(20),
_Status                    int,
_UpdateUserID                       int
)
BEGIN

UPDATE tk_user SET firstname=_FirstName, lastname=_LastName, username=_Username, `password`=_Password, email=_Email, mobile=_Mobile, `status`=_Status, update_by=_UpdateUserID, update_at= Now()
WHERE userId=_UserID;

END;

#
# Procedure "UpdateUserLastAccess"
#

DROP PROCEDURE IF EXISTS `UpdateUserLastAccess`;
CREATE PROCEDURE `UpdateUserLastAccess`(

IN     _UserID         int

)
BEGIN

UPDATE tk_user SET lastaccess = now() WHERE userId = _UserID;

END;
