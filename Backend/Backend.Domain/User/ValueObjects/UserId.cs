﻿using Backend.Domain.Common.Models;

namespace Backend.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    private Guid Value { get; }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}