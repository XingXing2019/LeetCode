using System;

namespace CountHousesInACircularStreet
{

    abstract class Street
    {
        public Street(int[] doors);
        public abstract void OpenDoor();
        public abstract void CloseDoor();
        public abstract bool IsDoorOpen();
        public abstract void MoveRight();
        public abstract void MoveLeft();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int HouseCount(Street street, int k)
        {
            var res = 0;
            for (int i = 0; i < k; i++)
            {
                if (street.IsDoorOpen())
                    street.CloseDoor();
                street.MoveRight();
            }
            while (!street.IsDoorOpen())
            {
                res++;
                street.OpenDoor();
                street.MoveRight();
            }
            return res;
        }
    }
}
