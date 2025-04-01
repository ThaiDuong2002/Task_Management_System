﻿using Backend.Application.Assignments.Queries.GetAssignments;
using Backend.Application.Services.Assignments.Commands.CreateAssignment;
using Backend.Application.Services.Assignments.Commands.DeleteAssignment;
using Backend.Application.Services.Assignments.Commands.UpdateAssignment;
using Backend.Application.Services.Assignments.Queries.GetAssignment;
using Backend.Contracts.Assignments;
using Backend.Domain.Models.AssignmentModel;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class AssignmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, GetAssignmentQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<(int? page, int? limit, string? status, string? priority), GetAssignmentsQuery>()
            .Map(dest => dest.Page, src => src.page)
            .Map(dest => dest.Limit, src => src.limit)
            .Map(dest => dest.Status, src => src.status)
            .Map(dest => dest.Priority, src => src.priority);

        config.NewConfig<CreateAssignmentRequest, CreateAssignmentCommand>()
            .Map(dest => dest.UserId, src => src.UserId);

        config.NewConfig<Guid, DeleteAssignmentCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<(UpdateAssignmentRequest request, Guid Id), UpdateAssignmentCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Assignment, AssignmentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Status, src => src.Status.Value)
            .Map(dest => dest.Priority, src => src.Priority.Value)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.DueDate, src => src.DueDate)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
    }
}