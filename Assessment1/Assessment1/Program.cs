using System;
using System.IO;


namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ec = true;//Used for error checking
            string[] selectedArray;
            string[] Array1_256 = System.IO.File.ReadAllLines("Net_1_256.txt");
            string[] Array2_256 = System.IO.File.ReadAllLines("Net_2_256.txt");
            string[] Array3_256 = System.IO.File.ReadAllLines("Net_3_256.txt");
            string[] Array1_2048 = System.IO.File.ReadAllLines("Net_1_2048.txt");
            string[] Array2_2048 = System.IO.File.ReadAllLines("Net_2_2048.txt");
            string[] Array3_2048 = System.IO.File.ReadAllLines("Net_3_2048.txt");//Fetches files from the debug folder


            while(ec == true)
            {
                Console.WriteLine("Type the number of the array you want to sort and search (1, 2, 3): ");
                string numSelect = Console.ReadLine();//Takes array selection from the user

                if (numSelect == "1")//Determines if the user selected array1
                {
                    string selectedLen = LenSelect();//Runs method to select array lenght
                    if (selectedLen == "256")//Determines lenghts selection from user
                    {
                        selectedArray = Array1_256;//Selects array
                        ec = false;//Pases error checking
                        convertArray(selectedArray);//Runs bubble sorting
                    }
                    else if (selectedLen == "2048")//Determines lenghts selection from user
                    {
                        selectedArray = Array1_2048;//Selects array
                        ec = false;//Pases error checking
                        convertArray(selectedArray);//Runs bubble sorting
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        ec = true;//Rpeats loop due to input error
                    }

                }
                else if (numSelect == "2")//Determines if the user selected array2
                {
                    string selectedLen = LenSelect();
                    if (selectedLen == "256")
                    {
                        selectedArray = Array2_256;
                        ec = false;
                        convertArray(selectedArray);
                    }
                    else if (selectedLen == "2048")
                    {
                        selectedArray = Array3_2048;
                        ec = false;
                        convertArray(selectedArray);
                    }
                    else
                    { 
                        Console.WriteLine("Invalid input");
                        ec = true;
                    }
                }
                else if (numSelect == "3")//Determines if the user selected array3
                {
                    string selectedLen = LenSelect();
                    if (selectedLen == "256")
                    {
                        selectedArray = Array3_256;
                        convertArray(selectedArray);
                        ec = false;
                    }
                    else if (selectedLen == "2048")
                    {
                        selectedArray = Array3_2048;
                        convertArray(selectedArray);
                        ec = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        ec = true;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                    ec = true;//Rpeats loop due to input error
                }
            }

            

        }

        static void bubbleSort(int[] ba, int n)
        {

            for (int i = 0; i < n - 1; i++)//Loops throgh each intger in the array 
            {
                for (int j = 0; j < n - 1 - i; j++)//Loops through each number before i in thr array
                {
                    if (ba[j + 1] < ba[j])//Checks if j is more or less than the number to its right
                    {
                        int temp = ba[j];//stores j in a temp
                        ba[j] = ba[j + 1];// swaps j and the number next to it
                        ba[j + 1] = temp;// swaps the number next to j with j stored in temp

                    }

                }
            }
            Console.WriteLine("This is bubble sort: ");
            Console.WriteLine(string.Join(" ", ba));//outputs the array

        }

        static void insertionSort(int [] ia, int n)
        {
            int pointer = 1;//sets a pointer
            int index;//sets an index
            while (pointer < n)//Loops through the array
            {
                int temp = ia[pointer];//Temp value to hold to value in pointer
                
                for (index = pointer; index > 0; index--)//Loops through each value lower than the index
                {
                    
                    if (temp < ia[index-1])//Checks if the pointers value is less than the current index
                    {
                        ia[index] = ia[index - 1];//Moves the number one left from the index
                    }
                    else
                    {
                        break;//leaves loop
                    }
                    
                }
                ia[index] = temp;//Sets the index value to the pointers value
                pointer++;//Increments the pointer
            }
            Console.WriteLine("This is inserstion sort: ");
            Console.WriteLine(string.Join(" ", ia));//outputs the array
        }

        static void convertArray(string[] atc)
        {
            int len = atc.Length;//Gets lenght of the array

            int[] intarray = Array.ConvertAll(atc, s => int.Parse(s));//Converts array of strings to array integers

 
            bubbleSort(intarray, len);//Runs the bubble sort method
            Console.WriteLine("");
            insertionSort(intarray, len);
        }

        static string LenSelect()
        {
            Console.WriteLine("Type which lenght array you want to select( 256, 2048): ");
            string lenSelect = Console.ReadLine();//Saves lenght selection
            return lenSelect;//Returns selection
        }

    }
}
