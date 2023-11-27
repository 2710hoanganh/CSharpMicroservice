using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlaformRepo : IPlatformRepo
    {
        private AppDbContext _context;

        public PlaformRepo(AppDbContext appDbContext)
        {
            _context = appDbContext ;
        }


        public void CreatePlafrom(Platform platform)
        {
            try
            {
                if(platform is null){
                    throw new ArgumentNullException(nameof(platform));
                }
                _context.Platforms.Add(platform);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id.Equals(id));
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}