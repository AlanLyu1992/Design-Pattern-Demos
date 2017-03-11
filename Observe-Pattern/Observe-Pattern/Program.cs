using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 观察者模式_对事件和委托的复习_
{
    class Program
    {
        class StockObserver
        {
            private string name;
            private Subject sub;
            public StockObserver(string name, Subject sub)
            {
                this.name = name;
                this.sub = sub;
            }

            public void CloseStockMarket()
            {
                Console.WriteLine("{0},{1} continue working!", sub.SubjectState, name);
            }
        }

        class NBAObserver
        {
            private string name;
            private Subject sub;
            public NBAObserver(string name, Subject sub)
            {
                this.name = name;
                this.sub = sub;
            }

            public void CloseNBA()  //方法的参数也符合委托的形式，无
            {
                Console.WriteLine("{0},{1} continue working!", sub.SubjectState, name);
            }
        }

        interface Subject
        {
            void Notify();

            string SubjectState
            {
                get;
                set;
            }
        }

        class Boss : Subject
        {
            public delegate void EventHandler();  //另一种写法，声明一个返回值为void，没有参数的委托, 为了使事件能在其他类中触发，委托和事件的声明都需要用public
            public event EventHandler Update;

            private string action;

            public void Notify()
            {
               // EventArgs e = new EventArgs(); 这样就不用生成事件的参数了
                Update();
            }

            public string SubjectState
            {
                get { return action; }
                set { action = value; }
            }
        }

        static void Main(string[] args)
        {
            Boss Alan = new Boss();

            StockObserver Ben = new StockObserver("Ben", Alan);

            NBAObserver King = new NBAObserver("King", Alan);

            Alan.Update += Ben.CloseStockMarket;
            Alan.Update += King.CloseNBA;
            Alan.SubjectState = "Alan is back!";
            Alan.Notify();

        }
    }
}
