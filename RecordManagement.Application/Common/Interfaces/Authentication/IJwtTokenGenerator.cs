namespace RecordManagement.Application.Common.Interfaces.Authentication;


public interface IJwtTokenGenerator 
{

    string GenerateToken(Guid userId,String firstName, string lastNamed);

}