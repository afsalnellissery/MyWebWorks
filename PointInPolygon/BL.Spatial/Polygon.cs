using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using BL.Spatial.DL;
using System.Data;
using System.Data.Entity.Core;
using BL.Spatial.Model;
using BL.Spatial.Utility;
using System.Globalization;

namespace BL.Spatial
{
    public static class Polygon
    {

        public static void SaveLocation(List<PolygonModel> data)
        {
            string location = PolygonString.PolygonToString(data,"POLYGON");

            using (var con = new SpatialDBEntities())
            {

             

                tbl_location loc = new tbl_location();
                loc.Location = DbGeography.FromText(location, 4326);


                con.tbl_location.Add(loc);
                con.SaveChanges();

            }


        }


        public static object GetPlace(List<PolygonModel> data)
        {
            string location = PolygonString.PolygonToString(data,"POLYGON");
            DbGeography geoLocation = DbGeography.FromText(location, 4326);

            object response;
            using (var con = new SpatialDBEntities())
            {

                response = con.SearchGeoLocation_sp(geoLocation).ToList();

            }

            return response;
        }


    }
}
