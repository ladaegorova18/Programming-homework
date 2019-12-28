using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MyNUnit.AttributesLibrary;

namespace MyNUnit
{
    public class TestingClass
    {
        public string Path { get; set; } = null;

        public static ConcurrentBag<TestInfo> testInformation = new ConcurrentBag<TestInfo>();

        public void PrintResult()
        {
            foreach (var info in testInformation)
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

        public TestingClass(string path)
        {
            Path = path;
        }

        public void Process()
        {
            var files = Directory.GetFiles(Path, "*.dll", SearchOption.AllDirectories);
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
            var instance = Activator.CreateInstance(type);
            Action<MethodInfo> task = null;
            if (typeof(AttributeType) == typeof(BeforeAttribute) || typeof(AttributeType) == typeof(BeforeClassAttribute)
                || typeof(AttributeType) == typeof(AfterClassAttribute) || typeof(AttributeType) == typeof(AfterAttribute))
            {
                foreach (var method in methods)
                {
                    if (!method.IsStatic)
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
            if (task != null)
            {
                Parallel.ForEach(methods, task);
            }
        }

        private static void RunTest(MethodInfo method)
        {
            var testAttribute = (TestAttribute)Attribute.GetCustomAttribute(method, typeof(TestAttribute));

            var parameters = method.GetParameters();
            var info = new TestInfo(method);
            if (testAttribute.Ignore != null)
            {
                info.Ignored = true;
                info.IgnoreReason = testAttribute.Ignore;
                return;
            }
            var instance = Activator.CreateInstance(method.DeclaringType);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                method.Invoke(instance, null);
                info.Crashed = !(testAttribute.Expected == null);
            }
            catch (Exception e)
            {
                info.Crashed = !(testAttribute.Expected == e.GetType());
            }
            stopWatch.Stop();
            info.Time = stopWatch.ElapsedMilliseconds;

            testInformation.Add(info);
        }
    }
}