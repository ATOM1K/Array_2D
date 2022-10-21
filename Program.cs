internal class Program
{
    /*
     *Рассмотрим последовательность, образованную дробями:
     *1/1,  2/1,  3/2, …,
     *в которой числитель (знаменатель) следующего члена последовательности
     *получается сложением числителей (знаменателей) двух предыдущих членов.
     *Числители двух первых дробей равны 1 и 2, знаменатели — 1 и 1.
        а) Найти k-й член этой последовательности.
        б) Получить первые n членов этой последовательности.
        в) Верно ли, что сумма первых n членов этой последовательности
        больше числа А? 
     */
    public static void InitArr(int[,] my2dArr)
    {
        my2dArr[0, 0] = 1;
        my2dArr[0, 1] = 2;
        my2dArr[1, 0] = 1;
        my2dArr[1, 1] = 1;
    }

    public static void EnterNumberOfFrac()
    {
        Console.Write("Hello, there! Enter number of fraction, it must be > 3:");
    }

    public static void LoadArr(int[,] myArr, int rowArr, int columnArr)
    {
        for (int columnCounter = 2; columnCounter < columnArr; columnCounter++)
        {
            myArr[rowArr, columnCounter] = myArr[rowArr, columnCounter-1] + myArr[rowArr, columnCounter - 2];
        }
    }

    public static void ShowArr(int[,] myArr, int columnArr)
    {
        for (int columnCounter = 0; columnCounter < columnArr; columnCounter++)
        {
            Console.Write($"{myArr[0, columnCounter]}/{myArr[1, columnCounter]}; ");           
        }
        Console.WriteLine();    
    }

    //Method Overloading
    public static void ShowArr(int[,] myArr)
    {
        Console.Write($"Enter the number of the sequence element to be output, from 1 to {myArr.Length / 2}: ");
        int k = int.Parse(Console.ReadLine()) - 1;
        Console.Write($"{myArr[0, k]}/{myArr[1, k]}; ");
    }

    public static void CompareWithDigit(int[,] myArr)
    {
        float numDenum = 0;
        for (int i = 0; i < myArr.Length / 2; i++)
        {
            numDenum = numDenum + ((float)myArr[0, i] / (float)myArr[1, i]);
        }
        Console.WriteLine();
        Console.WriteLine(Math.Round(numDenum, 2));
    }

    private static void Main(string[] args)
    {
        EnterNumberOfFrac();

        int n = int.Parse(Console.ReadLine());
        int[,] my2dArr = new int[2, n];
        
        InitArr(my2dArr);

        //Call the same method to populate an array row, giving the row number
        LoadArr(my2dArr, 0, n);
        LoadArr(my2dArr, 1, n);

        //Show all members of Array (b/Б)
        ShowArr(my2dArr, n);

        //Show k-member of Array (a/А)
        ShowArr(my2dArr);

        //Compare the sum of H-terms of the sequence with the entered number A (c/В)
        CompareWithDigit(my2dArr);
    }
}