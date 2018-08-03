using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace LingYun.Data
{
   public class DBConnect
    {
        
            public static string DataBaseConnectionString()
            {


                string providerName = "System.Data.SqlClient";
                string serverName = "LENOVO-PC";
                string databaseName = "LingYun";

                SqlConnectionStringBuilder sqlBuilder =
                    new SqlConnectionStringBuilder();

                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.IntegratedSecurity = false;
                sqlBuilder.UserID = "sa";
                sqlBuilder.Password = "tcr1994";
                sqlBuilder.MultipleActiveResultSets = true;

                string providerString = sqlBuilder.ToString();

                EntityConnectionStringBuilder entityBuilder =
                    new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.

                entityBuilder.ProviderConnectionString = providerString;

                entityBuilder.Provider = providerName;
                entityBuilder.Metadata = @"res://*/LingYun.csdl|res://*/LingYun.ssdl|res://*/LingYun.msl";

                string str = entityBuilder.ToString();
                return str;


            

        }
    }
}
