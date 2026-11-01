using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Domain.Entities;
using CSBank.Infrastructure.Database.Connections;
using Microsoft.EntityFrameworkCore;

namespace CSBank.Infrastructure.Repositories.EntityFrameworkCore;

public class UpdateUserRepository(AppDbContext context) : IUpdateUserRepository
{
    public async Task<Customer?> UpdateUserDetails(UpdateUserRequest? dto, CancellationToken cancellationToken)
    {
        bool exists = await context.Customers.AnyAsync(x => x.Id == dto!.Id, cancellationToken);

        if (!exists)
            return null;

        Customer? result = await UpdateUserAggregate(dto, cancellationToken);

        if (result is null)
            return null;

        await context.SaveChangesAsync(cancellationToken);

        return result;
    }

    private async Task<Customer?> UpdateUserAggregate(UpdateUserRequest? dto, CancellationToken cancellationToken)
    {
        Customer? customer = await context.Customers
        .Include(p => p.PrivateInformation)
        .SingleOrDefaultAsync(x => x.Id == dto!.Id, cancellationToken);

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