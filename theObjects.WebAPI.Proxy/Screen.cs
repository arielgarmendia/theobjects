using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using theObjects.WebAPI.Proxy.Helpers;
using theObjects.WebAPI.Proxy.ViewModels;

namespace theObjects.WebAPI.Proxy
{
    public static class Screen<T>
    {
        public static async Task<bool> Draw(Shape s)
        {
            if (s != null)
                return await ObjectsProxy<T>.Draw(s);
            else
                return false;
        }
        public static async Task<bool> Move(Guid id, int x, int y)
        {
            if (id != Guid.Empty)
                return await ObjectsProxy<T>.Move(id, x, y);
            else
                return false;
        }
        public static async Task<List<T>> GetAll()
        {
            return await ObjectsProxy<T>.GetAll();
        }
        public static async Task<T> Get(Guid id)
        {
            if (id != Guid.Empty)
                return await ObjectsProxy<T>.Get(id);
            else
                return default(T);
        }
    }
}
