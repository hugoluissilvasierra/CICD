using System.Runtime.Serialization;

namespace VentasAPI.Utils
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
