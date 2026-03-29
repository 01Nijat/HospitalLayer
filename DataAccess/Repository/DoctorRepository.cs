using DataAccess.Interface;
using Entities.Model;


namespace DataAccess.Repository
{
    public class DoctorRepository : IRepository<Doctors>
    {
        public bool Create(Doctors entity)
        {
            try
            {
                DbContext.Doctors.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Doctors entity)
        {
            try
            {
                DbContext.Doctors.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Doctors Get(Predicate<Doctors> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Doctors[0] 
                    : DbContext.Doctors.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Doctors> GetAll(Predicate<Doctors> filter = null)
        {
            try
            {
                return filter == null ? DbContext.Doctors : DbContext.Doctors.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Doctors entity)
        {
            try
            {
                Doctors dbDoc = Get(d => d.Id == entity.Id);
                dbDoc.Name = entity.Name;
                dbDoc.Surname = entity.Surname;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
