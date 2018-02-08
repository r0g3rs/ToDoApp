using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;
using ToDoApp.Data.Interfaces;
using ToDoApp.Model.Interface;

namespace ToDoApp.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntity
    {
        private static Configuration configuration;
        ISessionFactory _sessionFactory;
        ISession _session;

        private static readonly RepositoryBase<TEntity> _instance = new RepositoryBase<TEntity>();

        public RepositoryBase()
        {
            InitializeSession();
        }

        public static RepositoryBase<TEntity> Instance
        {
            get
            {
                return _instance;
            }
        }

        void InitializeSession()
        {
            try
            {
                _sessionFactory = Fluently.Configure()
                                                    .Database(MsSqlConfiguration.MsSql2012
                                                    .ConnectionString(@"Server=localhost\SQLEXPRESS; Database=ToDoApp; Integrated Security=True").ShowSql())
                                                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TEntity>())
                                                    .ExposeConfiguration(x => configuration = x)
                                                    .BuildSessionFactory();

                _session = _sessionFactory.OpenSession();

                SchemaUpdate update = new SchemaUpdate(configuration);
                update.Execute(true, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _session.Query<TEntity>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _session.Get<TEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Update(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Update(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw ex;
                }

            }
        }

        public void Delete(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(_session.Load<TEntity>(id));
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public long RowCount()
        {
            try
            {
                return _session.Query<TEntity>().LongCount();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}