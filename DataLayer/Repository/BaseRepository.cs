using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class BaseRepository
    {
        public string ConnectionString { get { return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; } }
    }
}
