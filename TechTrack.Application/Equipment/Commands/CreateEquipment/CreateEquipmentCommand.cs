using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrack.Domain.Enums;

namespace TechTrack.Application.Equipment.Commands.CreateEquipment
{
    public class CreateEquipmentCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? AssignedToUserId { get; set; }
    }
}