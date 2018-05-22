using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efrat.Dal.EntitiesData
{
    public class FollowMeData
    {

        public object GetColors()
        {
            using (FollowMeEntities context = new FollowMeEntities())
            {
                var list =
                    context.Colors.ToArray().Select(x => new { ID = x.ColorId, Value = x.Name + " - " + x.Name }).ToList();
                return list;
            }
        }


        public object GetProcess()
        {
            using (FollowMeEntities context = new FollowMeEntities())
            {
                var list =
                    context.Process.ToArray().Select(x => new { ID = x.ProcessId, Value = x.Name}).ToList();
                return list;
            }
        }

         public object GetProcessByProcessId(int ProcessId)
        {
            using (FollowMeEntities context = new FollowMeEntities())
            {
                var list =
                    context.Process.ToArray().Where(P => P.ProcessId == ProcessId).ToList();
                return list;
            }
        }

         public object GetOwners()
         {
             using (FollowMeEntities context = new FollowMeEntities())
             {
                 var list =
                     context.Owners.ToArray();
                 return list;
             }
         }

         public object GetArchiveOrdersByOwnerId(int OwnerId)
         {
             using (FollowMeEntities context = new FollowMeEntities())
             {
                 var list =
                     context.ActiveOrder.ToArray().Where(P => P.OwnerId == OwnerId).ToList();
                 return list;
             }
         }

         public object GetStation()
         {
             using (FollowMeEntities context = new FollowMeEntities())
             {
                 var list =
                     context.Station.ToArray().Select(x => new { ID = x.StationId, Value = x.Name}).ToList();
                 return list;
             }
         }

         public bool DeleteStationByStationId(int StationId )   
        {
            //int result;
            //using (FollowMeEntities ctx = new FollowMeEntities())
            //{
            //    result = ctx.Spp_DeleteStationByStationId(StationId);
                      
            //}

            return true;
        }
          


    }
}
