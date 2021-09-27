using PlateformServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformServices.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlateform(Plateform plate)
        {
            if(plate == null)
            {
                throw new ArgumentNullException(nameof(plate));
            }
            _context.Plateforms.Add(plate);

        }

        public IEnumerable<Plateform> GetAllPlatforms()
        {
            return _context.Plateforms.ToList();
        }

        public Plateform GetPlateformId(int id)
        {
            return _context.Plateforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
