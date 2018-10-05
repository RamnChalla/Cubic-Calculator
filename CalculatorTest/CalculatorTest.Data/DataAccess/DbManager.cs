using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest.Data.DataAccess
{
    /// <summary>
    /// DataAccess class - maintains database operations
    /// </summary>
    public class DbManager : IDbManager, IDisposable
    {
        public void SaveResult(string function, string result, int mode)
        {
            if(mode == Constants.AdoNetMode)
            {
                AddThroughAdoNet(function, result);
            }
            else if(mode == Constants.OrmMode)
            {
                AddThroughORM(function, result);
            }
        }

        private void AddThroughAdoNet(string function, string result)
        {
            SqlParameter[] standardParameters = new SqlParameter[2];
            standardParameters[0] = new SqlParameter("@FunctionName", function);
            standardParameters[1] = new SqlParameter("@FunctionResult", result);

            ExecuteNonQuerySqlServerStoredProcedure(Constants.InsertResultDataProc, Constants.AdoNetConnection, standardParameters);

        }

        private void AddThroughORM(string function, string result)
        {
            // insert
            using (var db = new CalculationsEntities())
            {
                var results = db.Set<CalculatorResult>();
                results.Add(new CalculatorResult { FunctionName = function, FunctionResult = result });
                db.SaveChanges();
            }
        }

        private void ExecuteNonQuerySqlServerStoredProcedure(string storedProcedureName, string connectionString, SqlParameter[] parameters = null)
        {
            try
            {
                using (var cnn = new SqlConnection(GetConnection(connectionString)))
                {
                    using (var cmd = new SqlCommand(storedProcedureName, cnn))
                    {                       
                        if (parameters != null)
                        {
                            foreach (SqlParameter param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                       // return "success";
                    }
                }
            }
            catch (SqlException sx)
            {
                throw new Exception(string.Format("SQL Exception calling SqlServer Stored procedure: {0}, message {1}", storedProcedureName, sx.Message), sx);
            }           
        }

        public string GetConnection(string connectionName)
        {
            if (connectionName == Constants.AdoNetConnection)
            {
                return ConfigurationManager.ConnectionStrings["CalculatorDbConnectionString"].ConnectionString; 
            }
            if (connectionName == Constants.OrmConnection)
            {
                return ConfigurationManager.ConnectionStrings["CalculationsEntities"].ConnectionString;
            }

            throw new NotImplementedException("This should not happen, an unknown database connection has been requested");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DbManager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
