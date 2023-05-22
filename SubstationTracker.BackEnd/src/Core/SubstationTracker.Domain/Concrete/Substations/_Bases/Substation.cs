using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Substations._Bases.Base;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;

namespace SubstationTracker.Domain.Concrete.Substations._Bases;

public class Substation : HistoryEntityBase, ISubstationBase, ISoftDelete
{
    public Substation()
    {
    }

    public Substation(string name,
        string phoneNumber, string address, string description,
        string photoPath)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
        PhotoPath = photoPath;
    }

    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
    public bool IsDeleted { get; set; }

    public virtual List<SubstationMovement> SubstationMovements { get; set; } = new();
    public virtual List<SubstationSector> SubstationSectors { get; set; } = new();
    public virtual List<SubstationResponsibleUser> SubstationResponsibleUsers { get; set; } = new();

    public static Substation Create(
        string name,
        string phoneNumber,
        string address,
        string description,
        string photoPath)
    {
        return new Substation(
            name: name,
            phoneNumber: phoneNumber,
            address: address,
            description: description,
            photoPath: photoPath);
    }

    public void Update(
        string name,
        string phoneNumber,
        string address,
        string description,
        string photoPath)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
        PhotoPath = photoPath;
    }

    public void ClearResponsibles()
    {
        // ResponsibleUserIdentities.Clear();
    }

    public void AddNewResponsible(string responsibleUserId)
    {
        // ResponsibleUserIdentities.Add(responsibleUserId);
    }

    public void AddNewResponsibles(HashSet<string> responsibleUserIdentities)
    {
        foreach (var responsibleUserId in responsibleUserIdentities)
        {
            AddNewResponsible(responsibleUserId);
        }
    }

    public void RemoveAResponsible(string responsibleUserId)
    {
        // ResponsibleUserIdentities.Remove(responsibleUserId);
    }

    public void RemoveResponsibles(HashSet<string> responsibleUserIdentities)
    {
        foreach (var responsibleUserId in responsibleUserIdentities)
        {
            RemoveAResponsible(responsibleUserId);
        }
    }

    public void SoftDelete()
    {
        IsDeleted = true;
    }
}