using System.Collections.Generic;

namespace SlimXUnitDb.Test.Core.Generators
{
    /// <summary>
    /// Base generator.
    /// </summary>
    /// <typeparam name="T">The generated object type.</typeparam>
    public abstract class BaseGenerator<T>
    {
        protected readonly List<T> _generatedItems;
        protected BaseGenerator()
        {
            _generatedItems = new List<T>();
        }

        /// <summary>
        /// Clears the generator from the generated data.
        /// </summary>
        public virtual void Clear()
        {
            _generatedItems.Clear();
        }

        /// <summary>
        /// Represents the count of generated items.
        /// </summary>
        public int Count
        {
            get
            {
                return _generatedItems.Count;
            }
        }

        /// <summary>
        /// Represents the last instance generated.
        /// </summary>
        public T Current
        {
            get
            {
                return _generatedItems[Count - 1];
            }
        }

        /// <summary>
        /// Represents the second last instance generated.
        /// </summary>
        public T Previous
        {
            get
            {
                return _generatedItems[Count - 2];
            }
        }

        /// <summary>
        /// Creates a new instance of generated item.
        /// </summary>
        protected abstract T GenerateNew();

        /// <summary>
        /// Generates a new instance of item.
        /// </summary>
        public T Generate()
        {
            T instance = GenerateNew();
            AfterGenerate(instance);

            return instance;
        }

        /// <summary>
        /// Runs immediate logic after item has been generated.
        /// </summary>
        /// <param name="instance">Newly generated instsance.</param>
        protected virtual void AfterGenerate(T instance)
        {
            _generatedItems.Add(instance);
        }
    }
}
