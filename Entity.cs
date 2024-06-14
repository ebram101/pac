using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This C# code defines a namespace `pac` containing an abstract class `Entity`. The `Entity` class has
protected integer fields `x` and `y`, as well as a 2D character array `maze`. It has a constructor
that initializes the `x`, `y`, and `maze` fields. */
namespace pac
{
    public abstract class Entity
    {
        protected int x;
        protected int y;
        protected char[,] maze;

        public Entity(int x , int y , char[,]maze) 
        {
           this.x = x;
           this.y = y;
           this.maze = maze;
        }

        public abstract void draw();
        
            public int GetX() => x;
            public int GetY() => y;
        


    }
}
