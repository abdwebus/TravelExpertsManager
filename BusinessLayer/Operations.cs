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
        public static List<Package> GetPackages()
        {
            List<Package> packages = new List<Package>();
            string packageSql = "SELECT PackageId, PkgName ,PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission FROM Packages";
            DataRowCollection packageRows = DB.getRows(packageSql);
            foreach (DataRow packageRow in packageRows)
            {
                Package package = new Package
                {
                    PackageId = Convert.ToInt32(packageRow["PackageId"]),
                    PkgName = packageRow["PkgName"].ToString(),
                    PkgStartDate = Convert.ToDateTime(packageRow["PkgStartDate"]),
                    PkgEndDate = Convert.ToDateTime(packageRow["PkgEndDate"]),
                    PkgDesc = packageRow["PkgDesc"].ToString(),
                    PkgBasePrice = Convert.ToDecimal(packageRow["PkgBasePrice"]),
                    PkgAgencyCommission = Convert.ToDecimal(packageRow["PkgAgencyCommission"])
                };
                package.Products = GetProductsForPackage(package.PackageId);
                packages.Add(package);
            }
            return packages;
        }

        private static List<Product> GetProductsForPackage(int packageId) {
            List<Product> products = new List<Product>(); 
            string productSql = "select p.ProductId, p.ProdName, s.SupplierId, s.SupName ";
            productSql += "from Packages_Products_Suppliers pps ";
            productSql += "JOIN Products_Suppliers ps on pps.ProductSupplierId = ps.ProductSupplierId ";
            productSql += "JOIN Products p on p.ProductId = ps.ProductId ";
            productSql += "JOIN Suppliers s on s.SupplierId = ps.SupplierId ";
            productSql += "where PackageId = " + packageId;
            DataRowCollection productRows = DB.getRows(productSql);
            foreach (DataRow productRow in productRows)
            {
                Supplier supplier = new Supplier
                {
                    SupplierId = Convert.ToInt32(productRow["SupplierId"]),
                    SupName = productRow["SupName"].ToString()
                };

                Product product = new Product
                {
                    ProductId = Convert.ToInt32(productRow["ProductId"]),
                    ProdName = productRow["ProdName"].ToString(),
                    Supplier = supplier
                };
                products.Add(product);
            }
            return products;
        }

        public static List<Supplier> GetSuppliers() {

            return new List<Supplier>();
        }

        public static List<Product> GetProducts() {

            return new List<Product>();
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

        public static bool UpdateProduct(int productId, string prodName, int supplierId)
        {

            return true;
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

            return true;
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
