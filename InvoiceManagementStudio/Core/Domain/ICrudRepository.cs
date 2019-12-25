using System.Collections.Generic;

namespace InvoiceManagementStudio.Core.Domain
{
    /// <summary>
    /// Defines generic CRUD repository rules for memory storage of entity type provided
    /// </summary>
    /// <typeparam name="TId">Type of id used by entity for which service is implemented</typeparam>
    /// <typeparam name="T">Type of entity for which service is implemented</typeparam>
    public interface ICrudRepository<in TId, T>
    {
        /// <summary>
        /// Access all entities stored in memory and returns they as list
        /// </summary>
        /// <returns>List of entities</returns>
        List<T> FindAll();

        /// <summary>
        /// Returns entity stored in memory searched by provided id
        /// </summary>
        /// <param name="id">Unique identification of entity</param>
        /// <returns>Single entity found in memory</returns>
        T FindById(IObjectIdentifier<TId> id);

        /// <summary>
        /// Saves provided entity into memory
        /// </summary>
        /// <param name="entity">Valid entity instance</param>
        /// <returns>Entity that have been successfully stored</returns>
        T Save(T entity);

        /// <summary>
        /// Replaced entity stored with provided, searched by entity id
        /// </summary>
        /// <param name="entity">Valid entity instance</param>
        /// <returns>Entity that have been successfully stored</returns>
        T Update(T entity);

        /// <summary>
        /// Permanently deletes entity stored in memory with id matching provided
        /// </summary>
        /// <param name="id">Entity unique identification</param>
        /// <returns>Entity sored under provided id (for revert possibility)</returns>
        T Delete(IObjectIdentifier<TId> id);

        /// <summary>
        /// Permanently deletes entity stored in memory and matching provided
        /// </summary>
        /// <param name="entity">Valid entity instance</param>
        /// <returns>Entity provided (for revert possibility)</returns>
        T Delete(T entity);
    }

}
