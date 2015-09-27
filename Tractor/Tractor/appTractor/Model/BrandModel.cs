using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;

namespace appTractor.Model
{
    public class BrandModel : IModelBase
    {
        private Brand brand;

        public void createBrand(Brand brand, int userId)
        {
            this.brand = brand;
            if (valid())
            {
                BrandDAL.create(brand.Brandname, brand.Description, userId);
            }
            else
            {
                throw new Exception("Invalid Brand Data!");
            }
        }

        public List<Brand> getBrands()
        {
            return BrandDAL.getBrands();
        }

        public bool valid()
        {
            return (brand != null && !String.IsNullOrEmpty(brand.Brandname));
        }
    }
}
