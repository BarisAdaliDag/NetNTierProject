using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ErrorHandling
{
    public static class ExceptionHandler
    {
        // Void dönen sync metotlar için 
        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                throw; // ← RE-THROW (orjinal exception'ı fırlat)
            }
        }

        // Dönüş tipi olan sync metotlar için
        public static T Execute<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch
            {
                throw; // ← RE-THROW
            }
        }

        // Void dönen async metotlar için
        public static async Task ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch
            {
                throw; // ← RE-THROW
            }
        }

        // Dönüş tipi olan async metotlar için
        public static async Task<T> ExecuteAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch
            {
                throw; // ← RE-THROW
            }
        }
    }
}