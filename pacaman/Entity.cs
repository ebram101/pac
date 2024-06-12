using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
