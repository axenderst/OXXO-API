using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Oxxo2.Controllers
{
    public class EnableStats
    {

        public bool CheckAvailability()
        {

                using (var context = new Oxxo2.DataAccess.OxxoContext())
                {
                    var BtEnableStatus = context.Enabled.FromSql("spGetEnableStatus").ToList();
                    bool isActive = bool.Parse(BtEnableStatus.ElementAt(0).IsActive.ToString());

                    if (isActive)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }               
        }

        public bool SetStats()
        {

            using (var context = new Oxxo2.DataAccess.OxxoContext())
            {
                var BtEnableStatus = context.Enabled.FromSql("spUpdEnablerStatus").ToList();
                bool isActive = bool.Parse(BtEnableStatus.ElementAt(0).IsActive.ToString());

                if (isActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


    }

  
}
   