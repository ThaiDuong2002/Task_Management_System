﻿namespace Backend.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    protected Entity(TId id)
    {
        Id = id;
    }

    protected Entity()
    {
        Id = default!;
    }

    public TId Id { get; protected set; }

    public bool Equals(Entity<TId>? obj)
    {
        return Equals((object?)obj);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}