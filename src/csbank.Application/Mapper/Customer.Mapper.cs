using CSbank.Domain.Request;
using CSBank.Application.Models;

namespace CSBank.Application.Mapper;

public static class Map
{
    internal static CustomerRequest ToDomain(this CustomerDto dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);

    internal static CustomerDto ToDto(this CustomerRequest dto)
    => new CustomerDto
    {
        Id = dto.Id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Suffix = dto.Suffix,
        RegistrationDate = dto.RegistrationDate,
        MiddleInitial = dto.MiddleInitial
    };


    internal static PrivateInfoRequest ToDomain(this PrivateInfoDto dto) =>
        new(dto.CustomerId, dto.Email, dto.PhoneNumber, dto.City, dto.Province,
        dto.Country, dto.Nationality, dto.BirthDate);

    internal static PrivateInfoDto ToDto(this PrivateInfoRequest dto)
    {
        return new PrivateInfoDto
        {
            CustomerId = dto.Customer_Id,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            Province = dto.Province,
            Country = dto.Country,
            Nationality = dto.Nationality,
            BirthDate = dto.BirthDate
        };
    }

    public static Object ToParameters(PrivateInfoDto privateInformation, CustomerDto customerDetails)
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