using System;
using System.Diagnostics;

namespace Common.Helpers
{
    public class DependencyHelper
    {
        public static void ThrowIfNull(params object[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] != null
                    && args[i].GetType() == typeof(ArgumentAction)
                    && (ArgumentAction)args[i] == ArgumentAction.Skip)
                {
                    continue;
                }

                if (args[i] == null)
                {
                    throw GetArgumentNullException(i);
                }
            }
        }

        private static ArgumentNullException GetArgumentNullException(int argIndex)
        {
            var frame = new StackFrame(2, false);
            var method = frame.GetMethod();
            var args = method.GetParameters();
            var name = args[argIndex].Name;

            return new ArgumentNullException(name);
        }

        public enum ArgumentAction
        {
            Undefined = 0,
            Skip
        }
    }
}
