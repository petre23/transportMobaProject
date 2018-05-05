using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class AngajatRepository
    {
        public List<Angajat> GetAngajati()
        {
            return new List<Angajat>();
        }

        public Guid SaveAngajati()
        {
            return Guid.Empty;
        }

        public Angajat GetAngajat()
        {
            return new Angajat();
        }
    }
}
