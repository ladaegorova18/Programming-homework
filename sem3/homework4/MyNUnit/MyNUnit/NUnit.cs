using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using AttributesLibrary;

namespace MyNUnit
{
    public class TestingClass
    {
        public string Path { get; set; } = null;

        public ConcurrentQueue<TestInfo> testInformation = new ConcurrentQueue<TestInfo>();


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
                    RunThisTest(method, testAttribute, type);
                }
            }
        }

        private static TestInfo RunThisTest(MethodInfo method, TestAttribute testAttribute, object instance)
        {
            var info = new TestInfo();
            var parameters = method.GetParameters();
            var crashed = true;
            if (testAttribute.Ignored)
            {
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
//у аннотации может быть два аргумента -- Expected для исключения, Ignore(со строковым параметром) -- для отмены запуска и указания причины
//перед и после запуска каждого теста в классе должны запускаться методы, помеченные аннотациями Before и After
//перед и после запуска тестов в классе должны запускаться методы, помеченные аннотациями BeforeClass и AfterClass
//BeforeClass и AfterClass должны быть статическими методами, при их запуске объект создаваться не должен
//Тесты должны запускаться возможно более параллельно.

//Приложение должно выводить в стандартный поток вывода отчет:
//о результате и времени выполнения прошедших и упавших тестов
//о причине отключенных тестов
//Юнит-тесты на систему тестирования обязательны (при этом они должны быть написаны не на ней самой, а на чём-то более отлаженном, типа NUnit).
