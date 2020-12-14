using System;

namespace TrafficLightControlledIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class TrafficLight
    {
        private int curRoad = 1;
        public TrafficLight()
        {

        }

        public void CarArrived(
            int carId,         // ID of the car
            int roadId,        // ID of the road the car travels on. Can be 1 (road A) or 2 (road B)
            int direction,     // Direction of the car
            Action turnGreen,  // Use turnGreen() to turn light to green on current road
            Action crossCar    // Use crossCar() to make car cross the intersection
        )
        {
            if (roadId != curRoad)
            {
                curRoad = roadId;
                turnGreen();
            }
            crossCar();
        }
    }
}
