using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChange();
        List<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlafrom(Platform platform);
    }
}