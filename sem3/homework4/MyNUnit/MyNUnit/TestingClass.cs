using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using MyNUnit.AttributesLibrary;

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
                
                var assembly = Assembly.LoadFrom(file);
                foreach (var type in assembly.GetTypes())
                {
                    RunTests(type);
                }
            }
        }

        private static void RunTests(Type type)
        {
            MethodsWithAttribute<BeforeClassAttribute>(type);
            MethodsWithAttribute<BeforeAttribute>(type);
            MethodsWithAttribute<TestAttribute>(type);
            MethodsWithAttribute<AfterClassAttribute>(type);
            MethodsWithAttribute<AfterAttribute>(type);
        }

        private static void MethodsWithAttribute<AttributeType>(Type type)
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
            var instance = new object();
            if (methods.Count != 0)
            {
                instance = Activator.CreateInstance(type);
            }
            var task = MakeTask<AttributeType>(methods, instance);
            if (task != null)
            {
                Parallel.ForEach(methods, task);
            }
        }

        private static Action<MethodInfo> MakeTask<AttributeType>(List<MethodInfo> methods, object instance)
        {
            Action<MethodInfo> task = null;
            if (typeof(AttributeType) == typeof(BeforeAttribute) || typeof(AttributeType) == typeof(BeforeClassAttribute)
                || typeof(AttributeType) == typeof(AfterClassAttribute) || typeof(AttributeType) == typeof(AfterAttribute))
            {
                foreach (var method in methods)
                {
                    if (!method.IsStatic && (typeof(AttributeType) == typeof(BeforeClassAttribute) || typeof(AttributeType) == typeof(AfterClassAttribute)))
                    {
                        throw new InvalidOperationException();
                    }
                    task = (Action<MethodInfo>)method.Invoke(instance, null);
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

        private static void RunTest(MethodInfo method)
        {
            var testAttribute = (TestAttribute)Attribute.GetCustomAttribute(method, typeof(TestAttribute));

            var info = new TestInfo(method);
            if (testAttribute.Ignore != null)
            {
                info.Ignored = true;
                info.IgnoreReason = testAttribute.Ignore;
                TestInformation.Add(info);
                return;
            }
            if (method.GetParameters().Length > 0)
            {
                info.Crashed = true;
                TestInformation.Add(info);
                return;
            }
            var instance = Activator.CreateInstance(method.DeclaringType);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                method.Invoke(instance, null);
                info.Crashed = testAttribute.Expected != null;
            }
            catch (Exception e)
            {
                info.Crashed = testAttribute.Expected != e.InnerException.GetType();
            }
            stopWatch.Stop();
            info.Time = stopWatch.ElapsedMilliseconds;

            TestInformation.Add(info);
        }
    }
}