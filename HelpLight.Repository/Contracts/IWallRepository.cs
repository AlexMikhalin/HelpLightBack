using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IWallRepository : IWorkUnit
    {
        void AddRecord(Contracts.WallRecord wallRecord);
        List<Contracts.WallRecord> GetRecords(Guid organizationId);
    }
}
