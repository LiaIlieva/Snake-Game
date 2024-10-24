using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class FoodHash : Food
    {
        private const char element = '#';
        private const int foodPoints = 3;

        public FoodHash(Wall currentWall) : base(currentWall, element, foodPoints)
        {
        }
    }
}
