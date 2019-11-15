using System.Collections.Generic;

namespace InvoiceManagementStudio.Core.Definition.Service
{

    /// <summary>
    /// Defines generic CRUD service
    /// </summary>
    /// <typeparam name="TId">Type of id used by entity for which service is implemented</typeparam>
    /// <typeparam name="T">Type of entity for which service is implemented</typeparam>
    public interface ICrudService<in TId, T>
    {
        List<T> GetAll();

        T GetById(IObjectIdentifier<TId> id);

        T Create(T entity);

        T Update(T entity);

        T Delete(T entity);
    }

}
