using System;

namespace Core.Domain.Exception
{
    public class ResourceNotFoundException : System.Exception
    {
        public ResourceNotFoundException() { }

        public ResourceNotFoundException(string message) : base(message) { }
        
        public ResourceNotFoundException(Type type, Object id) : base($"404 => {type} of {id} not found") { }
    }
}