﻿using FluentResults;

namespace Backend.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons { get; }
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
}