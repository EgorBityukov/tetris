using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris.Models
{
    public class Shape
    {
        public List<int> Positions { get; set; }

        public int[,] GetCoordinates()
        {
            int[,] coordinates = new int[2, Positions.Count / 2];

            for (int i = 0; i < Positions.Count / 2; i++)
            {
                coordinates[0, i] = Positions[i];
                coordinates[1, i] = Positions[i + Positions.Count / 2];
            }

            return coordinates;
        }
    }
}
