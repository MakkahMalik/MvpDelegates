using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using MVPdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace MVPdemo.Data
{
    public class DatabaseHelper
    {

        private readonly Database _db;
        public DatabaseHelper()
        {
            var factory = new DatabaseProviderFactory();
            _db = factory.Create("data");
        }
        public void AddProduct(Product product)
     {
            string query = "Insert into products (Name, Description) Values(@name , @description)";
            using (DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@name", DbType.String, product.Name);
                _db.AddInParameter(cmd, "@description", DbType.String, product.Description);
                _db.ExecuteNonQuery(cmd);
            }


        }  //end addproduct;
        public List<Product> GetProduct()
        {
            string query = "Select * from products";
            using(DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                using(IDataReader  reader = _db.ExecuteReader(cmd))
                {
                    var product = new List<Product>();
                    while (reader.Read())
                    {
                        product.Add(new Product { 
                            Id = reader.GetInt32(0),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                        
                        });
                    }

                    return product;
                }
            }

        } //end Getproduct;
        public void DeleteProduct(int id)
         {
            string query = "Delete from products where Id = @id  ";
            using(DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd , "@id" , DbType.Int32, id);
                _db.ExecuteNonQuery(cmd);
            }

        }  //end Deleteproduct;
        public void UpdateProduct( Product product)
        {
            string query = "update products set Name  = @name , Description = @description where Id = @id";
            using(DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@name", DbType.String, product.Name);
                _db.AddInParameter(cmd , "@description" , DbType.String , product.Description);
                _db.AddInParameter(cmd , "@id" , DbType.Int32, product.Id);
                _db.ExecuteNonQuery(cmd);
            }
        }  //end Updateproduct;
        public Product GetProductById(int id)
        {
            string query = "SELECT * FROM products WHERE Id = @id";
            using (DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@id", DbType.Int32, id);
                using (IDataReader reader = _db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                    }
                }
            }
            return null;
        }  //end getbyId;


    } //main class
} //namespace