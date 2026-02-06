using ParkingManagerDomain.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByPhoneAsync(string phone);

        Task<bool> EmailExistsAsync(string email);

        Task<bool> PhoneExistsAsync(string phone);

        Task<User?> GetWithVehiclesAsync(Guid userId);
        Task<User?> GetWithGarageAsync(Guid userId);

        Task<User?> CheckWithGarageIdAsync(Guid garageId);
        Task<User?> CheckWithVehicleIdAsync(Guid vehicleId);

        // Get user with bookings included
        Task<User?> GetWithBookingsAsync(Guid userId);

        // Get user with payments included
        Task<User?> GetWithPaymentsAsync(Guid userId);

        // Get user with complete details (vehicles, bookings, payments)
        Task<User?> GetWithCompleteDetailsAsync(Guid userId);

        Task<IEnumerable<User>> GetByRoleAsync(string role);

        Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);

        Task<IEnumerable<User>> GetActiveUsersAsync();

        // Get users registered within a date range
        Task<IEnumerable<User>> GetUsersByRegistrationDateAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}