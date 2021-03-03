using System;

/// <summary>
/// 模板模式
/// 定义：定义一个模板结构，将具体实现延迟到子类去实现
/// 作用：在不改变模板结构的情况下，在子类中重新定义模板的内容
/// 解决问题：
/// 1、提高代码复用率（将相同的代码放到抽象的父类中，而将不同的实现放在不同的子类中）
/// 2、实现了反向控制（通过一个父类调用其子类的操作，通过对子类的具体实现扩展不同的行为，实现了反转控制。同时符合“开闭原则” ！！！）
/// </summary>
namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var baocai = new FryBaoCai();
            baocai.CookProcess();

            var caixin = new FryCaiXin();
            caixin.CookProcess();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 手撕包菜
    /// </summary>
    public class FryBaoCai : FoodAbstract
    {
        /// <summary>
        /// 放入包菜
        /// </summary>
        public override void PourVegetable()
        {
            Console.WriteLine("放入包菜");
        }

        /// <summary>
        /// 放入调味料
        /// </summary>
        public override void PourSauce()
        {
            Console.WriteLine("放入辣椒");
        }


    }

    /// <summary>
    /// 蒜蓉菜心
    /// </summary>
    public class FryCaiXin : FoodAbstract
    {
        /// <summary>
        /// 放入包菜
        /// </summary>
        public override void PourVegetable()
        {
            Console.WriteLine("放入菜心");
        }

        /// <summary>
        /// 放入调味料
        /// </summary>
        public override void PourSauce()
        {
            Console.WriteLine("放入蒜蓉");
        }
    }

    /// <summary>
    /// 模板方法
    /// 以炒菜为例，
    /// </summary>
    public abstract class FoodAbstract
    {
        public void CookProcess()
        {
            PourOil();
            HeatOil();
            PourVegetable();
            PourSauce();
            Fry();
        }

        /// <summary>
        /// 倒油是一样的，直接实现
        /// </summary>
        private void PourOil()
        {
            Console.WriteLine("倒油");
        }

        /// <summary>
        /// 热油是一样的，直接实现
        /// </summary>
        private void HeatOil()
        {
            Console.WriteLine("热油");
        }

        /// <summary>
        /// 蔬菜不一样，所以声明为抽象方法，由子类去实现
        /// </summary>
        public abstract void PourVegetable();

        /// <summary>
        /// 调味料不一样，所以声明为抽象方法，由子类去实现
        /// </summary>
        public abstract void PourSauce();

        /// <summary>
        /// 翻炒是一样的，直接实现
        /// </summary>
        private void Fry()
        {
            Console.WriteLine("翻炒");
        }
    }
}
