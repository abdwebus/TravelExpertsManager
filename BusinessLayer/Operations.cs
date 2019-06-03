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
            
            List<Supplier> suppliers = new List<Supplier>();
            string sql = "SELECT SupplierID, SupName FROM Suppliers";
            DataRowCollection rows = DB.getRows(sql);

            foreach(DataRow row in rows)
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

        public static List<Product> GetProducts() {

            return new List<Product>();
        }

        public static Package GetPackage(int packageId) {

            return new Package();
        }

        public static Supplier GetSupplier(int supplierId)
        {
            Supplier p = new Supplier();
            string sql = "SELECT SupplierId, SupName FROM Suppliers WHERE ID =" + supplierId;

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

            string sql = "UPDATE Suppliers SET  SupName = @SupName WHERE SupplierId = @SupplierId";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@SupplierId", supplierId);
            command.Parameters.AddWithValue("@SupName", supName);
            return DB.updateRow(command);


            //return true;
        }

        public static bool UpdateProduct(int productId, string prodName, int supplierId)
        {

            return true;
        }

        public static bool InsertPackage(string supName)
        {

            return true;
        }

        public static bool InsertSupplier(int SupplierID, string supName)
        {
            //get current maximum id, so I can add 1 later
            string getmax = "SELECT MAX(SupplierId) FROM Suppliers";
            SqlCommand max = new SqlCommand(getmax);
            int maxid;
            maxid = DB.DoScalar(max);


            string sql = "INSERT into Suppliers (SupplierId, SupName) values ( @supplierId,@supName)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@supplierId", maxid + 1);//add 1 so the new ID is quaranteed to be unique ()
            command.Parameters.AddWithValue("@supName", supName);
            return DB.updateRow(command);
           
           
        }

        public static bool InsertProduct(Product product)
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
