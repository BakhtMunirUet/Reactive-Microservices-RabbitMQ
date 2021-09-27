using PlateformServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Plateform> GetAllPlatforms();
        Plateform GetPlateformId(int id);
        void CreatePlateform(Plateform plate);
    }
}
