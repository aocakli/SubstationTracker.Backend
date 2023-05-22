﻿using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

namespace SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;

public interface ISubstationMovementWriteRepository : IWriteRepositoryWithSoftDelete<SubstationMovement>
{
    
}