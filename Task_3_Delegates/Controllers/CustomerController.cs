using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Task_3_Delegates.Data;
using Task_3_Delegates.Models;

 // public delegate List<Customer> DelName(IList<Customer> customers);

namespace Task_3_Delegates.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext db;
        public delegate List<Customer> delName(IList<Customer> customers);
        public delegate List<Customer> delLahoreName(IList<Customer> customers);
        public delegate List<Customer> delAge(IList<Customer> customers);
        public delegate int delTotal(IList<Customer> customers);
        public CustomerController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult NameLahore()
        {
            delName objName = delegate (IList<Customer> _customer)
            {
                ////List<Customer> customers1 = new List<Customer>();
                //Customer customers1 = new Customer();
                //foreach (var item in customers)
                //{
                //     customers.Where(x => x.Name.Equals("Lahore") || x.Name.Equals("lahore"));
                //    return customers1;
                //}
                //var customer = customers.Where(x => x.City == "Lohore" || x.City == "lahore").ToList();
                var customer = _customer.Where(c => c.City.Equals("Lahore") || c.City.Equals("lahore")).ToList();
                return customer;
            };
            var listLahore = objName(db.Customers.ToList());
            List<String> CNames = new List<string>();
            foreach (var c in listLahore)
            {
                CNames = CNames.Append(c.Name).ToList();
            }
            return View(CNames);
        }

        [HttpGet]
        public IActionResult GetLahoreName()
        {
            delLahoreName objName = delegate (IList<Customer> customer)
            {
                ////List<Customer> customers1 = new List<Customer>();
                //Customer customers1 = new Customer();
                //foreach (var item in customers)
                //{
                //     customers.Where(x => x.Name.Equals("Lahore") || x.Name.Equals("lahore"));
                //    return customers1;
                //}
                var customers = customer.Where(x => x.City == "Lahore" || x.City == "lahore").ToList();
                //var customer = _customer.Where(c => c.City.Equals("Lahore") || c.City.Equals("lahore")).ToList();
                return customers;
            };
            var listLahore = objName(db.Customers.ToList());
            
            return View(listLahore);
        }

        [HttpGet]
        public IActionResult GetAge()
        {
            delAge objAge = delegate (IList<Customer> customers)
            {
                var age = customers.Where(x => x.Age >= 55 && x.Age <= 60).ToList();
                return age;
            };

            var ageList = objAge(db.Customers.ToList());
            return View(ageList);
        }

        //[HttpGet]
        //public IActionResult GetTotal()
        public void GetTotal()
        {
            delTotal objToatl = delegate (IList<Customer> customers)
            {
                int Total = 0;
                foreach (var item in customers)
                {
                    Total += item.GrantTotal;
                }
                return Total;
            };
            var total = objToatl (db.Customers.ToList());

            ViewData["Total"] = total;
            ViewBag.Total = total;
            // return View(Total);
        }

        ////public   IActionResult GetCity(List<Customer> customers)
        //public static void GetCity(List<Customer> customers)
        //{
        //    StateName stateName = new StateName(List < Customer > customers)


        //    var customer = db.Customers.Where(x => x.City == "Lahore" || (x.City == "lahore"));
        //    return View(customer);
               
               ////var customer = _customer.Where(c => c.City.Equals("Lahore") || c.City.Equals("lahore")).ToList();
               //// return customer;
       
        //}


        //private static List<Customer> CityName(List<Customer> customers)
        //{
        //    //StateName stateName= new StateName(x=>x.Select(x =>x.City=="Lohore") || (x=>x.City=="lahore"));
        //    StateName stateName = new StateName(List(Customer).Select(x=>x.City == "Lahore"));
        //    return customers;
        //}

        public IActionResult Index()
        {
            GetTotal();
            var list = db.Customers.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            //var create = db.Customers.Where(x => x.Id == obj.Id);
            db.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //public static string City( string city)
        //{
        //    if(city == "Lohore")
        //    {

        //    }
        //}
    }
}
