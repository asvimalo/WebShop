using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DB
    {
        //Field Data
        private string ConnectionString { get; set; }
        public SqlDataAdapter AdapterProduct = null;
        public SqlDataAdapter AdapterCustomer = null;
        public SqlDataAdapter AdapterShoppingCart = null;
        public SqlDataAdapter AdapterProductsByGenreCategory = null;
        public SqlDataAdapter AdapterProductsByMaleCategoryTshirt = null;
        public SqlDataAdapter AdapterProductsByMaleCategorySweatShirt = null;
        public SqlDataAdapter AdapterProductsByMaleCategoryJeans = null;
        public SqlDataAdapter AdapterProductsByMaleCategoryJackets = null;

        public DB(string connectionString)
        {
            //Configure the adapter and setup the adapter
            ConnectionString = connectionString;
            ConfigureAdapterProducts(out AdapterProduct);
        }

        /// <summary>
        /// Select all products and prepare the remaining commands automaticaly
        /// </summary>
        /// <param name="adapterProduct"></param>
        private void ConfigureAdapterProducts(out SqlDataAdapter adapterProduct)
        {
            //Create the adapter and setup the SelectCommand
            adapterProduct = new SqlDataAdapter("Select * FROM tblProduct", ConnectionString);
            //Obtain the remaining command objects at runtime
            var builder = new SqlCommandBuilder(adapterProduct);
        }
    }
}
