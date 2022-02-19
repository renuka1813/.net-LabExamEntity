using MVCLabExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLabExam.Controllers
{
    public class ProductsController : Controller
    {
        SqlConnection cn = new SqlConnection();

        [ChildActionOnly]
        public ActionResult PartialViewLab()
        {
            return View();
        }
        public ActionResult Layout()
        {
            return View();
        }
        // GET: Products
        public ActionResult Index()
        {
            List<Product> pro = new List<Product>();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=products;Integrated Security=True;Connect Timeout=30";
            cn.Open();

            SqlCommand index = new SqlCommand();
            index.Connection = cn;
            index.CommandType = System.Data.CommandType.StoredProcedure;
            index.CommandText = "IndexData";

            try
            {
                SqlDataReader dr = index.ExecuteReader();
                while(dr.Read())
                {
                    pro.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Rate = (int)(decimal)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName= (string)dr["CategoryName"],

                    });
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(pro);
         
            
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            /* cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=products;Integrated Security=True;Connect Timeout=30";
             cn.Open();

             SqlCommand cmdedit = new SqlCommand();
             cmdedit.Connection = cn;
             cmdedit.CommandType = System.Data.CommandType.Text;
             cmdedit.CommandText = "select*from Products where ProductId=@id";
             cmdedit.Parameters.AddWithValue("@id", id);
             Product obj = null;
             try
             {
                 SqlDataReader dr = cmdedit.ExecuteReader();
                 if(dr.Read())
                 {
                     obj = new Product()
                     {
                         ProductId = (int)dr["ProductId"],
                         ProductName = (string)dr["ProductName"],
                         Rate = (int)(decimal)dr["Rate"],
                         Description = (string)dr["Description"],
                         CategoryName = (string)dr["CategoryNam"]
                     };
                     dr.Close();
                     return View(obj);

                 }
             }
             catch(Exception e)
             {
                 return RedirectToAction("Index");
             }
             finally
             {
                 cn.Close();
             }*/
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product pro)
        {
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=products;Integrated Security=True;Connect Timeout=30";
            cn.Open();

            SqlCommand cmdedit = new SqlCommand();
            cmdedit.Connection = cn;
            cmdedit.CommandType = System.Data.CommandType.StoredProcedure;
            cmdedit.CommandText = "EditData";
            cmdedit.Parameters.AddWithValue("@ProductName", pro.ProductName);
            cmdedit.Parameters.AddWithValue("@Rate", pro.Rate);
            cmdedit.Parameters.AddWithValue("@Description", pro.Description);
            cmdedit.Parameters.AddWithValue("@CategoryName", pro.CategoryName);
            try
            {
                // TODO: Add update logic here
                cmdedit.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
/*List<Product> pro = new List<Product>();
cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=products;Integrated Security=True;Connect Timeout=30";
cn.Open();

SqlCommand index = new SqlCommand();
index.Connection = cn;
index.CommandType = System.Data.CommandType.StoredProcedure;
index.CommandText = "IndexData";

try
{
    SqlDataReader dr = index.ExecuteReader();
    while (dr.Read())
    {
        pro.Add(new Product
        {
            ProductId = (int)dr["ProductId"],
            ProductName = (string)dr["ProductName"],
            Rate = (int)(decimal)dr["Rate"],
            Description = (string)dr["Description"],
            CategoryName = (string)dr["CategoryName"],

        });
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    cn.Close();
}
retur
*/