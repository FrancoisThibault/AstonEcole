using AstonEcole.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstonEcole.Web.Infrastructure
{
    public abstract  class AstonPage : System.Web.UI.Page
    {
        private Dictionary<Type, AstonApiClient> _services = new Dictionary<Type, AstonApiClient>();

        protected T GetApiClient<T>()
            where T : AstonApiClient, new()
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                _services.Add(typeof(T), new T());
            }

            return (T) _services[typeof(T)];
        }

        public override void Dispose()
        {

            _services.Values.ToList().ForEach(apiClient => apiClient.Dispose());

            base.Dispose();
        }
    }
}