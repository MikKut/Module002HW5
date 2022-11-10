﻿using Logger.Exceptions;
using Logger.LoggerLogic.Classes;

namespace Logger
{
    /// <summary>
    /// A class for simulating how methods work.
    /// </summary>
    internal class Starter
    {
        private enum MethodIndicator
        {
            InNormalWay = 0,
            WithWarnings = 1,
            WithErrors = 2,
        }

        /// <summary>
        /// Simulates up to 100 moves with helps of <see cref="Actions"/>.
        /// </summary>
        public static void Run()
        {
            try
            {
                var workFaker = new Actions();
                var randomNumbersGenerator = new Random();
                int methodIndicator = 0;
                bool doesNotHaveAnError = false;
                for (int i = 0; i < 100; i++)
                {
                    methodIndicator = randomNumbersGenerator.Next(0, 3);
                    doesNotHaveAnError = SimulateRandomMethod(workFaker, (MethodIndicator)methodIndicator);
                    if (!doesNotHaveAnError)
                    {
                        break;
                    }
                }
            }
            catch (BusinessException ex)
            {
                Logger.LoggerLogic.Classes.Logger.GetLogger().LogInfo(new Result($"Action got this custom Exception : {ex.Message}", true), LogType.Warning);
            }
            catch (Exception ex)
            {
                Logger.LoggerLogic.Classes.Logger.GetLogger().LogInfo(new Result($"Action failed by reason: {ex.Message}", false), LogType.Error);
            }
        }

        private static bool SimulateRandomMethod(Actions workFaker, MethodIndicator methodIndicator)
        {
            switch (methodIndicator)
            {
                case MethodIndicator.InNormalWay:
                    return workFaker.MethodGoesInNormalWay().Status;
                case MethodIndicator.WithWarnings:
                    return workFaker.MethodGoesWithWarnings().Status;
                case MethodIndicator.WithErrors:
                    return workFaker.MethodGoesWithErrors().Status;
                default:
                    throw new Exception($"Number of methods generated in {nameof(Run)} method is more than 3");
            }
        }
    }
}
