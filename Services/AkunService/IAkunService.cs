using Sibolga_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibolga_Library.Services.AkunService
{
    public interface IAkunService
    {
        bool CreateUser(GabungModel gabungModel);

        bool CreatePemasok(GabungModel gabungModel);
    }
}
