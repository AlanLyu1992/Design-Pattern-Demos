using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 装饰模式
{
    class Program
    {
        class person
        {
            public person() { }
            private string name;
            public person(string name)
            {
                this.name = name;
            }

            public virtual void show()
            {
                Console.WriteLine("装扮的{0}", name);
            }

        }

        class clothes : person
        {
            protected person component;
            public void Decorate(person component)
            {
                this.component = component;
            }

            public override void show()
            {
                if(component !=null)
                component.show();
            }
        }

        class Tshirts : clothes
        {
            public override void show()
            {
                Console.Write("Tshirt ");
                base.show();
            }
        }

        class bigku : clothes
        {
            public override void show()
            {
                Console.Write("kuzi ");
                base.show();
            }
        }

        class underwear : clothes
        {
            public override void show()
            {
                Console.Write("underwear ");
                base.show();
            }
        }

        static void Main(string[] args)
        {
            person Alan = new person("Alan");
            Console.WriteLine("第一种装扮");

            Tshirts Tshirts = new Tshirts();
            bigku bigku = new bigku();
            underwear underwear = new underwear();

            Tshirts.Decorate(Alan);
            bigku.Decorate(Tshirts);
            underwear.Decorate(bigku);
            underwear.show();
        }

    }
}
