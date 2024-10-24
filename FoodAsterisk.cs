using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char element = '*';
        private const int foodPoints = 1;

        public FoodAsterisk(Wall currentWall) : base(currentWall, element, foodPoints)
        {
        }
    }
}
