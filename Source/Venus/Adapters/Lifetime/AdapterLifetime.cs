﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Venus.Adapters.Lifetime
{
    internal class AdapterLifetime : Venus.LightInject.ILifetime, IDisposable
    {
        private ILifetime lifetime;

        public AdapterLifetime(ILifetime lifetime)
        {
            if (lifetime == null)
                throw new ArgumentNullException("lifetime");

            this.lifetime = lifetime;
        }

        public object GetInstance(Func<object> createInstance, LightInject.Scope scope)
        {
            return lifetime.GetInstance(createInstance);
        }

        public void Dispose()
        {
            var disposable = lifetime as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
