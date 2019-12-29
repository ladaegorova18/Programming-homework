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
        public string Name { get; set; }

        /// <summary>
        /// has a test crashed or not?
        /// </summary>
        public bool Crashed { get; set; }

        /// <summary>
        /// if test is ignored
        /// </summary>
        public bool Ignored { get; set; }

        /// <summary>
        /// reason why is a test ignored if it is
        /// </summary>
        public string IgnoreReason { get; set; }

        /// <summary>
        /// time of test passing
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// main test method constructor
        /// </summary>
        /// <param name="method"> method to get information about </param>
        public TestInfo(MethodInfo method) => Name = method.Name;
    }
}
