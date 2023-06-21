namespace homework03
{
    internal class Dec_to_Hex
    {
        static void Main(string[] args)
        {
            int number, i;
            int[] array = new int[10];

            Console.Write("\n\tEnter the number to convert: ");
            number = int.Parse(Console.ReadLine());

            for (i = 0; number > 0; i++)
            {
                array[i] = number % 2;
                number = number / 2;
            }

            Console.Write("\n\tBinary of the given number => ");

            for (i = i - 1; i >= 0; i--)
            {
                Console.Write(array[i]);
            }
            
            Console.WriteLine();
        }
    }
}
