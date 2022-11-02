using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BallArena
{
    public abstract class Creator<T>
    {
        protected List<Type> products;

        public Creator()
        {
            var subclasses = Assembly.GetAssembly(typeof(T)).GetTypes().Where(t => t.IsSubclassOf(typeof(T)) && t.IsAbstract == false);
            products = new List<Type>();
            foreach (var subclass in subclasses)
            {
                products.Add(subclass);
            }
        }

        public TypeProduct Get<TypeProduct>() where TypeProduct : T, new()
        {
            if (products.Contains(typeof(TypeProduct)))
            {
                var product = Activator.CreateInstance<TypeProduct>();
                return product;
            }
            return default;
        }
    }
}