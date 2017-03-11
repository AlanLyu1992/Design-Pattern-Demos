using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 组合模式
{
    class Program
    {
        abstract class Company
        {
            protected string name;

            public Company(string name)
            {
                this.name = name;
            }

            public abstract void Add(Company c);
            public abstract void Remove(Company c);
            public abstract void Display(int depth);
            public abstract void LineOfDuty();
        }

        class ConcreteCompany : Company
        {
            private List<Company> children = new List<Company>();

            public ConcreteCompany(string name)
                : base(name)
            {
            }

            public override void Add(Company c)
            {
                children.Add(c);
            }

            public override void Remove(Company c)
            {
                children.Remove(c);
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new string('-', depth) + name);

                foreach (Company component in children)
                {
                    component.Display(depth + 2);
                }


            }

            public override void LineOfDuty()
            {
                foreach (Company component in children)
                {
                    component.LineOfDuty();
                }
            }
 
                


        }

        class HRDepartment : Company
        {
            public HRDepartment(string name)
                : base(name)
            {
            }

            public override void Add(Company c)
            {
                
            }

            public override void Remove(Company c)
            {
            
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new string('-', depth) + name);
            }

            public override void LineOfDuty()
            {
                Console.WriteLine("{0}员工培训",name);
            }


        }

        class FinanceDepartment : Company
        {
            public FinanceDepartment(string name)
                : base(name)
            {
            }

            public override void Add(Company c)
            {

            }

            public override void Remove(Company c)
            {

            }

            public override void Display(int depth)
            {
                Console.WriteLine(new string('-', depth) + name);
            }

            public override void LineOfDuty()
            {
                Console.WriteLine("{0} 公司财务管理",name);
            }


        }


        static void Main(string[] args)
        {
            ConcreteCompany root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总人力资源部"));
            root.Add(new FinanceDepartment("总公司财务部"));

            ConcreteCompany comp = new ConcreteCompany("上海公司");
            comp.Add(new HRDepartment("上海人力"));
            comp.Add(new FinanceDepartment("上海财务"));
            root.Add(comp);

            ConcreteCompany comp1 = new ConcreteCompany("南京公司");
            comp1.Add(new HRDepartment("南京人力"));
            comp1.Add(new FinanceDepartment("南京财务"));
            comp.Add(comp1);

            ConcreteCompany comp2 = new ConcreteCompany("杭州公司");
            comp2.Add(new HRDepartment("杭州人力"));
            comp2.Add(new FinanceDepartment("杭州财务"));
            comp.Add(comp2);

            Console.WriteLine("\n结构图");
            root.Display(1);

            Console.WriteLine("\n职责:");
            root.LineOfDuty();




        }
    }
}
