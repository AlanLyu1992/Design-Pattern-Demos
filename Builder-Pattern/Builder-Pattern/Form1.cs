using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 建造者模式
{
    
    public partial class Form1 : Form
    {
        public abstract class PersonBuilder
        {
            protected Graphics g;
            protected Pen p;

            public PersonBuilder(Graphics g, Pen p)
            {
                this.g = g;
                this.p = p;
            }

            public abstract void head();
            public abstract void body();
            public abstract void leg();
        }

        public class ThinPerson : PersonBuilder
        {
            public ThinPerson(Graphics g, Pen p)
                : base(g, p)
            {
            }

            public override void head()
            {
                g.DrawEllipse(p, 500, 200, 300, 300);
            }

            public override void body()
            {
                g.DrawRectangle(p, 600, 500, 100, 500);
            }

            public override void leg()
            {
                g.DrawLine(p, 700, 500, 900, 1000);
            }
        }

        public class FatPerson : PersonBuilder
        {
            public FatPerson(Graphics g, Pen p)
                : base(g, p)
            { }
            public override void head()
            {
                g.DrawEllipse(p, 70, 40, 60, 60);
            }

            public override void body()
            {
                g.DrawRectangle(p, 600, 500, 100, 500);
            }

            public override void leg()
            {
                g.DrawLine(p, 800, 900, 900, 1000);
            }

        }

        public class PersonDirector
        {
            private PersonBuilder pb;
            public PersonDirector(PersonBuilder pb)
            {
                this.pb = pb;
            }

            public void CreatePerson()
            {
                pb.head();
                pb.body();
                pb.leg();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Yellow);
            ThinPerson ptb = new ThinPerson(pictureBox1.CreateGraphics(),p);
            PersonDirector pdthin = new PersonDirector(ptb);
            pdthin.CreatePerson();

            FatPerson pfb = new FatPerson(pictureBox2.CreateGraphics(), p);
            PersonDirector pdf = new PersonDirector(pfb);
            pdf.CreatePerson();

        }
    }
}
