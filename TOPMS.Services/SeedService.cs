using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TOPMS.Data;
using TOPMS.Models;
using TOPMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;


namespace TOPMS.Services
{
    public class SeedService : ISeedService
    {
        private readonly TOPMSContext _context;
        private readonly IServiceProvider _serviceProvider;

        public SeedService(TOPMSContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }


        public void SeedAreas(string areasString)
        {
            var areasList = areasString.Split(", ").ToList();
            List<AreaOfService> areas = new List<AreaOfService>();

            foreach (var areaName in areasList)
            {
                var areaExist = _context.AreaOfService.FirstOrDefault(a => a.Name == areaName);

                if (areaExist == null)
                {
                    areas.Add(new AreaOfService { Name = areaName });
                }
            }

            _context.AreaOfService.AddRange(areas);
        }

        public void SeedServices(string servicesString)
        {
            var servicesList = servicesString.Split(", ").ToList();
            List<Service> services = new List<Service>();

            foreach (var serviceName in servicesList)
            {
                var serviceExist = _context.Services.FirstOrDefault(s => s.Name == serviceName);

                if (serviceExist == null)
                {
                    services.Add(new Service { Name = serviceName });
                }
            }

            _context.Services.AddRange(services);
        }

        public void SeedStatuses(string statusesString)
        {
            var statusesList = statusesString.Split(", ").ToList();
            List<Status> statuses = new List<Status>();

            foreach (var statusName in statusesList)
            {
                var statusExist = _context.Status.FirstOrDefault(a => a.Name == statusName);

                if (statusExist == null)
                {
                    statuses.Add(new Status { Name = statusName });
                }
            }

            _context.Status.AddRange(statuses);
        }

        public void SeedTransports(string transportsString)
        {
            var transportsList = transportsString.Split(", ").ToList();
            List<Transport> transports = new List<Transport>();

            foreach (var transportName in transportsList)
            {
                var transportExist = _context.Transports.FirstOrDefault(a => a.Name == transportName);

                if (transportExist == null)
                {
                    transports.Add(new Transport { Name = transportName });
                }
            }

            _context.Transports.AddRange(transports);
        }

        public void SeedRoles(string rolesString)
        {
            var RoleManager = _serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<AppRole>>();
            var rolesAndDescrList = rolesString.Split(", ").ToList();

            for (int i = 0; i < rolesAndDescrList.Count - 1; i += 2)
            {
                var roleExist = RoleManager.RoleExistsAsync(rolesAndDescrList[i]).GetAwaiter().GetResult();

                if (!roleExist)
                {
                    RoleManager.CreateAsync(new AppRole() { Name = rolesAndDescrList[i], Descrition = rolesAndDescrList[i+1] });
                }
            }
        }
    }
}
