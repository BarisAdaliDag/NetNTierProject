using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Exceptions
{
    // 404 Not Found için
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    // 400 Bad Request için
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    // 409 Conflict için
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}