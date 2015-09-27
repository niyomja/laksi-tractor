using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;

namespace appTractor.Model
{
    public class CompanyModel : IModelBase
    {
        public Company getCompany() {
            return CompanyDAL.getCompany();
        }

        public void UpdateCompany(Company company, int userId) {
            CompanyDAL.Update(company.ID, company.Name, company.Desciption, company.LocG, company.LocIM, userId);
        }
    }
}
