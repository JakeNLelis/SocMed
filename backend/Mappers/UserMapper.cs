#pragma warning disable CS8601 // Possible null reference assignment.

using backend.Dtos.Account;
using backend.Models;

namespace backend.Mappers;

public static class AccountMapper
{
    public static UserProfileDto toUserProfileDto(this AppUser user)
    {
        return new UserProfileDto
        {
            Id = user.Id,
            FullName = user.FirstName + " " + user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            Birthdate = user.Birthdate,
            City = user.City,
            Province = user.Province,
            Country = user.Country,
            ProfilePhoto = user.ProfilePhoto,
            CoverPhoto = user.CoverPhoto,
            Bio = user.Bio,
            Posts = user.Posts,
            Followings = user.Followings,
            Followers = user.Followers,
        };
    }

    public static UserCardDto toUserCardDto(this AppUser user)
    {
        return new UserCardDto
        {
            Id = user.Id,
            ProfilePhoto = user.ProfilePhoto,
            FullName = user.FirstName + " " + user.LastName,
            UserName = user.UserName,
            Email = user.Email,
        };
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.
