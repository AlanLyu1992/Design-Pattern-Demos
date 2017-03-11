using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 状态模式
{
    class Program
    {
        public class Work
        {
            private double hours;
            public double Hours
            {
                get { return hours; }
                set { hours = value; }
            }

            private bool finished;
            public bool Finished
            {
                get { return finished; }
                set { finished = value; }
            }

            private State current;
            public Work()
            {
                this.current = new Morning();
            }

            public void SetState(State s)
            {
                this.current = s;
            }

            public void WriteProgram()
            {
                this.current.WriteProgram(this);
            }
        
        }

        public abstract class State
        {
            public abstract void WriteProgram(Work w);
        }

        public class Morning : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.Hours < 10)
                {
                    Console.WriteLine("this is morning!");
                }
                else
                {
                    w.SetState(new AfterNoon());
                    w.WriteProgram();
                }
            }

        }

        public class AfterNoon : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.Hours < 13)
                {
                    Console.WriteLine("this is Afternoon!");
                }
                else
                {
                    w.SetState(new Evening());
                    w.WriteProgram();
                }
            }

        }

        public class Evening : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.Finished)
                {
                    Console.WriteLine("this is Evening!");
                }
                else
                {
                    if (w.Hours < 20)
                    {
                        w.SetState(new Gohome());
                        w.WriteProgram();
                    }
                }
            }

        }

        public class Gohome : State
        {
            public override void WriteProgram(Work w)
            {
               
                    Console.WriteLine("You need go home");
                    w.SetState(new Sleep());
                    w.WriteProgram();
            }


        }

        public class Sleep : State
        {
            public override void WriteProgram(Work w)
            {

                Console.WriteLine("I am sleeping!");
                
            }


        }
        static void Main(string[] args)
        {
            Work em = new Work();
            em.Hours = 9;
            em.WriteProgram();
            em.Hours = 12;
            em.WriteProgram();
            em.Hours = 15;
            em.WriteProgram();

           
            em.Hours = 21;
            em.WriteProgram();

            
            em.Hours = 15;
            em.WriteProgram();
           
        }
    }
}
