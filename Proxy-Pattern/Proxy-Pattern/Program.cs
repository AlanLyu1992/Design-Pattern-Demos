using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 代理模式
{
    class Program
    {
        interface sendlovemessage
        {
            void GiveDolls();
            void GiveFlowers();
            void GiveChocolate();
        }

        class Boy : sendlovemessage
        {
            private string name;
            public string Name
            {
                get {return name;}
                set {name =value;}
            }

            girl girl =new girl();
            public Boy () {}
            public Boy(girl girl)
            {
              
                this.girl =girl;
            }

            
            public void GiveDolls()
            {
                Console.WriteLine(girl.Name +"送你的洋娃娃!");

            }

            public void GiveFlowers()
            {
                Console.WriteLine(girl.Name +"送你的花!");

            }
            
            public void GiveChocolate()
            {
                Console.WriteLine(girl.Name +"送你的巧克力!");
            }
        
        }

        class X:sendlovemessage
        {
            Boy boy;
            public X (String name, girl girl)
            {
                
                boy =new Boy(girl);
                boy.Name =name;


            }
            public void GiveDolls()
            {
                boy.GiveDolls();
            }
            
            public void GiveFlowers()
            {
                boy.GiveFlowers();
            }

            public void GiveChocolate()
            {
                boy.GiveChocolate();
            }
        }

        class girl
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        static void Main(string[] args)
        {
            Boy Alan = new Boy();
            Alan.Name = "Alan";
            girl Joy = new girl();
            Joy.Name = "Joy";
            X x = new X("Alan", Joy);
            x.GiveDolls();
            x.GiveFlowers();
            x.GiveChocolate();
        }
    }
}
