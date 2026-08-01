using CSBank.Application.Models;
using CSBank.Domain.Entities;

namespace CSBank.Application.Mapper;

public static class MapUser
{
    public static UpdateUserRequest ToDto(Customer? data)
        => new UpdateUserRequest(
            Id: data?.Id,
            FirstName: data?.FirstName,
            LastName: data?.LastName,
            Suffix: data?.Suffix,
            MiddleInitial: data?.MiddleInitial,
            Email: data?.PrivateInformation.Email,
            PhoneNumber: data?.PrivateInformation.PhoneNumber,
            City: data?.PrivateInformation.City,
            Province: data?.PrivateInformation.Province,
            Country: data?.PrivateInformation.Country,
            Nationality: data?.PrivateInformation.Nationality,
            BirthDate: data?.PrivateInformation.BirthDate
        );
}