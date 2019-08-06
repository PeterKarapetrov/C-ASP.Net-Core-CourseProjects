using System;
using System.Collections.Generic;
using System.Text;

namespace TOPMS.Services.Contracts
{
    public interface IAreaService
    {
        bool UserIsAdmin(string userName);
    }
}
