using HelpLight.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using WallRecord = HelpLight.Data.Models.WallRecord;
using HelpLight.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class WallRepository : IWallRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public WallRepository(HelpLightDbContext _VaODbContext)
        {
            this._VaODbContext = _VaODbContext;
        }

        public void SaveChanges()
        {
            _VaODbContext.SaveChanges();
        }

        public void AddRecord(Contracts.WallRecord wallRecord)
        {
            try
            {
                var wallRecordEntity = Mapper.Map<Contracts.WallRecord, WallRecord>(wallRecord);
                _VaODbContext.Add(wallRecordEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.WallRecord> GetRecords(Guid organizationId)
        {
            var wallRecords = new List<Contracts.WallRecord>();
            try
            {
                var wrEntity = _VaODbContext.WallRecords
                                     .Where(w => w.IdOrganization == organizationId)
                                     .Include(w => w.Comments).ToList();

                wallRecords = Mapper.Map<List<Contracts.WallRecord>>(wrEntity);

                return wallRecords;
            }
            catch
            {
                throw;
            }
        }
    }
}
