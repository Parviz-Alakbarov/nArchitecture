using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; init; }


    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Errors = errors;
        Title = errors.Count() > 1 ? "Validation errors" : "Validation error";
        Status = StatusCodes.Status400BadRequest;
        Detail = errors.Count() > 1 ? "More than one validation errors occured." : "Validation error occured.";
        Type = "Validation error documentation!";
    }
}
