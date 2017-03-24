// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkAsync.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   Defines the IUnitOfWorkAsync type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Pattern.UnitOfWork
{
    using System.Threading;
    using System.Threading.Tasks;
    using Repository.Pattern.Infrastructure;
    using Repository.Pattern.Repositories;

    /// <summary>
    /// The UnitOfWorkAsync interface.
    /// </summary>
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// The repository async.
        /// </summary>
        /// <typeparam name="TEntity">Type for which the repository is being created for.</typeparam>
        /// <returns>
        /// The instance of repository
        /// <see cref="Repository.Pattern.Repositories.IRepositoryAsync`1" />
        /// for TEntity.
        /// </returns>
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}