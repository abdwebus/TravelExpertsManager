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
        /// <summary>
        /// Get all packages and the products associated with the packages
        /// </summary>
        /// <returns>List<Package> list of packages</returns>
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

        /// <summary>
        /// Helper method to get all products for specific package
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns>List<Product></returns>
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

        /// <summary>
        /// Helper method to get suppliers associated with specific product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        private static List<Supplier> GetSuppliersByProduct(int productId)
        {
            List<Supplier> suppliers = new List<Supplier>();
            string sql = "SELECT s.SupplierId, s.SupName FROM Products_Suppliers ps ";
            sql += "JOIN Suppliers s ON ps.SupplierId = s.SupplierId ";
            sql += "WHERE ps.ProductId = " + productId;
            DataRowCollection rows = DB.getRows(sql);
            foreach (DataRow row in rows)
            {
                Supplier supplier = new Supplier
                {
                    SupplierId = Convert.ToInt32(row["SupplierId"]),
                    SupName = row["SupName"].ToString()
                };
                suppliers.Add(supplier);
            }
            return suppliers;
        }

        /// <summary>
        /// Add product to package
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="supplierId"></param>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public static bool AddProductToPackage(int productId, int supplierId, int packageId)
        {
            int productSupplierId = GetProductSupplierId(productId, supplierId);
            string sql = "INSERT INTO Packages_Products_Suppliers ";
            sql += "(PackageId, ProductSupplierId) VALUES (@packageId, @productSupplierId)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@productSupplierId", productSupplierId);
            command.Parameters.AddWithValue("@packageId", packageId);
            return DB.updateRow(command);
        }


        /// <summary>
        /// Helper method to get productSupplierId
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        private static int GetProductSupplierId(int productId, int supplierId) {
            //Get ProductSupplierId
            string sql = "SELECT ProductSupplierId FROM Products_Suppliers WHERE ";
            sql += "ProductId = " + productId;
            sql += " AND SupplierId = " + supplierId;
            DataRowCollection rows = DB.getRows(sql);
            int result = Convert.ToInt32(rows[0]["ProductSupplierId"]);

            return result;
        }

        /// <summary>
        /// Get products and all suppliers that supply them
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public static List<ProductSupplier> GetProductSuppliers(int packageId) {
            List<ProductSupplier> productSuppliers = new List<ProductSupplier>();
            List<Product> products = GetProductsNotInPackage(packageId);
            foreach (Product product in products)
            {
                ProductSupplier ps = new ProductSupplier
                {
                    product = product,
                    suppliers = GetSuppliersByProduct(product.ProductId)
                };
                productSuppliers.Add(ps);
            }
            return productSuppliers;
        }

        public static List<Supplier> GetSuppliers() {

            return new List<Supplier>();
        }

        /// <summary>
        /// Helper method to get all products that are not part of a specific package
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        private static List<Product> GetProductsNotInPackage(int packageId)
        {
            List<Product> products = new List<Product>();
            string packageSql = "SElECT ProductId, ProdName FROM Products ";
            packageSql += "WHERE ProductId not in (select ps.ProductId ";
            packageSql += "from Packages_Products_Suppliers pps ";
            packageSql += "JOIN Products_Suppliers ps on pps.ProductSupplierId = ps.ProductSupplierId ";
            packageSql += "where PackageId = " + packageId + ")";

            DataRowCollection packageRows = DB.getRows(packageSql);
            foreach (DataRow packageRow in packageRows)
            {
                Product product = new Product
                {
                    ProductId = Convert.ToInt32(packageRow["ProductId"]),
                    ProdName = packageRow["ProdName"].ToString(),
                };
                products.Add(product);
            }
            return products;
        }

        public static List<Product> GetProducts() {
            List<Product> products = new List<Product>();
            string packageSql = " SELECT ProductId, ProdName FROM Products";
            DataRowCollection packageRows = DB.getRows(packageSql);
            foreach (DataRow packageRow in packageRows)
            {
                Product product = new Product
                {
                    ProductId = Convert.ToInt32(packageRow["ProductId"]),
                    ProdName = packageRow["ProdName"].ToString(),
                };
                products.Add(product);
            }
            return products;
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

        /// <summary>
        /// Add new package
        /// </summary>
        /// <param name="PkgName"></param>
        /// <param name="PkgStartDate"></param>
        /// <param name="PkgEndDate"></param>
        /// <param name="PkgDesc"></param>
        /// <param name="PkgBasePrice"></param>
        /// <param name="PkgAgencyCommission"></param>
        /// <returns></returns>
        public static bool InsertPackage(string PkgName, DateTime PkgStartDate, DateTime PkgEndDate, string PkgDesc, decimal PkgBasePrice, decimal PkgAgencyCommission)
        {
            string sql = "INSERT INTO Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) ";
            sql += "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@PkgName", PkgName);
            command.Parameters.AddWithValue("@PkgStartDate", PkgStartDate);
            command.Parameters.AddWithValue("@PkgEndDate", PkgEndDate);
            command.Parameters.AddWithValue("@PkgDesc", PkgDesc);
            command.Parameters.AddWithValue("@PkgBasePrice", PkgBasePrice);
            command.Parameters.AddWithValue("@PkgAgencyCommission", PkgAgencyCommission);
            return DB.updateRow(command);
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
