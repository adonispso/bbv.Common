//-------------------------------------------------------------------------------
// <copyright file="ExceptionExtensionMethods.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2011 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Extension methods for exceptions.
    /// </summary>
    public static class ExceptionExtensionMethods
    {
        /// <summary>
        /// Preserves the stack trace of the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void PreserveStackTrace(this Exception exception)
        {
            Ensure.ArgumentNotNull(exception, "exception");

#if SILVERLIGHT
#else
            var remoteStackTraceString = typeof(Exception).GetField("_remoteStackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);

            remoteStackTraceString.SetValue(exception, exception.StackTrace + Environment.NewLine);
#endif
        }
    }
}