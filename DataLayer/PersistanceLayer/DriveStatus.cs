using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class DriveStatus
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
