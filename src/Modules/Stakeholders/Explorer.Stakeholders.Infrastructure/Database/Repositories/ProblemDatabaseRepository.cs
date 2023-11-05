﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class ProblemDatabaseRepository : IProblemRepository
    {
        private readonly StakeholdersContext _dbContext;
        private readonly DbSet<Problem> _dbSet;
        public ProblemDatabaseRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Problem>();
        }

        public PagedResult<Problem> GetByUserId(int page, int pageSize, long id)
        {
            var task = _dbSet.Include(x => x.Tourist).Where(x => x.TouristId == id).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<Problem> GetByAuthor(int page, int pageSize, List<long> tourIds)
        {
            var task = _dbSet.Include(x => x.Tourist).Where(x => tourIds.Contains(x.TourId)).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<Problem> GetAll(int page, int pageSize)
        {
            var task = _dbSet.Include(x => x.Tourist).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public Problem Get(long id)
        {
            var task = _dbContext.Problem.FirstOrDefault(problem => problem.Id == id);
            return task;
        }

        public long GetTourIdByProblemId(long problemId)
        {
            var result = _dbContext.Problem.FirstOrDefault(problem => problem.Id == problemId);
            return result.TourId;
        }
    }
}
