using System;

namespace FlappyServer.Model
{
    public class MapInGame
    {
        private double[] top;
        private double[] bottom;

        public MapInGame(double range)
        {
            top = new double[10];
            bottom = new double[10];
            for (int i = 0; i < 10; i++)
            {
                top[i] = new Random().NextDouble() * range;
                bottom[i] = range - top[i];
            }
        }

        public double[] Top { get => top;}
        public double[] Bottom { get => bottom;}
    }
}
