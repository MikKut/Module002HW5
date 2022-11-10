using Logger.Exceptions;
using Logger.LoggerLogic.Interfaces;

namespace Logger.LoggerLogic.Classes
{
    /// <summary>
    /// Simulates work.
    /// </summary>
    internal class Actions : IAction
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Actions"/> class.
        /// </summary>
        public Actions()
        {
            _logger = Logger.GetLogger();
        }

        /// <inheritdoc/>
        public IResult MethodGoesInNormalWay()
        {
            var result = new Result("Goes in a normal way", true);
            Console.Write($"Start method: {nameof(this.MethodGoesInNormalWay)}");
            _logger.LogInfo(result, LogType.Information);
            return result;
        }

        /// <inheritdoc/>
        public IResult MethodGoesWithErrors()
        {
            Console.Write($"I broke a logic: {nameof(this.MethodGoesWithErrors)}");
            throw new Exception($"{nameof(this.MethodGoesWithErrors)} trew an exception");
        }

        /// <inheritdoc/>
        public IResult MethodGoesWithWarnings()
        {
            Console.Write($"Skipped logic in method: {nameof(this.MethodGoesWithWarnings)}");
            throw new BusinessException(nameof(this.MethodGoesWithWarnings));
        }
    }
}
