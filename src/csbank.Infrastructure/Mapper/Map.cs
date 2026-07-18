using CSBank.Application.Models;

namespace CSbank.Infrastructure.Mapper;

public static class Map
{
    internal static Object ToParameters(PrivateInfoDto privateInformation, CustomerDto customerDetails)
    {
        return new
        {
            firstName = customerDetails.FirstName,
            lastName = customerDetails.LastName,
            suffix = customerDetails.Suffix,
            registrationDate = DateTime.UtcNow,
            middleInitial = customerDetails.MiddleInitial,
            email = privateInformation.Email,
            phoneNumber = privateInformation.PhoneNumber,
            city = privateInformation.City,
            province = privateInformation.Province,
            country = privateInformation.Country,
            nationality = privateInformation.Nationality,
            birthDate = privateInformation.BirthDate.ToDateTime(TimeOnly.MinValue)
        };
    }
}