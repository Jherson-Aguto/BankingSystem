using CSbank.Domain.Request;
using CSBank.Application.Models;

namespace CSBank.Application.Mapper;

internal static class Map
{
    public static CustomerRequest ToDomain(this CustomerDto dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);

    public static CustomerDto ToDto(this CustomerRequest dto)
    {
        return new CustomerDto
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Suffix = dto.Suffix,
            RegistrationDate = dto.RegistrationDate,
            MiddleInitial = dto.MiddleInitial
        };
    }

    public static PrivateInfoRequest ToDomain(this PrivateInfoDto dto) =>
        new(dto.Id, dto.Email, dto.PhoneNumber, dto.City, dto.Province,
        dto.Country, dto.Nationality, dto.Age, dto.BirthDate);

    public static PrivateInfoDto ToDto(this PrivateInfoRequest dto)
    {
        return new PrivateInfoDto
        {
            Id = dto.Id,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            Province = dto.Province,
            Country = dto.Country,
            Nationality = dto.Nationality,
            Age = dto.Age,
            BirthDate = dto.BirthDate
        };
    }
}