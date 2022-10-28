using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BallArena
{
    public abstract class Creator<T> where T : Product
    {
        protected Dictionary<string, Type> products;

        public Creator()
        {
            var subclasses = Assembly.GetAssembly(typeof(T)).GetTypes().Where(t => t.IsSubclassOf(typeof(T)));
            products = new Dictionary<string, Type>();
            foreach (var subclass in subclasses)
            {
                var instance = Activator.CreateInstance(subclass) as T;
                products.Add(instance.Id, subclass);
            }
        }

        public T GetById(string id)
        {
            if (products.ContainsKey(id))
            {
                Type type = products[id];
                var product = Activator.CreateInstance(type) as T;
                return product;
            }
            return null;
        }
    }
}