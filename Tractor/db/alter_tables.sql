ALTER TABLE tk_part
ADD COLUMN
(
  `locG` varchar(20) DEFAULT NULL,
  `locIM` varchar(20) DEFAULT NULL,
  `comment` text
);

ALTER TABLE tk_customer
ADD COLUMN
(
  `address` text,
  `fax` varchar(20) DEFAULT NULL,
  `tax_no` varchar(100) DEFAULT NULL
);