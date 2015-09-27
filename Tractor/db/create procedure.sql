DROP PROCEDURE IF EXISTS `CreatePart`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `CreatePart`(

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