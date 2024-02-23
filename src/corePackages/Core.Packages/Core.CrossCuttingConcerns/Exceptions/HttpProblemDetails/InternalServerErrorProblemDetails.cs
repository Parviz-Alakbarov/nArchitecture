using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(string detail) : base()
    {
        Title = "Internal Server Error";
        Status = StatusCodes.Status500InternalServerError;
        Detail = "Internal Server Error";
        Type = "This is for url of internal server error problem documentation!";
    }


}
