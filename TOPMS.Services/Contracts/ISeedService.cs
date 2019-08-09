using System;
using System.Collections.Generic;
using System.Text;

namespace TOPMS.Services.Contracts
{
    public interface ISeedService
    {
        void SeedAreas(string areasString);
        void SeedTransports(string transportsString);
        void SeedServices(string servicesString);
        void SeedStatuses(string statusesString);
        void SeedRoles(string rolesAndDescrString);
    }
}
