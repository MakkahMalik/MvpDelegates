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
            string query = "Insert into products (Name, Description, CreatedAt, ModifiedAt ) Values(@name , @description ,@createdAt , @modifiedAt  )";
            using (DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@name", DbType.String, product.Name);
                _db.AddInParameter(cmd, "@description", DbType.String, product.Description);
                _db.AddInParameter(cmd, "@createdAt", DbType.DateTime, DateTime.Now);
                _db.AddInParameter(cmd, "@modifiedAt", DbType.DateTime, DateTime.Now);
                _db.ExecuteNonQuery(cmd);
            }


        }  //end addproduct;
        public List<Product> GetProduct()
        {
            string query = "Select * from products where IsDeleted = 0";
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
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            ModifiedAt = reader.GetDateTime(reader.GetOrdinal("ModifiedAt")),
                            IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"))

                        });
                    }

                    return product;
                }
            }

        } //end Getproduct;
        public void DeleteProduct(int id)
         {
            string query = "UPDATE products SET IsDeleted = 1, ModifiedAt = @modifiedAt WHERE Id = @id";
            //string query = "Delete from products where   Id = @id and IsDeleted = 0 ";
            using (DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@modifiedAt", DbType.DateTime, DateTime.Now);
                _db.AddInParameter(cmd , "@id" , DbType.Int32, id);
                _db.ExecuteNonQuery(cmd);
            }

        }  //end Deleteproduct;
        public void UpdateProduct( Product product)
        {
            string query = "update products set Name  = @name , Description = @description  ,ModifiedAt = @modifiedAt  where Id = @id";
            using(DbCommand cmd = _db.GetSqlStringCommand(query))
            {
                _db.AddInParameter(cmd, "@name", DbType.String, product.Name);
                _db.AddInParameter(cmd , "@description" , DbType.String , product.Description);
                _db.AddInParameter(cmd, "@modifiedAt", DbType.DateTime, DateTime.Now);
                _db.AddInParameter(cmd , "@id" , DbType.Int32, product.Id);
                _db.ExecuteNonQuery(cmd);
            }
        }  //end Updateproduct;
        public Product GetProductById(int id)
        {
            string query = "SELECT * FROM products WHERE Id = @id and IsDeleted = 0";
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
                            Description = reader["Description"].ToString(),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            ModifiedAt = reader.GetDateTime(reader.GetOrdinal("ModifiedAt")),
                            IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                        };
                    }
                }
            }
            return null;
        }  //end getbyId;


    } //main class
} //namespace