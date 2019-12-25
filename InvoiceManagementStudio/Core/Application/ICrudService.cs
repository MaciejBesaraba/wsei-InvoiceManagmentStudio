using System.Collections.Generic;
using InvoiceManagementStudio.Core.Domain;

namespace InvoiceManagementStudio.Core.Application
{

    /// <summary>
    /// Defines generic CRUD service rules for entity type provided
    /// </summary>
    /// <typeparam name="TId">Type of id used by entity for which service is implemented</typeparam>
    /// <typeparam name="T">Type of entity for which service is implemented</typeparam>
    public interface ICrudService<in TId, T>
    {
        /// <summary>
        /// Provides list of entities
        /// </summary>
        /// <returns>List of entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Entity of specified identification
        /// </summary>
        /// <param name="id">Unique identification of searched entity</param>
        /// <returns>Single entity</returns>
        T GetById(IObjectIdentifier<TId> id);

        /// <summary>
        /// Process creation of new entity. Validation, Memory storage, Auto correction, Data completion
        /// </summary>
        /// <param name="entity">Entity instance</param>
        /// <returns>Single entity after creation process</returns>
        T Create(T entity);

        /// <summary>
        /// Process update of data for entity specified
        /// </summary>
        /// <param name="entity">Entity instance to update</param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Process deletion of entity object
        /// </summary>
        /// <param name="id">Entity unique identification</param>
        /// <returns>Entity instance matching provided id (for revert possibility)</returns>
        T Delete(IObjectIdentifier<TId> id);

        /// <summary>
        /// Process deletion of entity object
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <returns>Entity instance matching provided (for revert possibility)</returns>
        T Delete(T entity);
    }

}
