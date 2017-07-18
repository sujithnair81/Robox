using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboX
{
    class Program
    {
        static void Main(string[] args)
        {

            Robot robo = Robot.GetRobot();

            //Test Sort Chip

            var numbers = new int[6] {4, 5, 2, 1,6,8};
            IChip sortChipAsc = new SortChip(Order.Ascending);
            robo.Plug(sortChipAsc);

            var output1 = robo.Execute(numbers);

            Console.WriteLine("*******Ascending Chip******");
            foreach (var n in output1)
            {
                Console.WriteLine(n);
            }

            IChip sortChipDesc = new SortChip(Order.Descending);
            robo.Plug(sortChipDesc);

            var output = robo.Execute(numbers);

            Console.WriteLine("*******Descending Chip******");
            foreach (var n in output)
            {
                Console.WriteLine(n);
            }

            IChip sumChip = new SumChip();
            robo.Plug(sumChip);

            var outputSum = robo.Execute(numbers);

            Console.WriteLine("*******Sum Chip******");
            foreach (var n in outputSum)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("*******Total Chips******");
            Console.WriteLine(robo.NumberOfChipsInstalled);

            Console.ReadLine();
        }
    }
    //Used a singleton pattern , which is ideal for these kind of problems
    public class Robot
    {
        private static Robot _robot;
        private static IChip _chip;
        private int _numberOfChipsInstalled;
        private Robot()
        {

        }

        public static Robot GetRobot()
        {
            return _robot ?? (_robot = new Robot());
        }

        public int[] Execute(int[] numbers)
        {

            if (_chip == null)
            {
                Console.WriteLine("Please Install a chip");
                return null;
            }


            if (numbers != null && numbers.Length > 0)
            {
                return _chip.Execute(numbers);
            }

            return null;

        }

        public void Plug(IChip chip)
        {
            _chip = chip;
            _numberOfChipsInstalled++;
        }

        public int NumberOfChipsInstalled { get { return _numberOfChipsInstalled; } }

    }

    public enum Order
    {
        Ascending,
        Descending
    }
    public class SortChip : IChip
    {
        private Order _orderType;
        public SortChip(Order orderType)
        {
            _orderType = orderType;
        }
        public int[] Execute(int[] numbers)
        {
            return Sort(numbers);
        }

        private int[] Sort(int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)
            {

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    //could have made better with a reusable code
                    if (_orderType == Order.Ascending)
                    {
                        if (numbers[i] > numbers[j])
                        {
                            var temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }
                    else
                    {
                        if (numbers[i] < numbers[j])
                        {
                            var temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }

                }
            }

            return numbers;
        }



    }
    public class SumChip : IChip
    {
        public int[] Execute(int[] numbers)
        {
            return new int[1] { TotalSum(numbers) };
        }

        public int TotalSum(int[] numbers)
        {
            int sum = 0;
            foreach (var value in numbers)
            {
                sum = sum + value;
            }
            return sum;

        }
    }

    public interface IChip
    {
        int[] Execute(int[] numbers);
    }
}
