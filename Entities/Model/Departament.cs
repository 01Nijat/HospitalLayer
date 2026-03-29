using Entities.Interface;


namespace Entities.Model
{
    public class Departament : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxEmployees { get; set; }
    }
}
