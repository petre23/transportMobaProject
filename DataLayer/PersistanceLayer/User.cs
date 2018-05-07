using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool HasAdminRole { get; set; }
    }
}
