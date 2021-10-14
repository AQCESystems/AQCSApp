

using System;

namespace AQCSApp.Web.Data.Entities
{
  

    public class User : ModelBase
    {

        public string Name { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Free { get; set; }
        public bool Premiun { get; set; }
        public DateTime SuscriptionBeginDate { get; set; }
        public DateTime SuscruptionEndDate { get; set; }


    }
}
