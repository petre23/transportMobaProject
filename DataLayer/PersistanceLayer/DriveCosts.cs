using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PersistanceLayer
{
    [DataContract]
    public class DriveCosts
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public decimal CostEuro { get; set; }
        [DataMember]
        public decimal CostPounds { get; set; }
        [DataMember]
        public string Specifications { get; set; }
        [DataMember]
        public Guid Drive { get; set; }
    }
}
