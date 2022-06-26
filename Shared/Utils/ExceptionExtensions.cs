// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

namespace System
{
    public static class ExceptionExtensions
    {
        public static string ToLongString(this Exception exception)
        {
            if (exception == null)
                return "null exception";

            if (exception.InnerException != null)
            {
                var innerExceptionText = exception.InnerException.ToLongString();
                return
                    $"{exception.GetType().Name}: {exception.Message ?? "-"}\n\t{exception.StackTrace}\nInnerException was {innerExceptionText}";
            }
            return $"{exception.GetType().Name}: {exception.Message ?? "-"}\n\t{exception.StackTrace}";
        }
    }
}
