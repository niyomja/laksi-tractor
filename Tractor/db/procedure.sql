# Host: localhost  (Version: 5.6.26-log)
# Date: 2015-08-20 10:47:46
# Generator: MySQL-Front 5.3  (Build 4.175)

/*!40101 SET NAMES utf8 */;

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
CREATE PROCEDURE `SelectBalanceReport`(
IN 
   _StartDate datetime,
   _EndDate   datetime,
   _BrandID   int
)
BEGIN

SELECT * FROM tk_company LIMIT 0,1;
SELECT b.brandName, p.partNo, p.partName, p.model,  SUM(pn.recd - pn.lSold) AS `GBalance`, SUM(pn.oemRecd - pn.rSold) AS `OEMBalance`
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
_Price                        decimal,
_OEMRecd                      int,
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
