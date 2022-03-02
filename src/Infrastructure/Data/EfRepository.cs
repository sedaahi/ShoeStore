using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _db;

        public EfRepository(StoreContext db)
        {
            _db = db;
        } 
        public async Task<T> AddAsync(T entity) //asenkron!
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).CountAsync();  //WithSpesification Ardalis paketi sayesinde geliyor!
        }

        public async Task DeleteAsync(T entity) //asenkron!
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).FirstAsync();  //WithSpesification Ardalis paketi sayesinde geliyor!

        }

        public async Task<T> FirstOrDefault(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).FirstOrDefaultAsync(); //WithSpesification Ardalis paketi sayesinde geliyor!
        }

        public async Task<List<T>> GetAllAsync()  //Entitinin Hepsini getiren metot 
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISpecification<T> specification) //PackageManager Ardalis EntityFrameWork kurmalısın(ReadME)
        {
            return await _db.Set<T>().ToListAsync(specification);
        }

        public async Task<T> GetByIdAsync(int id) //asenkron!
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)  //asenkron!
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
