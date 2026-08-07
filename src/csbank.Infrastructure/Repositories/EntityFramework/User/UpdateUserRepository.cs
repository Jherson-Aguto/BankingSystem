using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Domain.Entities;
using CSBank.Infrastructure.Database.Connections;
using Microsoft.EntityFrameworkCore;

namespace CSBank.Infrastructure.Repositories.EntityFrameworkCore;

public class UpdateUserRepository(AppDbContext context) : IUpdateUserRepository
{
    public async Task<Customer?> UpdateUserDetails(UpdateUserRequest? dto)
    {
        bool exists = await context.Customers.AnyAsync(x => x.Id == dto!.Id);

        if (!exists)
            return null;

        Customer? result = await UpdateUserAggregate(dto);

        if (result is null)
            return null;

        await context.SaveChangesAsync();

        return result;
    }

    private async Task<Customer?> UpdateUserAggregate(UpdateUserRequest? dto)
    {
        Customer? customer = await context.Customers
        .Include(p => p.PrivateInformation)
        .SingleOrDefaultAsync(x => x.Id == dto!.Id);

        if (customer is null)
            return null;

        customer.UpdateFirstName(dto?.FirstName);
        customer.UpdateLastName(dto?.LastName);
        customer.UpdateMiddleInitial(dto?.MiddleInitial);
        customer.UpdateSuffix(dto?.Suffix);
        customer.PrivateInformation.UpdateEmail(dto?.Email);
        customer.PrivateInformation.UpdateCountry(dto?.Country);
        customer.PrivateInformation.UpdateCity(dto?.City);
        customer.PrivateInformation.UpdateProvince(dto?.Province);
        customer.PrivateInformation.UpdatePhoneNumber(dto?.PhoneNumber);
        customer.PrivateInformation.UpdateNationality(dto?.Nationality);
        customer.PrivateInformation.UpdateBirthDate(dto?.BirthDate);

        return customer;
    }

}