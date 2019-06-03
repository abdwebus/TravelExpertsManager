using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class Operations
    {
        public static void testConnection()
        {
            SqlConnection connection = DB.getConnection();
            Console.WriteLine(connection.ToString());
            connection.Close();
        }
        public static List<Package> GetPackages()
        {
            List<Package> packages = new List<Package>();
            string sql = "SELECT PackageId, PkgName ,PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission FROM Packages";
            DataRowCollection rows = DB.getRows(sql);
            foreach (DataRow row in rows)
            {
                Package package = new Package
                {
                    PackageId = Convert.ToInt32(row["PackageId"]),
                    PkgName = row["PkgName"].ToString(),
                    PkgStartDate = Convert.ToDateTime(row["PkgStartDate"]),
                    PkgEndDate = Convert.ToDateTime(row["PkgEndDate"]),
                    PkgDesc = row["PkgDesc"].ToString(),
                    PkgBasePrice = Convert.ToDecimal(row["PkgBasePrice"]),
                    PkgAgencyCommission = Convert.ToDecimal(row["PkgAgencyCommission"])
                };

                packages.Add(package);
            }
            return packages;
        }

        public static List<Supplier> GetSuppliers() {
          
            return new List<Supplier>();
        }

        public static List<Product> GetProducts() {
            List<Product> ProductList = new List<Product>();
            string sql = "select ProdName from Products order by ProdName ; ";
            DataRowCollection Rows = DB.getRows(sql);

            foreach(DataRow Row in Rows)
            {
                Product product = new Product()
                {
                    ProdName = Row["ProdName"].ToString(),
                };
               ProductList.Add(product);
           }
            return ProductList;
        }

        public static Package GetPackage(int packageId) {

            return new Package();
        }

        public static Supplier GetSupplier(int supplierId)
        {

            return new Supplier();
        }

        public static Product GetProduct(int productId)
        {

            return new Product();
        }

        public static bool UpdatePackage(Package package) {

            return true;
        }

        public static bool UpdateSupplier(int supplierId, string supName) {

            return true;
        }

        public static bool UpdateProduct(int productId, string prodName/*, int supplierId*/)
        {
            string sql = " update Products set ProdName = (@ProdName) where ProductId = (@ProdID) ;";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ProdName", prodName);
            command.Parameters.AddWithValue("@ProdID", productId);
            return DB.updateRow(command);

          
        }

        public static bool InsertPackage()
        {

            return true;
        }

        public static bool InsertSupplier(string supName)
        {

            return true;
        }

        public static bool InsertProduct(string prodName, int supplierId)
        {
            string sql = " insert into Products (ProdName) values  (@ProdName) ";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@ProdName", prodName);
            return DB.updateRow(command);
        }
        public static List<Product> ShowProducts()
        {
            List<Product> ProductList = new List<Product>();
            string sql = "  select * from Products;";
            DataRowCollection Rows = DB.getRows(sql);

            foreach (DataRow Row in Rows)
            {
                Product product = new Product()
                {
                    ProdName = Row["ProdName"].ToString(),
                    ProductId =Convert.ToInt32(Row["ProductID"].ToString()),
                };
                ProductList.Add(product);
            }
            return ProductList;
        }

        public static bool updateShippedDate(int orderID, DateTime date)
        {
            string sql = "UPDATE Orders SET ShippedDate = @date WHERE OrderID = @orderID";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@orderID", orderID);
            command.Parameters.AddWithValue("@date", date);
            return DB.updateRow(command);
        }
    }
}
