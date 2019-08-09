using System;
using System.Collections.Generic;
using System.Text;

namespace TOPMS.Services.Common
{
    public static class GlobalConstants
    {
        public const string UserRolesString = "Admin, PowerUser, User, Forwarder";

        public const string ServicesString = "AirCargo, AirExpress, AirEconomy, Express, Economy, FTL, LTL, FCL, LCL, CourierOnBoard, Special";

        public const string StatusesString = "Submitted, Offered, Ordered, InTransit, Delivered, Finished, Cancelled, Expired";

        public const string TransportsString = "ByAir, ByRoad, BySea, Combined, SpecialRequest";

        public const string AreasString = "World, Europe, Asia, Australia, Africa, NorthAmerica, SouthAmerica, Bulgaria";
    }
}
