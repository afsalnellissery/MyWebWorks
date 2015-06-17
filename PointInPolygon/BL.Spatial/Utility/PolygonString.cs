using BL.Spatial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Spatial.Utility
{
    public static class PolygonString
    {
       // "POLYGON((-122.358 47.653 , -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))";

        //POLYGON((147.002563476563 -34.1345416819374,149.326171875 -33.5825911639392,148.826293945313 -34.8183131456094,147.233276367188 -34.329828328362))
        public static string PolygonToString(List<PolygonModel> polygon,string shape)
        {

            string geoLocation = shape+"((";
            int len = polygon.Count;
            for (int i = 0; i < polygon.Count; i++)
            {
                geoLocation += polygon[i].F + " " + polygon[i].A + ",";
            }

            geoLocation += polygon[0].F + " " + polygon[0].A;
            geoLocation+="))";

            

            return geoLocation;
        }


    }


    
}
