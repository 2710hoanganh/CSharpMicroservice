using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PreDbData
    {
        public static void PrePopulation(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext appDbContext){
            if(!appDbContext.Platforms.Any())
            {
                Console.WriteLine("Seeding data!");
                appDbContext.Platforms.AddRange(
                    new Platform() {Id=1,Name="Dotnet", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Id=2,Name="SQLServer", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Id=3,Name="MongoDb", Publisher="MongoDb", Cost="Free"},
                    new Platform() {Id=4,Name="Nodejs", Publisher="Node", Cost="Free"},
                    new Platform() {Id=5,Name="Nestjs", Publisher="Nest", Cost="Free"}
                );
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data!");
            }
        }
    }
}