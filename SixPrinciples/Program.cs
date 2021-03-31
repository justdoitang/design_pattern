using System;

/*
 *面向对象设计-五大原则  SOLID
 *
 * 单一原则
 * 对象应该仅具有一种单一功能
 *  
 * 开放闭合原则
 * 软件中的对象（类，模块，函数等等），应该对扩展开放，对修改关闭。这意味着一个实体是允许在不改变它的源代码的前提下变更它的行为。
 * 如Demo所示，可以在不修改抽象类的情况下，定义新的图形实现类来继承抽象基类。然后在调用的时候直接使用实现类
 *
 * 里氏替换原则
 * 程序中的对象应该是可以在不改变程序正确性的前提下被它的子类所替换的
 * 
 * 依赖倒置原则
 * 依赖于抽象而不是一个实例
 * 
 * 接口隔离原则
 * 多个特定客户端接口要好于一个宽泛用途的接口
 */
namespace SixPrinciples
{
    static class Program
    {
        static void Main(string[] args)
        {
            Draw(new RoundShape());//里氏替换原则
            Console.ReadLine();
        }

        /*
         * 里氏替换原则
         * 派生类（子类）对象可以在程序中代替其基类（超类）对象。
         */
        static void Draw(Shape shape)
        {
            Console.WriteLine("开始绘画");
            shape.Draw();
            Console.WriteLine("结束绘画");
        }
    }

    /// <summary>
    /// 定义抽象类
    /// </summary>
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制矩形");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制三角形");
        }
    }
    
    public class RoundShape : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("绘制圆形");
        }
    }
}