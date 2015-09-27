DROP PROCEDURE IF EXISTS `SelectCustomerReport`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectCustomerReport`()
BEGIN

SELECT * FROM tk_company LIMIT 0,1;
SELECT * 
FROM tk_customer
WHERE is_delete = 0
ORDER BY customerName ASC;

END;


--call SelectBalanceReport('2015-08-10 13:26:38', '2015-08-20 13:26:38', 0);

SELECT b.brandName, p.partNo, p.partName, p.model,  SUM(pn.recd - pn.lSold) AS `GBalance`, SUM(pn.oemRecd - pn.rSold) AS `OEMBalance`
FROM tk_part p
INNER JOIN tk_part_inventory pn ON pn.partId = p.partId
INNER JOIN tk_brand b ON b.brandId = p.brandId
WHERE pn.is_delete = 0
GROUP BY b.brandName, p.partNo
ORDER BY b.brandName ASC