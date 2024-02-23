using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail) : base() 
    {
        Title = "Rele Violation";
        Status  = StatusCodes.Status400BadRequest;
        Detail = detail;
        Type = "This is for url of problem documentation!";
    }
}
