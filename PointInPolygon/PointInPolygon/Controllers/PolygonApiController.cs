using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Spatial.Model;
using BL.Spatial;

namespace PointInPolygon.Controllers
{
    public class PolygonApiController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SavePolygon(List<PolygonModel> PolygonModel)
        {


            //Polygon.SaveLocation(PolygonModel);

            object data = Polygon.GetPlace(PolygonModel);


            if (data.ToString() == "[]")
                data = "no schools found this place";

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }


        [HttpGet]
        public   HttpResponseMessage SavePolygon()
        {


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "okay");
            return response;
        }

    }
}
