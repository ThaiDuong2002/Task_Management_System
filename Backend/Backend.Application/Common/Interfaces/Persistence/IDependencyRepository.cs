﻿using Backend.Domain.Models.DependencyModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IDependencyRepository
{
    Task<int> Create(Dependency dependency);
    Task<int> Delete(Dependency dependency);
    Task<List<Dependency>> GetAll(Guid id);
    Task<List<Dependency>> GetByAssignmentId(Guid id, int? page, int? limit);
}