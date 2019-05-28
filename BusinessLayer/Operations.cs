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

        public static List<Package> GetPackages()
        {

            return new List<Package>();
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



        public static List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT o.OrderID, o.CustomerID, CONVERT(date, o.OrderDate) as OrderDate, CONVERT(date, o.RequiredDate) as RequiredDate, CONVERT(date, o.ShippedDate) as ShippedDate, ";
            sql += "od.ProductID, od.UnitPrice, od.Quantity, od.Discount, (od.UnitPrice * od.Quantity * (1 - od.Discount)) as OrderTotal ";
            sql += "FROM Orders as o ";
            sql += "JOIN [Order Details] as od ON o.OrderID = od.OrderID";
            DataRowCollection rows = DB.getRows(sql);
            foreach (DataRow row in rows)
            {
                Order order = new Order
                {
                    //OrderID = Convert.ToInt32(row["OrderID"]),
                    //CustomerID = row["CustomerID"].ToString(),
                    //OrderDate = getValue(row, "OrderDate"),
                    //RequiredDate = getValue(row, "RequiredDate"),
                    //ShippedDate = getValue(row, "ShippedDate"),
                    //ProductID = Convert.ToInt32(row["ProductID"]),
                    //UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    //Quantity = Convert.ToInt32(row["Quantity"]),
                    //Discount = Convert.ToDecimal(row["Discount"]),
                    //OrderTotal = Convert.ToDecimal(row["OrderTotal"])
                };
                orders.Add(order);
            }
            return orders;
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
