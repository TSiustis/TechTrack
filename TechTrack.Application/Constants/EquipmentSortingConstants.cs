using System.Linq.Expressions;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Constants;
public static class EquipmentSortingConstants
{
    public const string Name = "Name";
    public const string Type = "Type";
    public const string SerialNumber = "SerialNumber";
    public const string Status = "Status";
    public const string AssignmentDate = "AssignmentDate";
    public const string ReturnDate = "ReturnDate";

    public static readonly IReadOnlyDictionary<string, Expression<Func<Equipment, object>>> SortExpressions =
        new Dictionary<string, Expression<Func<Equipment, object>>>
        {
            { Name, equipment => equipment.Name },
            { Type, equipment => equipment.Type },
            { SerialNumber, equipment => equipment.SerialNumber },
            { Status, equipment => equipment.Status },
            { AssignmentDate, equipment => equipment.AssignmentDate },
            { ReturnDate, equipment => equipment.ReturnDate }
        };
}

