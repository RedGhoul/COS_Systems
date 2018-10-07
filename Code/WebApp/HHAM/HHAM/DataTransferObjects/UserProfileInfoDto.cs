using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.DataTransferObjects
{
    public class UserProfileInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
}