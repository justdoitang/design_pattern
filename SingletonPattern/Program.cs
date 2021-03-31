using System;
using System.Threading;

/*
 * 单例模式
 * 确保某一个类只有一个实例，而且自行实例化向整个系统提供这个实例
 * 实现单例模式有两种方案，饿汉式和懒汉式
 */
namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // var a1 = EagerSingleton.GetInstance();
            // var a2 = EagerSingleton.GetInstance();
            // if (a1 == a2)
            // {
            //     Console.WriteLine("两个变量包含同一个实例");
            // }
            //
            // EagerSingleton.Print();
            
            
            var process1 = new Thread(() =>
            {
                TestSingleton("Foo");
            });
            
            var process2 = new Thread(() =>
            {
                TestSingleton("Boo");
            });
            
            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        private static void TestSingleton(string value)
        {
            var singleton = LazySingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
            
        }
    }

    /// <summary>
    /// 饿汉式
    /// 相同的类在多线程环境中会出错。 多线程可能会同时调用构建方法并获取多个单例类的实例
    /// </summary>
    public class EagerSingleton
    {
        //单例模式下，构造函数必须为私有的，防止使用new 运算符直接进行构造调用
        private EagerSingleton()
        {
        }

        private static EagerSingleton _instance;

        public static EagerSingleton GetInstance()
        {
            return _instance ??= new EagerSingleton();
        }

        public static void Print()
        {
            Console.WriteLine("单例模式之饿汉式");
        }
    }

    /// <summary>
    /// 懒汉式
    /// 实现双重锁机制，在多线程环境话是安全的
    /// </summary>
    public class LazySingleton
    {
        private LazySingleton()
        {
        }

        private static LazySingleton _instance;

        private static readonly object _lock = new object();

        public static LazySingleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LazySingleton();
                        _instance.Value = value;
                    }
                }   
            }

            return _instance;
        }

        public string Value { get; set; }
    }
}