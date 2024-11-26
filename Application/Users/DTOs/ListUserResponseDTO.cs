namespace Application.Users.DTOs;

public class ListUserResponseDTO
{
    public ICollection<GetUserResponseDTO> Items { get; set; }
}