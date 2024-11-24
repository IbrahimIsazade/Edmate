﻿using Domain.Entities;
using MediatR;

namespace Application.Modules.AwardModule.Commands.AwardAddCommand
{
    public class AwardAddRequest : IRequest<Award>
    {
        public required int Name { get; set; }
        public required int CourseId { get; set; }
    }
}
