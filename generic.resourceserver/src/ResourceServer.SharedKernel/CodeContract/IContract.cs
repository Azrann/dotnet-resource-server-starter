using System;

namespace ResourceServer.SharedKernel.CodeContract
{
    public interface IContract
    {
        void Requires<TException>(bool assertion, string message) where TException : Exception;
        void Requires<TException>(Func<bool> assertion, string message) where TException : Exception;
    }
}
