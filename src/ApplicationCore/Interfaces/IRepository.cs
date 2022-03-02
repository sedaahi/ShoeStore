using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    //Veri devamlığını sağlamak için Ireposity kullandık //Bağımsız kılmak için
    public interface IRepository<T> where T: BaseEntity  // Generic yapı ile kategory/brand/product hepsiyle kullanabil ama where! BaseEntitydekiler
    {
        Task<T> GetByIdAsync(int id);    // Asenkron olarak id getir (Asenkron old. için task yazdık olmasa direk T GetById(int Id) derdik)
        Task<List<T>> GetAllAsync();  //Tümünü getir
        Task<List<T>> GetAllAsync(ISpecification<T> specification); //Tümünü getir ama bazı kısıtlamalara göre

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);  //Update ederken birşey değişmeyeceği için <T> gerek yok
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> specification);  //....'dan kaç tane var diye saydırmak için
        Task<T> FirstAsync(ISpecification<T> specification);  // aramaya uyan ilk olanı getir demek için (bulamazsa hata fırlatır)
        Task<T> FirstOrDefault(ISpecification<T> specification);

    }
}
