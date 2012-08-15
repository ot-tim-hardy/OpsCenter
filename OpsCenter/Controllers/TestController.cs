using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpsCenter.Models;

namespace OpsCenter.Controllers
{
    public class TestController : Controller
    {
    	private IDatastore _db = null;

		public TestController(IDatastore db)
		{
			_db = db;
		}
        //
        // GET: /Test/

        public ActionResult Index()
        {
        	List<Configuration> qaConfigs = _db.All<Configuration>().Where(c => c.Environment == "QA").ToList();
			return View(qaConfigs);
        }

    }
}
