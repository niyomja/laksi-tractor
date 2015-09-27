DROP PROCEDURE IF EXISTS `UpdateCustomer`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCustomer`(

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

DROP PROCEDURE IF EXISTS `UpdatePart`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePart`(

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


DROP PROCEDURE IF EXISTS `UpdatePartInventory`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePartInventory`(

IN   
_PartInventoryID              int,  
_PartID                       int,
_CustomerID                       int,
_Date                         datetime,
_DOInvoiceNo                  varchar(100),
_Recd                         int,
_LSold                        int,
_GOnHand                      int,
_Price                        decimal,
_RSold                        int,
_IMOnHand                     int,
_Price2                        decimal,
_TotalAvailabel               int,
_TotalDemand                  int,
_UserID                       int,
_Detail                      text
)
BEGIN

UPDATE tk_part_inventory SET partId=_PartID, `regDate`=_Date, DOInvoiceNo=_DOInvoiceNo, customerId=_CustomerID, update_by=_UserID, update_at= Now(),
                             recd=_Recd, lSold=_LSold, gOnHand=_GOnHand, price=_Price, price2=_Price2, rSold=_RSold, imOnHand=_IMOnHand, totalDemand=_TotalDemand, 
                             totalAvailabel=_TotalAvailabel, detail=_Detail 
WHERE partInventoryId=_PartInventoryID;

END;


CREATE DEFINER=`root`@`localhost` PROCEDURE `DeletePartInventory`(

IN   
_PartInventoryID              int,  
_UserID                       int
)
BEGIN

UPDATE tk_part_inventory SET is_delete=1, update_by=_UserID, update_at= Now()
WHERE partInventoryId=_PartInventoryID;

END;

DROP PROCEDURE IF EXISTS `SelectPartInventoryByPartId`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectPartInventoryByPartId`(
IN _PartID int
)
BEGIN

SELECT p.*, DATE_FORMAT(NULLIF(p.regDate, ''),'%d-%m-%Y %H:%i:%s') AS fDate, c.customerName
FROM tk_part_inventory p
LEFT JOIN tk_customer c ON c.customerId=p.customerId
WHERE partId=_PartID AND is_delete = 0
ORDER BY `regDate` ASC;

END;

CREATE PROCEDURE `SelectAllCustomers`()
BEGIN

SELECT *
FROM tk_customer
ORDER BY `customerName` ASC;

END;


call SelectPartInventoryByPartId(36);