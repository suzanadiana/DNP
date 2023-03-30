namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get;}
    public string eMail { get; }
    public string phoneNumber { get; }
    public string passWord { get; }

    public UserCreationDto(string userName, string eMail, string phoneNumber, string passWord)
    {
        UserName = userName;
        this.eMail = eMail;
        this.phoneNumber = phoneNumber;
        this.passWord = passWord;
     
    }
}