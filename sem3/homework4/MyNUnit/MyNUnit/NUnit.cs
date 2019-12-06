using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNUnit
{
    public class NUnit
    {
        private string path = null;
        private List<string> files = new List<string>();

        public NUnit(string path)
        {
            this.path = path;
        }

        public string Process()
        {
            GetAllFiles(path, ".dll", files);
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFrom(file);
                var testClasses = new List<Type>();
                foreach (var type in assembly.GetTypes())
                {
                    if (Attribute.IsDefined(type, typeof(TestClass))
                    {
                        RunTests(type);
                    }
                }
            }
        }

        private static void RunTests(Type type)
        {
            foreach (var method in type.GetMethods())
            {
                if (Attribute.IsDefined(method, typeof(TestMethod)))
                {

                }
            }
        }

        private void GetAllFiles(string root, string extension, List<string> files)
        {
            var directories = Directory.GetDirectories(path);
            files.AddRange(Directory.GetFiles(root, extension));
            foreach (var currentPath in directories)
            {
                GetAllFiles(currentPath, extension, files);
            }
        }
    }
}

//MyNUnit
//Реализовать command-line приложение, принимающее на вход путь и выполняющее запуск тестов, находящихся во всех сборках, расположенных по этому пути:
//тестом считается метод, помеченный аннотацией Test
//у аннотации может быть два аргумента -- Expected для исключения, Ignore(со строковым параметром) -- для отмены запуска и указания причины
//перед и после запуска каждого теста в классе должны запускаться методы, помеченные аннотациями Before и After
//перед и после запуска тестов в классе должны запускаться методы, помеченные аннотациями BeforeClass и AfterClass
//BeforeClass и AfterClass должны быть статическими методами, при их запуске объект создаваться не должен
//Тесты должны запускаться возможно более параллельно.
//Приложение должно выводить в стандартный поток вывода отчет:
//о результате и времени выполнения прошедших и упавших тестов
//о причине отключенных тестов
//Юнит-тесты на систему тестирования обязательны (при этом они должны быть написаны не на ней самой, а на чём-то более отлаженном, типа NUnit).
