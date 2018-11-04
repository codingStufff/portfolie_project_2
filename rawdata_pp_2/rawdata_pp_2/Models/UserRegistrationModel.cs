using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rawdata_pp_2.Models
{
    // this model extends UserLoginModel, therefore it also get its properties hence we only have for properties here.
    // furthermore, we do not want a user to create its own Id or creationdate, because the database takes care of that.
    public class UserRegistrationModel : UserLoginModel
    {
        public int Age { get; set; }
        public string DisplayName { get; set; }
        public string UserLocation { get; set; }
        public string Salt { get; set; }
    }
}
