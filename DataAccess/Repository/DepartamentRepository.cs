using DataAccess.Interface;
using Entities.Model;


namespace DataAccess.Repository
{
    public class DepartamentRepository : IRepository<Departament>
    {
        public bool Create(Departament entity)
        {
            try
            {
                DbContext.Departaments.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Departament entity)
        {
            try
            {
                DbContext.Departaments.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Departament Get(Predicate<Departament> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Departaments[0] : DbContext.Departaments.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Departament> GetAll(Predicate<Departament> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Departaments : DbContext.Departaments.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Departament entity)
        {
            try
            {
                Departament DbDepartament = Get(d => d.Id == entity.Id);
               
                
                   DbDepartament.Name = entity.Name;
                    
                     DbDepartament.MaxEmployees = entity.MaxEmployees;
                      return true;
                 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
