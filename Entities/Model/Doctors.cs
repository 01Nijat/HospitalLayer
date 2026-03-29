using Entities.Interface;


namespace Entities.Model
{
    public class Doctors : IEntity

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        Departament Departament { get; set; }
    }
}
