using System;
using Repository.Context;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository
{

    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Commit()
        {
           _applicationContext.SaveChangesAsync();
        }
    }
}

