using Bogus;
using System;
using System.Collections.Generic;

namespace SlimXUnitDb.Test.Core.Generators
{
    /// <summary>
    /// Base bogus faker generator.
    /// </summary>
    /// <typeparam name="T">Type of class to generate.</typeparam>
    public abstract class BaseFactory<T> : BaseGenerator<T> where T : class
    {
        private readonly List<bool> _isSyncronized;
        protected readonly BaseTest _testContest;

        public BaseFactory(BaseTest testContest)
        {
            _testContest = testContest;
            _isSyncronized = new List<bool>();
        }

        /// <summary>
        /// Syncronizes the starcounter database with the passed lilst of objects.
        /// </summary>
        /// <param name="list">The object to synchronise.</param>
        protected abstract void SyncDb(IReadOnlyList<T> list);

        /// <inheritdoc />
        protected sealed override void AfterGenerate(T instance)
        {
            base.AfterGenerate(instance);
            _isSyncronized.Add(false);
        }

        /// <inheritdoc />
        public sealed override void Clear()
        {
            base.Clear();
            _isSyncronized.Clear();
        }

        /// <inheritdoc />
        public T Generate(Action<Faker<T>> overrideAction)
        {
            T instance = GenerateNew(overrideAction);
            AfterGenerate(instance);

            return instance;
        }

        protected abstract T GenerateNew(Action<Faker<T>> action);

        /// <summary>
        /// Synchronizes the current factory content with the db.
        /// </summary>
        public void Sync()
        {
            List<T> toSync = new List<T>();
            for (int i = 0; i < _generatedItems.Count; i++)
            {
                if (!_isSyncronized[i])
                {
                    toSync.Add(_generatedItems[i]);
                }
            }
            SyncDb(toSync);
            AcceptChanges();
        }

        /// <summary>
        /// Accepts changes for object yet not syncronized with the db.
        /// </summary>
        public void AcceptChanges()
        {
            for (int i = 0; i < _isSyncronized.Count; i++)
            {
                _isSyncronized[i] = true;
            }
        }
    }
}
