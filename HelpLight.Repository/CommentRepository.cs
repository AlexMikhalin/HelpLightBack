using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Comment = HelpLight.Data.Models.Comment;
using HelpLight.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using HelpLight.Data.Contexts;

namespace HelpLight.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public CommentRepository(HelpLightDbContext _VaODbContext)
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

        public void AddComment(Contracts.Comment comment)
        {
            try
            {
                var commentEntity = Mapper.Map<Contracts.Comment, Comment>(comment);
                _VaODbContext.Add(commentEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
