using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBox.Domain.Entities
{
    public class UsersEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate{ get; set; }
    }
}
