using CSbank.Domain.Request;
using CSBank.Application.Models;

namespace CSBank.Application.Mapper;

internal static class Map
{
    public static CustomerRequest ToDomain(this CustomerDto dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);

    public static CustomerDto ToDto(this CustomerRequest dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);

    public static PrivateInfoRequest ToDomain(this PrivateInfoDto dto) =>
        new(dto.Id, dto.Email, dto.PhoneNumber, dto.City, dto.Province,
        dto.Country, dto.Nationality, dto.Age, dto.BirthDate);

    public static PrivateInfoDto ToDto(this PrivateInfoRequest dto) =>
        new(dto.Id, dto.Email, dto.PhoneNumber, dto.City, dto.Province,
        dto.Country, dto.Nationality, dto.Age, dto.BirthDate);
}