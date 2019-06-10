using System;
using System.Collections.Generic;
using VSCode.Models.bohater;

namespace VSCode.Controllers
{
    public interface IAppRepository
    {
        ICollection<Bohater> Bohaterowie {get;}

        void SaveAsync();
    }
}