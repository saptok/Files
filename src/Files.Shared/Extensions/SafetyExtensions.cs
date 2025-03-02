﻿using System;
using System.Threading.Tasks;

#nullable enable

namespace Files.Shared.Extensions
{
    [Obsolete("This class will be replaced with SafeWrapper.")]
    public static class SafetyExtensions
    {
        public static bool IgnoreExceptions(Action action, Logger? logger = null)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                logger?.Info(ex, ex.Message);
                return false;
            }
        }

        public static async Task<bool> IgnoreExceptions(Func<Task> action, Logger? logger = null)
        {
            try
            {
                await action();
                return true;
            }
            catch (Exception ex)
            {
                logger?.Info(ex, ex.Message);
                return false;
            }
        }

        public static T? IgnoreExceptions<T>(Func<T> action, Logger? logger = null)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                logger?.Info(ex, ex.Message);
                return default;
            }
        }

        public static async Task<T?> IgnoreExceptions<T>(Func<Task<T>> action, Logger? logger = null)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                logger?.Info(ex, ex.Message);
                return default;
            }
        }
    }
}
