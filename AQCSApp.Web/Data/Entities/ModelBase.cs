using System;

namespace AQCSApp.Web.Data.Entities
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
