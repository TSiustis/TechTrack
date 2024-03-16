using System.Linq.Expressions;
using TechTrack.Application.Helpers;
using TechTrack.Domain.Enums;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Equipments.Extensions;
public static class EquipmentExtensions
{
    public static Expression<Func<Equipment, bool>> HasGuidEqualTo(
        this Expression<Func<Equipment, bool>> predicate, Guid guid)
    {
        if (guid == Guid.Empty)
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.Id == guid);
    }

    public static Expression<Func<Equipment, bool>> AndNameEqualTo(
        this Expression<Func<Equipment, bool>> predicate, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.Name == name);
    }

    public static Expression<Func<Equipment, bool>> AndTypeEqualTo(
        this Expression<Func<Equipment, bool>> predicate, string type)
    {
        if (string.IsNullOrEmpty(type))
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.Type == type);
    }

    public static Expression<Func<Equipment, bool>> AndSerialNumberEqualTo(
        this Expression<Func<Equipment, bool>> predicate, string serialNumber)
    {
        if (string.IsNullOrEmpty(serialNumber))
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.SerialNumber == serialNumber);
    }

    public static Expression<Func<Equipment, bool>> AndStatusEqualTo(
        this Expression<Func<Equipment, bool>> predicate, EquipmentStatus status)
    {
        if (status == default)
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.Status == status);
    }

    public static Expression<Func<Equipment, bool>> AndAssignmentDateEqualTo(
        this Expression<Func<Equipment, bool>> predicate, DateTime? assignmentDate)
    {
        if (!assignmentDate.HasValue)
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.AssignmentDate == assignmentDate);
    }

    public static Expression<Func<Equipment, bool>> AndReturnDateEqualTo(
        this Expression<Func<Equipment, bool>> predicate, DateTime? returnDate)
    {
        if (!returnDate.HasValue)
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.ReturnDate == returnDate);
    }

    public static Expression<Func<Equipment, bool>> AndAssignedToUserIdEqualTo(
        this Expression<Func<Equipment, bool>> predicate, int? assignedToUserId)
    {
        if (!assignedToUserId.HasValue)
        {
            return predicate;
        }
        return predicate.And(equipment => equipment.AssignedToUserId == assignedToUserId);
    }
}