using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using ModeloVeroco;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VerocoController : ApiController
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        [HttpGet]
        public HttpResponseMessage Get(string producto = "All")
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (producto.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "El valor debe ser Limitado. " + producto + " is invalid.");
                }
            }
        }

    }
}
