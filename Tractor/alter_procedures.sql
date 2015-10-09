DROP PROCEDURE IF EXISTS `CreateUser`;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateUser`(

IN     
_FirstName                 varchar(200),
_LastName                  varchar(200),
_Username                  varchar(100),
_Password                  varchar(200),
_Email                     varchar(200),
_Mobile                    varchar(20),
_Status                    int,
_RoleAdmin                 int,
_CreateUserID              int
)
BEGIN

INSERT INTO tk_user(firstname, lastname, username, `password`, email, mobile, `status`, role_admin, create_by, create_at) 
VALUES(_FirstName, _LastName, _Username, _Password, _Email, _Mobile, _Status, _RoleAdmin, _CreateUserID, Now());

END;

DROP PROCEDURE IF EXISTS `UpdateUser`;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUser`(

IN   
_UserID                       int,
_FirstName                 varchar(200),
_LastName                  varchar(200),
_Username                  varchar(100),
_Password                  varchar(200),
_Email                     varchar(200),
_Mobile                    varchar(20),
_Status                    int,
_RoleAdmin                 int,
_UpdateUserID              int
)
BEGIN

UPDATE tk_user SET firstname=_FirstName, lastname=_LastName, username=_Username, `password`=_Password, email=_Email, mobile=_Mobile, `status`=_Status, role_admin=_RoleAdmin, update_by=_UpdateUserID, update_at= Now()
WHERE userId=_UserID;

END;

DROP PROCEDURE IF EXISTS `SelectTransactionReport`;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionReport`(
IN 
   _StartDate datetime,
   _EndDate   datetime,
   _BrandID   int
)
BEGIN

SELECT * FROM tk_company LIMIT 0,1;
SELECT DATE_FORMAT(pn.update_at, '%d/%m/%Y %H:%i') as update_at, b.brandName, pn.DOInvoiceNo as partNo, p.partName, p.model, p.is_delete as part_deleted, pn.is_delete as inventory_deleted, CONCAT(u.firstname, ' ', u.lastname) as fullname   
FROM tk_part p
INNER JOIN tk_part_inventory pn ON pn.partId = p.partId
INNER JOIN tk_brand b ON b.brandId = p.brandId
INNER JOIN tk_user u ON u.userId = pn.update_by
WHERE (_BrandID=0 OR b.brandId=_BrandID) AND DATE_FORMAT(pn.update_at, '%d/%m/%Y') BETWEEN DATE_FORMAT(_StartDate, '%d/%m/%Y') AND DATE_FORMAT(_EndDate, '%d/%m/%Y')
ORDER BY pn.update_at ASC;

END;

DROP PROCEDURE IF EXISTS `DeletePart`;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeletePart`(
IN _PartID int, _UserID int
)
BEGIN

UPDATE tk_part
SET is_delete = 1, update_by = _UserID
WHERE partId=_PartID;

UPDATE tk_part_inventory
SET is_delete = 1, update_by = _UserID
WHERE partId=_PartID;

END;