using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataAccessLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataAccessLayer : IDataAccessLayer
    {
        AngajatRepository _angajatRepository = new AngajatRepository();
        public List<Angajat> GetAngajati()
        {
            return _angajatRepository.GetAngajati();
        }

        public Guid SaveAngajat(Angajat angajat)
        {
            return _angajatRepository.SaveAngajati();
        }

        public Angajat GetAngajat(Guid idAngajat)
        {
            return _angajatRepository.GetAngajat();
        }
    }
}
