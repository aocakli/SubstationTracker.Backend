﻿using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryEntries;

public interface IInventoryEntryReadRepository : IReadRepository<InventoryEntry>
{
}