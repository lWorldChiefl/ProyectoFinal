using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using ModeloVeroco;
using System.Threading;

namespace Veroco_Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VerocoController : ApiController
    {

        public HttpResponseMessage Get(string producto = "All")
        {
            using (Proyecto_VerocoEntities entities = new Proyecto_VerocoEntities())
            {
                switch (producto.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Productos.ToList());
                    case "limitado":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Productos.Where(u => u.productStock <= 10).ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "El valor debe ser Limitado. " + producto + " is invalid.");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromUri]int id, IEnumerable<Detalle> detalle)
        {
            using (Proyecto_VerocoEntities entities = new Proyecto_VerocoEntities())
            {
                var valor = entities.Facturas.Where(e => e.detailsId == id);
                Factura factura = new Factura();

                factura.invoiceDate = DateTime.Now;
                factura.detailsId = id;
                factura.userId = id;

                entities.Facturas.Add(factura);

                foreach (var model in detalle)
                {
                    model.detailsId = factura.detailsId ?? default(int);
                    entities.Detalles.Add(model);
                }
                entities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
