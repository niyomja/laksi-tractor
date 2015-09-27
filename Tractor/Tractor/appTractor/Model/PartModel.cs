using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;

namespace appTractor.Model
{
    public class PartModel : IModelBase
    {
        private Part part;

        public int createPart(Part part, int userId)
        {
            this.part = part;
            if (valid())
            {
                return PartDAL.create(part.BrandID, part.PartNo, part.PartName, part.Model, part.GSP, part.IMSP, part.LocG, part.LocIM, part.Comment, userId);
            }
            else {
                return -1;
            }
        }

        private bool valid()
        {
            return (part != null 
                && part.BrandID > 0
                && !String.IsNullOrEmpty(part.PartNo) && !String.IsNullOrEmpty(part.PartName));
        }

        public List<Part> getPartsByBrandId(int brandId)
        {
            return PartDAL.getPartsByBrandId(brandId);
        }

        public List<Part> getPartsByBrandIdPartNo(int brandId, string partNo)
        {
            return PartDAL.getPartsByBrandIdPartNo(brandId, partNo);
        }

        public bool UpdatePart(Part cPart, int userId)
        {
            part = cPart;
            if (valid())
            {
                PartDAL.update(cPart.PartID, part.BrandID, part.PartNo, part.PartName, part.Model, part.GSP, part.IMSP, part.LocG, part.LocIM, part.Comment, userId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void delete(int partId, int userId)
        {
            PartDAL.deletePartById(partId, userId);
        }
    }
}
