﻿using System;

namespace Accord.Extensions
{
    /// <summary>
    /// Contains methods for code performance measurement. 
    /// </summary>
    public static class Diagnostics
    {
        /// <summary>
        /// Executes a provided action and measures time in milliseconds that was consumed by provided action.
        /// </summary>
        /// <param name="action">User specified action.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public static long MeasureTime(Action action)
        {
            var s = DateTime.Now.Ticks;

            action();

            var e = DateTime.Now.Ticks;
            long elapsed = (e - s) / TimeSpan.TicksPerMillisecond;

            return elapsed;
        }

        /// <summary>
        ///  Executes a provided action several times and measures average time in milliseconds that was consumed by provided action.
        /// </summary>
        /// <param name="action">User specified action. The parameter is current execution count [0..executionCount-1].</param>
        /// <param name="executionCount">Number of times to execute the specified action.</param>
        /// <returns>Average elapsed time in milliseconds.</returns>
        public static float MeasureAverageTime(Action<int> action, int executionCount = 10)
        {
            var totalElapsed = MeasureTime(() => 
            {
                for (int i = 0; i < executionCount; i++)
                {
                    action(i);
                }
            });

            return totalElapsed / executionCount;
        }
    }
}