using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Attributes;

namespace MyNUnit
{
    /// <summary>
    /// class to run all tests in some directory
    /// </summary>
    public static class TestingClass
    {
        /// <summary>
        /// information about all tests
        /// </summary>
        public static ConcurrentBag<TestInfo> TestInformation { get; set; } = new ConcurrentBag<TestInfo>();

        /// <summary>
        /// prints result of running tests
        /// </summary>
        public static void PrintResult()
        {
            foreach (var info in TestInformation)
            {
                Console.Write(info.Name);
                if (info.Ignored)
                {
                    Console.Write(" Ignored " + info.IgnoreReason);
                }
                else
                {
                    Console.WriteLine($" {!info.Crashed} {info.Time.ToString()}");
                }
            }
        }

        /// <summary>
        /// starts test processing 
        /// </summary>
        /// <param name="path"> path to seek assemblies </param>
        public static void Process(string path)
        {
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var types = Assembly.LoadFrom(file).GetTypes();
                foreach (var type in types)
                {
                    RunTests(type);
                }
            }
        }

        private static void RunTests(Type type)
        {
            var instance = Activator.CreateInstance(type);
            MethodsWithAttribute<BeforeClassAttribute>(type, instance);
            MethodsWithAttribute<BeforeAttribute>(type, instance);
            MethodsWithAttribute<TestAttribute>(type, instance);
            MethodsWithAttribute<AfterAttribute>(type, instance);
            MethodsWithAttribute<AfterClassAttribute>(type, instance);
        }

        private static void MethodsWithAttribute<AttributeType>(Type type, object instance)
        {
            var methods = new List<MethodInfo>();
            foreach (var method in type.GetMethods())
            {
                foreach (var attribute in method.GetCustomAttributes(false))
                {
                    if (attribute.GetType().Name == typeof(AttributeType).Name)
                    {
                        methods.Add(method);
                    }
                }
            }
            var task = MakeTask<AttributeType>(methods, instance);
            if (task != null)
            {
                Parallel.ForEach(methods, task);
            }
        }

        private static Action<MethodInfo, object> MakeTask<AttributeType>(List<MethodInfo> methods, object instance)
        {
            Action<MethodInfo, object> task = null;
            if (typeof(AttributeType) == typeof(BeforeAttribute) || typeof(AttributeType) == typeof(BeforeClassAttribute)
                || typeof(AttributeType) == typeof(AfterClassAttribute) || typeof(AttributeType) == typeof(AfterAttribute))
            {
                foreach (var method in methods)
                {
                    if (!method.IsStatic && (typeof(AttributeType) == typeof(BeforeClassAttribute) || typeof(AttributeType) == typeof(AfterClassAttribute)))
                    {
                        throw new InvalidOperationException();
                    }
                    task = (Action<MethodInfo, object>)method.Invoke(instance, null);
                }
            }
            else if (typeof(AttributeType) == typeof(TestAttribute))
            {
                foreach (var method in methods)
                {
                    task = RunTest;
                }
            }
            return task;
        }

        private static void RunTest(MethodInfo method, object instance)
        {
            var testAttribute = (TestAttribute)Attribute.GetCustomAttribute(method, typeof(TestAttribute));
            TestInfo info = null;

            bool ignored = false;
            string ignoreReason = null;
            bool crashed = false;
            long time = 0;

            if (testAttribute.Ignore != null)
            {
                ignored = true;
                ignoreReason = testAttribute.Ignore;
                info = new TestInfo(method, ignored, ignoreReason, crashed, time);
                TestInformation.Add(info);
                return;
            }
            if (method.GetParameters().Length > 0)
            {
                crashed = false;
                info = new TestInfo(method, ignored, ignoreReason, crashed, time);
                TestInformation.Add(info);
                return;
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                method.Invoke(instance, null);
                crashed = testAttribute.Expected != null;
            }
            catch (Exception e)
            {
                crashed = testAttribute.Expected != e.InnerException.GetType();
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;

            info = new TestInfo(method, ignored, ignoreReason, crashed, time);
            TestInformation.Add(info);
        }
    }
}