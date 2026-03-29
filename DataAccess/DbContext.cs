using Entities.Model;


namespace DataAccess
{
    public static class DbContext
    {
        public static List<Doctors> Doctors { get; set; }
        public static List<Departament> Departaments{ get; set; } 
            static DbContext()
            {
                Doctors = new List<Doctors>();
                Departaments = new List<Departament>();
        }
    }
}
