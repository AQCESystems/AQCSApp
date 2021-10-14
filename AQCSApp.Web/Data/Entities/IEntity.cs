
namespace AQCSApp.Web.Data.Entities
{
    public interface IEntity
    {
        //Los campos que pongamos aquí serán obligatorios en todas las entidades que 
        //hereden de el. Por ejemplo la entidad FishFamily
        int Id { get; set; }

    }
}
