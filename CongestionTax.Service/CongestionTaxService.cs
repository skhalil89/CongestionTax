using CongestionTax.Data;
using CongestionTax.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongestionTax.Service
{
    public class CongestionTaxService : ICongestionTaxService
    {

        private readonly CongestionDbContext _dbContext;
        public CongestionTaxService(CongestionDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<double> GetTax(Guid cityId, Vehicle vehicle, List<DateTime> dates)
        {
            DateTime intervalStart = dates[0];
            double totalFee = 0;
            double maxFeeInInterval = 0;

            foreach (DateTime date in dates)
            {
                double nextFee = await GetTollFee(cityId, date, vehicle);
                if (GetMinutesDifference(intervalStart, date) <= 60)
                {
                    maxFeeInInterval = Math.Max(maxFeeInInterval, nextFee);
                }
                else
                {
                    totalFee += maxFeeInInterval;
                    intervalStart = date;
                    maxFeeInInterval = nextFee;
                }
            }

            totalFee += maxFeeInInterval; // Add fee for the last interval
            return Math.Min(totalFee, 60); // Ensure max SEK 60 cap
        }

        int GetMinutesDifference(DateTime start, DateTime end)
        {
            return (int)(end - start).TotalMinutes;
        }

        private async Task<double> GetTollFee(Guid cityId, DateTime entryTime, Vehicle vehicle)
        {

            if (await IsTollFreeDate(entryTime) || IsTollFreeVehicle(vehicle)) return 0;

            //_dbContext.Database.EnsureCreated();

            var hour = entryTime.TimeOfDay;
            var tariff = await _dbContext.TaxRates
                .FirstOrDefaultAsync(t => t.CityId == cityId &&

                hour >= t.StartTime && hour <= t.EndTime);

            return tariff?.Amount ?? 0;
        }

        private async Task<bool> IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            return await _dbContext.Exemption.AnyAsync(d => d.StartDate >= date && d.EndDate <= date);
        }

        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            var vehicleType = vehicle.GetVehicleType();
            Enum. TollFreeVehicles
            return true;
        }

    }
}
