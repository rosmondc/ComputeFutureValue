using ComputeFutureValue.Api.Data;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputeFutureValue.Api.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ComputeFutureValueDbContext _context;
        private readonly DbSet<T> _entity;
        private readonly ILogger<T> _logger;

        public GenericRepository(ComputeFutureValueDbContext context, ILogger<T> logger)
        {
            _context = context;
            _entity = context.Set<T>();

            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                _logger.LogInformation($"Get all records from {_entity.EntityType.Name}");
                return await _entity.ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"{_entity.EntityType.Name} could not be retrieved: {ex.Message}";
                _logger.LogInformation(message);

                throw new Exception(message);
            }
            
        }

        public async Task<T> GetById(object id)
        {
            try
            {
                _logger.LogInformation($"Get record from {_entity.EntityType.Name}, id: {id}");
                return await _entity.FindAsync(id);
            }
            catch (Exception ex)
            {
                var message = $"{_entity.EntityType.Name} could not be retrieved: {ex.Message}";
                _logger.LogError(message);

                throw new Exception(message);
            }
        }

        public async Task<T> AddAsync(T entity)
        {

            if (entity == null)
            {
                var message = $"{nameof(AddAsync)} entity must not be null";
                _logger.LogError(message);

                throw new ArgumentNullException(message);
            }

            _logger.LogInformation($"Adding new record {_entity.EntityType.Name}, values: {entity.ToString()}");


            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                var message = $"{nameof(entity)} could not be saved: {ex.Message}";
                _logger.LogError(message);

                throw new Exception(message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                var message = $"{nameof(UpdateAsync)} entity must not be null";
                _logger.LogError(message);

                throw new ArgumentNullException(message);
            }

            _logger.LogInformation($"Updating record {_entity.EntityType.Name}, values: {entity.ToString()}");

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                var message = $"{nameof(entity)} could not be updated: {ex.Message}";
                _logger.LogError(message);

                throw new Exception(message);
            }
        }
    }
}
