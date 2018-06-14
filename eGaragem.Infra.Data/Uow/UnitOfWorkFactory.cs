using eGaragem.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGaragem.Infra.Data.UoW
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var connection = new SqlConnection(connString);

            connection.Open();
            return new UnitOfWork(connection, true);
        }
    }
}
