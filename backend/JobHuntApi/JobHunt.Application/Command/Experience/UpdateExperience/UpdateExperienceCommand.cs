﻿using JobHunt.Application.Request.Experience;
using JobHunt.Application.Response;
using MediatR;

namespace JobHunt.Application.Command.Experience.UpdateExperience;

public record UpdateExperienceCommand(Guid ExperienceId, UpdateExperienceRequest UpdateExperienceRequest) : IRequest<BaseResponse>;