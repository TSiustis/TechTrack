﻿using TechTrack.Domain.Common;
using TechTrack.Domain.Enums;

namespace TechTrack.Domain.Models
{
    public class Equipment : Entity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime? AssignmentDate { get; set; }   
        public DateTime? ReturnDate { get; set; }
        public int? AssignedToUserId { get; set; }
        public User? AssignedTo { get; set; }
    }
}