using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.ErrorHandling;
using Project.Bll.Exceptions;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T,U> : IManager<T,U> where T : class,IDto where U : BaseEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            await ExceptionHandler.ExecuteAsync(async () => {

                U domainEntity = _mapper.Map<U>(entity);

                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Entities.Enums.DataStatus.Inserted;


                await _repository.CreateAsync(domainEntity);
            } );

           
        }

        public List<T> GetActives()
        {
            return ExceptionHandler.Execute(() => {
                List<U> values = _repository.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList();

                return _mapper.Map<List<T>>(values);
            });

           
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await ExceptionHandler.ExecuteAsync(async () =>
            {
                List<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values);
            });

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ExceptionHandler.ExecuteAsync(async () =>
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı!");

                return _mapper.Map<T>(value);
            });
        }

        public  List<T> GetPassives()
        {
            return ExceptionHandler.Execute(() =>
            {
                List<U> values = _repository.Where(x => x.Status == DataStatus.Deleted).ToList();
                return _mapper.Map<List<T>>(values);
            });
        }

        public List<T> GetUpdateds()
        {
            return ExceptionHandler.Execute(() =>
            {
                List<U> values = _repository.Where(x => x.Status == DataStatus.Updated).ToList();
                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await ExceptionHandler.ExecuteAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı!");

                
                if (originalValue.Status != DataStatus.Deleted)
                    throw new BadRequestException("Sadece pasif durumda olan kayıtlar kalıcı olarak silinebilir!");

                await _repository.DeleteAsync(originalValue);

                return $"{id} id'li veri silinmistir";
            });

        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await ExceptionHandler.ExecuteAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(id);

                if (originalValue == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı!");

                // Zaten silinmiş mi kontrolü
                if (originalValue.Status == DataStatus.Deleted)
                    throw new BadRequestException("Kayıt zaten pasif durumda!");

                originalValue.Status = DataStatus.Deleted;
                originalValue.DeletedDate = DateTime.Now;
                await _repository.SaveChangesAsync();

                return $"{id} id'li veri pasife cekiilmistir";
            });



        }

        public async Task UpdateAsync(T entity)
        {
            await ExceptionHandler.ExecuteAsync(async () =>  
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);

                if (originalValue == null)
                    throw new NotFoundException($"{entity.Id} ID'li kayıt bulunamadı!");

                // Silinmiş kayıt güncellenemez
                if (originalValue.Status == DataStatus.Deleted)
                    throw new BadRequestException("Pasif durumda olan kayıtlar güncellenemez!");
                U newValue = _mapper.Map<U>(entity);
                newValue.UpdatedDate = DateTime.Now;
                newValue.Status = DataStatus.Updated;
                await _repository.UpdateAsync(originalValue, newValue);
            });
        }
    }
}
