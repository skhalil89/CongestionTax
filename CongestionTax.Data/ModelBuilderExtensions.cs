using CongestionTax.Domain;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var GutenbergCityId = new Guid();

        modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = GutenbergCityId,
                MaxDailyCharge = 60,
                Name = "Gutenberg",
            }
        );
        modelBuilder.Entity<TaxRate>().HasData(
            new TaxRate
            {
                Id = new Guid(),
                CityId = GutenbergCityId,
                StartTime = new TimeSpan(6, 0, 0),
                EndTime = new TimeSpan(6, 30, 0),
                Amount = 8,
            },
            new TaxRate
            {
                Id = new Guid(),
                CityId = GutenbergCityId,
                StartTime = new TimeSpan(6, 30, 0),
                EndTime = new TimeSpan(7, 0, 0),
                Amount = 8,
            },
            new TaxRate
            {
                Id = new Guid(),
                CityId = GutenbergCityId,
                StartTime = new TimeSpan(7, 0, 0),
                EndTime = new TimeSpan(7, 30, 0),
                Amount = 8,
            }
        );
    }
}
