namespace Tkf_Complaint_System.Data
{
    using Microsoft.EntityFrameworkCore;
    using Tkf_Complaint_System.Models;

    public static class Seeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed provinces
            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceId = 1, ProvinceName = "Baluchistan" },
                new Province { ProvinceId = 2, ProvinceName = "Sindh" }
            );

            // Seed districts
            modelBuilder.Entity<District>().HasData(
                new District { DistrictId = 1, DistrictName = "Karachi", ProvinceId = 2 },
                new District { DistrictId = 2, DistrictName = "Quetta", ProvinceId = 1 }
            );
            // Seed cities
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Karachi", DistrictId = 1 },
                new City { CityId = 2, CityName = "Quetta", DistrictId = 2 }
            );
            // Seed UCs
            modelBuilder.Entity<UC>().HasData(
                new UC { UCId = 1, UCName = "North Karachi", CityId = 1 },
                new UC { UCId = 2, UCName = "Quetta Mariabad", CityId = 2 }
            );

            // Seed Villages
            modelBuilder.Entity<Village>().HasData(
                new Village {  VillageId = 1, VillageName = "village1", UCId = 1 },
                new Village { VillageId = 2, VillageName = "Quetta", UCId = 2 }
            );

            // Seed projects
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, ProjectName = "UNICEF - KHI", VillageId = 1 },
                new Project { ProjectId = 2, ProjectName = "UNICEF - Quetta", VillageId = 2 }
            );
        }
    }
}
