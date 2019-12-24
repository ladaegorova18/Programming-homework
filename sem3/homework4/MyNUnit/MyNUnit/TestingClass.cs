using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using AttributesLibrary;

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
                Console.WriteLine(info.Name);
                if (info.Ignored)
                {
                    Console.Write("Ignored " + info.IgnoreReason);
                }
                else
                {
                    Console.Write(info.Crashed + info.Time.ToString());
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
            foreach (var method in type.GetMethods())
            {
                var testAttribute = Attribute.GetCustomAttribute(method, typeof(TestAttribute)) as TestAttribute;
                if (testAttribute != null)
                {
                    testInformation.Add(RunThisTest(method, testAttribute, type));
                }
            }
        }

        private static TestInfo RunThisTest(MethodInfo method, TestAttribute testAttribute, object instance)
        {
            var parameters = method.GetParameters();
            var crashed = true;
            var info = new TestInfo(method);
            if (testAttribute.Ignore != null)
            {
                info.Ignored = true;
                info.IgnoreReason = testAttribute.Ignore;
                return info;
            }

            try
            {
                method.Invoke(instance, null);
                crashed = (testAttribute.Expected == null);
            }
            catch (Exception e)
            {
                crashed = (testAttribute.Expected == e.InnerException.GetType());
            }

            info.Crashed = crashed;
            return info;
        }
    }
}

//MyNUnit
//перед и после запуска каждого теста в классе должны запускаться методы, помеченные аннотациями Before и After
//перед и после запуска тестов в классе должны запускаться методы, помеченные аннотациями BeforeClass и AfterClass
//BeforeClass и AfterClass должны быть статическими методами, при их запуске объект создаваться не должен
//Тесты должны запускаться возможно более параллельно.

//Приложение должно выводить в стандартный поток вывода отчет:
//о результате и времени выполнения прошедших и упавших тестов
//о причине отключенных тестов