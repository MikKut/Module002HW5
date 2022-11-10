using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Exceptions
{
    /// <summary>
    /// Eception that occures when some logic is skipped in a method.
    /// </summary>
    internal class BusinessException : Exception
    {
        private string _businessExceptionMessage = "I broke a logic: ";

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="methodName">Represents name of the method that causes the eception.</param>
        public BusinessException(string methodName)
            : base(methodName)
        {
            _businessExceptionMessage += methodName;
        }

        /// <inheritdoc/>
        public override string Message { get => _businessExceptionMessage; }
    }
}
