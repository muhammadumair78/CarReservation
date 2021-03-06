﻿using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO.Base
{
    public abstract class BaseDTO<TEntity, TKey> : IBase<TKey> where TEntity : IDeletable<TKey>, new()
    {
        public bool IsDeleted { get; set; }
        public TKey Id { get; set; }
        public BaseDTO()
        {
            Init();
        }
        public BaseDTO(TEntity entity)
            : this()
        {
            ConvertFromEntity(entity);
        }

        protected virtual void Init()
        {
        }

        public virtual TEntity ConvertToEntity(TEntity entity)
        {
            entity.Id = Id == null || Id.Equals(default(TKey)) ? entity.Id : Id;
            return entity;
        }

        public TEntity ConvertToEntity()
        {
            TEntity entity = new TEntity();
            return ConvertToEntity(entity);
        }

        public virtual void ConvertFromEntity(TEntity entity)
        {
            IsDeleted = entity.IsDeleted;
            Id = entity.Id;
            //CreatedOn = entity.CreatedOn.GetISOStandardDateTime();
            //CreatedBy = entity.CreatedBy;
            //ModifiedOn = entity.LastModifiedOn.GetISOStandardDateTime();
            //ModifiedBy = entity.LastModifiedBy;
        }

        public static List<TDTO> ConvertEntityListToDTOList<TDTO>(IEnumerable<TEntity> entityList) where TDTO : BaseDTO<TEntity, TKey>, new()
        {
            var result = new List<TDTO>();
            if (entityList != null)
                foreach (var entity in entityList)
                {
                    var dto = new TDTO();
                    dto.ConvertFromEntity(entity);
                    result.Add(dto);
                }
            return result;
        }
        
        public static IList<TEntity> ConvertDTOListToEntity(IEnumerable<BaseDTO<TEntity, TKey>> dtoList, IEnumerable<TEntity> entityList)
        {

            var result = new List<TEntity>();
            if (dtoList != null)
                foreach (var dto in dtoList)
                {
                    var entityFromDb = entityList.SingleOrDefault(x => x.Id.Equals(dto.Id));
                    if (entityFromDb != null)
                    {
                        result.Add(dto.ConvertToEntity(entityFromDb));
                    }
                    else
                    {
                        result.Add(dto.ConvertToEntity());
                    }
                }
            foreach (var entity in entityList.Where(x => !dtoList.Any(y => y.Id.Equals(x.Id))))
            {
                entity.IsDeleted = true;
                result.Add(entity);
            }
            return result;
        }
        
        public static IList<TEntity> ConvertDTOListToEntity(IEnumerable<BaseDTO<TEntity, TKey>> dtoList)
        {
            var result = new List<TEntity>();
            if (dtoList != null)
                foreach (var dto in dtoList)
                {
                    result.Add(dto.ConvertToEntity());
                }
            return result;
        }
    }
}
