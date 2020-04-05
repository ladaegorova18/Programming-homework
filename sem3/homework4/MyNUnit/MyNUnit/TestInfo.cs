using System.Reflection;

namespace MyNUnit
{
    /// <summary>
    /// information about a test method
    /// </summary>
    public class TestInfo
    {
        /// <summary>
        /// test method name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// has a test crashed or not?
        /// </summary>
        public bool Crashed { get; }

        /// <summary>
        /// if test is ignored
        /// </summary>
        public bool Ignored { get; }

        /// <summary>
        /// reason why is a test ignored if it is
        /// </summary>
        public string IgnoreReason { get; }

        /// <summary>
        /// time of test passing
        /// </summary>
        public long Time { get; }

        /// <summary>
        /// main test method constructor
        /// </summary>
        /// <param name="method"> method to get information about </param>
        public TestInfo(MethodInfo method, bool ignored, string ignoreReason, bool crashed, long time)
        {
            Name = method.Name;
            Ignored = ignored;
            IgnoreReason = ignoreReason;
            Crashed = crashed;
            Time = time;
        }
    }
}
