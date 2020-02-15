﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Where(x => x.Substring(x.LastIndexOf('\\') + 1) != "Attributes.dll");
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
            if (type.GetConstructor(new Type[] { }) == null)
            {
                return;
            }
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
                var invokeMethods = new List<(MethodInfo, object)>();
                for (var i = 0; i < methods.Count; ++i)
                {
                    invokeMethods.Add((methods[i], instance));
                }
                Parallel.ForEach(invokeMethods, task);
            }
        }

        private static Action<(MethodInfo, object)> MakeTask<AttributeType>(List<MethodInfo> methods, object instance)
        {
            if (typeof(AttributeType) == typeof(BeforeAttribute) || typeof(AttributeType) == typeof(BeforeClassAttribute)
                || typeof(AttributeType) == typeof(AfterClassAttribute) || typeof(AttributeType) == typeof(AfterAttribute))
            {
                foreach (var method in methods)
                {
                    if (!method.IsStatic && (typeof(AttributeType) == typeof(BeforeClassAttribute) || typeof(AttributeType) == typeof(AfterClassAttribute)))
                    {
                        throw new InvalidOperationException();
                    }
                    return (Action<(MethodInfo, object)>)method.Invoke(instance, null);
                }
            }
            else if (typeof(AttributeType) == typeof(TestAttribute))
            {
                foreach (var method in methods)
                {
                    return RunTest;
                }
            }
            return null;
        }

        private static void RunTest((MethodInfo, object) task) 
        {
            var testAttribute = (TestAttribute)Attribute.GetCustomAttribute(task.Item1, typeof(TestAttribute));
            TestInfo info = null;
            bool ignored = false;
            string ignoreReason = null;
            bool crashed = false;
            long time = 0;
            if (testAttribute.Ignore != null)
            {
                ignored = true;
                ignoreReason = testAttribute.Ignore;
                info = new TestInfo(task.Item1, ignored, ignoreReason, crashed, time);
                TestInformation.Add(info);
                return;
            }
            if (task.Item1.GetParameters().Length > 0)
            {
                crashed = true;
                info = new TestInfo(task.Item1, ignored, ignoreReason, crashed, time);
                TestInformation.Add(info);
                return;
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                task.Item1.Invoke(task.Item2, null);
                crashed = testAttribute.Expected != null;
            }
            catch (Exception e)
            {
                crashed = testAttribute.Expected != e.InnerException.GetType();
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;

            info = new TestInfo(task.Item1, ignored, ignoreReason, crashed, time);
            TestInformation.Add(info);
        }
    }
}