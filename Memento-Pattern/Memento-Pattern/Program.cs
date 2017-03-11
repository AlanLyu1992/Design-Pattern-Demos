using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 备忘录模式
{
    class Program
    {
        class GameRole
        {
            private int vigor;
            private int attack;
            private int defense;
            public int Vigor
            {
                get { return vigor; }
                set { vigor = value; }
            }

            public int Attack
            {
                get { return attack; }
                set { attack = value; }
            }

            public int Defense
            {
                get { return defense; }
                set { defense = value; }
            }

            private Demo demo;
            public void init(int vigor, int attack, int defense)
            {
                this.vigor = vigor;
                this.attack = attack;
                this.defense = defense;
            }

            public void Show()
            {
                Console.WriteLine("{0},{1},{2}", Vigor, Attack, Defense);
            }

            public void Fight()
            {
                this.vigor = 0;
                this.attack = 0;
                this.defense = 0;
            }

            public Demo Save()
            {
                return (new Demo(this.vigor, this.attack, this.defense));
            }

            public void Reborn(Demo demo)
            {
                this.vigor = demo.vigor;
                this.attack = demo.attack;
                this.defense = demo.defense;
            }
        }

        class Demo
        {
            public  int vigor;
            public int attack;
            public int defense;
            public Demo(int vigor, int attack, int defense)
            {
                this.vigor = vigor;
                this.attack = attack;
                this.defense = defense;
            }

        }

        class Savor
        {
            public Demo demo;
        }
        static void Main(string[] args)
        {
            GameRole Alan = new GameRole();
            Alan.init(100, 100, 100);
            Alan.Show();
            Console.WriteLine();
            Savor savor = new Savor();
            savor.demo=Alan.Save();

            Alan.Fight();

            Alan.Show();
            Console.WriteLine();
            Alan.Reborn(savor.demo);
            Alan.Show();
        }
    }
}
