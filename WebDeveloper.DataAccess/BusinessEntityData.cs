using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class BusinessEntityData:BaseDataAccess<BusinessEntity>
    {
        public BusinessEntity GetBusinessEntityById(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.BusinessEntitys.FirstOrDefault(u => u.BusinessEntityID == id);
            }
        }

        public int AddBusinessentity(BusinessEntity entity)
        {
            int id;
            using (var dbContext = new WebContextDB())
            {
                dbContext.Entry(entity).State = EntityState.Added;
                dbContext.SaveChanges();
                dbContext.Entry(entity).GetDatabaseValues();
                return id = entity.BusinessEntityID;
            }
        }

    }
}
