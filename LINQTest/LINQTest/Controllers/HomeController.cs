using System.Diagnostics;
using System.IO.Compression;
using LINQTest.Data;
using LINQTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LINQTest.Controllers
{
    public class HomeController : Controller
    {
        NorthwindContext db = new NorthwindContext();


        public IActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }
        public IActionResult ProductList()
        {
            //product listesi
            return View(db.Products.ToList());
        }
        public IActionResult KayitSecme()
        {
            ViewBag.Name = db.Products.Select(p => p.ProductName).ToList(); //productName se�ilir
            //Birden fazla �zellik se�me
            ViewBag.NamePrice = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).ToList();
            //Yukar�daki gibi cshtml e veri g�ndermek yerine Model olu�turum g�ndeririz.
            var namePrice = db.Products.Select(p =>
            new ProductModel
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
            }
            ).ToList();
            //ilk kay�t
            var firstRecorder = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();

            //Filtreleme
            //fiyat 18 den b�y�k olanlar
            var products = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).Where(p => p.UnitPrice > 18).ToList();

            //Birden fazla kriter ekleme
            products = db.Products.Select(p => new { p.ProductName, p.UnitPrice })
                            .Where(p => p.UnitPrice > 18 && p.UnitPrice < 30).ToList();
            //Kategori
            var products2 = db.Products.Where(p => p.CategoryId == 1).ToList();

            //Filtreleme yap�ld�ktan sonra  kolon se�me i�lemi yap�l�r
            var products3 = db.Products.Where(p => p.CategoryId == 1).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
            //
            var product4 = db.Products.Where(p => p.ProductName.Contains("Ch")).ToList();

            //Almanyada ya�ayanlar�n isimleri
            ViewBag.Almanya = db.Customers.Select(c => new { c.ContactName, c.Country }).Where(c => c.Country == "Germany").ToList();
            //Diego Roel m��teri nerede ya�ar.
            var customer = db.Customers.Select(c => new { c.ContactName, c.Country })
                                .Where(c => c.ContactName == "Diego Roel").FirstOrDefault();

            //Stokta olmayan �r�nler
            ViewBag.productInventoryEmpty = db.Products.Where(p => p.UnitsInStock == 0).Select(p => p.ProductName).ToList();

            var employees = db.Employees.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
            }).ToList();

            //ilk 5 kay�t
            var prod = db.Products.Take(5).ToList();

            // sonraki 5
            var prod2 = db.Products.Skip(5).Take(5).ToList();


            return View();
        }

        public IActionResult KayitEkleme()
        {
            var category = db.Categories.Where(c => c.CategoryName == "Beverages").FirstOrDefault();
            var p1 = new Product() { ProductName = "yeni �r�n 1", Category = new Category() { CategoryName = "Yeni Kategori 1" } };
            var p2 = new Product() { ProductName = "yeni �r�n 2", Category = category };

            var products = new List<Product>() { p1, p2 };
            db.Products.AddRange(products);
            return View(products);

        }

        public IActionResult SiralamaHesaplama()
        {
            //�r�n say�s�
            var result = db.Products.Count();
            //Belirli kriter
            result = db.Products.Count(i => i.UnitsInStock > 10 && i.UnitPrice < 30);
            //sat��ta olmayanlar - 
            var satis = db.Products.Count(i => i.Discontinued);
            //min fiyat
            var minPrice = db.Products.Min(i => i.UnitPrice);
            //fiyat ortalamas� - sat��ta olan
            var result2 = db.Products.Where(p => !p.Discontinued).Average(i => i.UnitPrice);
            //fiyat toplam� - sat��ta olan
            var total = db.Products.Where(p => !p.Discontinued).Sum(i => i.UnitPrice);

            //K���kten b�y��e
            var sirala = db.Products.OrderBy(p => p.UnitPrice);
            var sirala2 = db.Products.OrderByDescending(p => p.UnitPrice);

            return View();
        }
        //
        public IActionResult CokluTablo()
        {
            //yazd�rmak istedi�imizde sadece product daki categoriId yaz�labilir. CategoryName yaz�lmaz
            var result = db.Products.Where(p => p.Category.CategoryName == "Beverages").ToList();
            //yazmak i�in, category dahil ettik
            result = db.Products.Include(p => p.Category).Where(p => p.Category.CategoryName == "Beverages").ToList();
            //
            var result2 = db.Products
                .Where(p => p.Category.CategoryName == "Beverages")
                .Select(c => new
                {
                    name = c.ProductName,
                    id = c.CategoryId,
                    category = c.Category.CategoryName
                })
                .ToList();

            //hangi kategorinin �r�nleri yok
            var categories = db.Categories.Where(c => c.Products.Count() == 0).ToList();

            categories = db.Categories.Where(c => c.Products.Any()).ToList(); //herhangi bir kay�t var m�? Persormansl�

            //tedarik�i adlar�
            var products = db.Products.Select(s => new
                                            {
                                                companyName = s.Supplier.ContactName,
                                                contactName = s.Supplier.ContactName,
                                            });


            //query expression
            var prod = (from p in db.Products
                        where p.UnitPrice > 10
                        select p).ToList();

            //  sipari�i olan m��teriler
            //var customers = db.Customers.Where(c=>c.Orders.Count()>0).Select(c=>new {c.ContactName}).ToList();
            var customers = db.Customers.Where(c => c.Orders.Any())
                .Select(c => new { 
                    CustomerId = c.CustomerId,
                    c.ContactName,
                    OrderCount=c.Orders.Count(),
                    Orders = c.Orders.Select(order=>new
                    {
                        OrderId = order.OrderId,
                        Total = order.OrderDetails.Sum(od=>od.Quantity * od.UnitPrice),
                        Products = order.OrderDetails.Select(od=>new ProductModel
                        {
                            ProductId = od.ProductId,
                            Name = od.Product.ProductName,
                            Price = od.UnitPrice
                        })
                    }).ToList(),
                })
                .OrderBy(c => c.OrderCount)
                .ToList();

            return View();
        }

        public IActionResult KlasikSorgu()
        {
            var sonuc = db.Database.ExecuteSqlRaw("delete from products where productId=81");
            return View();
        }


    }
    public class CustomerModel
    {
        public CustomerModel()
        {
            this.Orders = new List<OrderModel>();
        }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
        public List<OrderModel> Orders { get; set; }
    }

    public class OrderModel
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public List<ProductModel> Products { get; set; }
    }

    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
