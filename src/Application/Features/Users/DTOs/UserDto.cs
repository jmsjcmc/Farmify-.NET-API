namespace Farmify_API_v2.src.Application.Features.Users.DTOs
{
    public record UserDto(
        int ID,
        string FirstName,
        string Lastname,
        string Username,
        string Email);
}
