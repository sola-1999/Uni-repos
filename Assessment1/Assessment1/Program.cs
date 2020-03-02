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
            //Console.WriteLine(string.Join(" ", ba));//outputs the array
            disTenth(ba);

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
            //Console.WriteLine(string.Join(" ", ia));//outputs the array
            disTenth(ia);
        }

        static void MergeInitialise(int[] ma, int n)
        {
            int[] temp = new int[n];//Sets temp to the value of n
            MergeRecurs(ma, temp, 0, n - 1);//Runs a recursive sort algorithm
            Console.WriteLine("This is Merge sort: ");
            //Console.WriteLine(string.Join(" ", ma));//outputs the array
            disTenth(ma);
        }

        static void MergeArray(int[] ma, int[] temp, int low, int middle, int high)
        {
            int resIn = low;//Stores result index
            int tempIn = low;//Stores temporary index
            int desIn = middle;//Stores destination index

            while (tempIn < middle && desIn <= high)//Merges smaller values if the list isn't empty
            {
                if (ma[desIn] < temp[tempIn])
                {
                    ma[resIn++] = ma[desIn++];//Moves smaller values
                }
                else
                {
                    ma[resIn++] = temp[tempIn++];//Moves smaller values to temp
                }
            }
            while( tempIn < middle)
            {
                ma[resIn++] = temp[tempIn++];//Sorts values still left in temp
            }
        }

        static void MergeRecurs(int[] ma, int[]temp, int low, int high)
        {
            int n = high - low + 1;//Finds the middle value in the array
            int middle = low + n / 2;//Finds middle value for split arrays
            int i;

            if (n < 2)//Checks if the middle value is below 2
            {
                return;
            }
            for (i = low; i < middle; i++)
            {
                temp[i] = ma[i];//Sets lower half of data into a temp array
            }
            MergeRecurs(temp, ma, low, middle - 1 );//Sorts the lower array
            MergeRecurs(ma, temp, middle, high);//Sorts the higher array
            MergeArray(ma, temp, low, middle, high);//Merges the array
        }

        static void QuickSort(int[] qa, int left, int right)
        {
            int l;//Stores a side left counter
            int r;//Sets a side right counter
            int pivot;//Sets a pivot point
            int temp;//Temp to hold values

            l = left;//Sets to the farmost left value
            r = right;//Sets to the farmost right value

            pivot = qa[(left + right) / 2];//Sets the pivot to a middle value

            do
            {
                while ((qa[l] < pivot) && (l < right)) l++;//Loops through the the array from the left side
                while ((pivot < qa[r]) && (r > left)) r--;//Loops through the the array from the right side

                if (l <= r)
                {
                    temp = qa[l];//Stores the current left value in a temp
                    qa[l] = qa[r];//Swaps the current right value with left
                    qa[r] = temp;//Stores the temp value in the right location
                    l++;
                    r--;//Increments left and right counter


                }
            } while (l <= r);

            if (left < r) QuickSort(qa, left, r);//Sorts if the left value is lower than the right counter
            if (l < right) QuickSort(qa, l, right);//Sorts if the left counter is lower than the right value



        }

        static void QuickSortInitialise(int[] qa, int n)
        {
            QuickSort(qa, 0, n - 1);//Runs a quick sort
            Console.WriteLine("This is Quick sort: ");
            //Console.WriteLine(string.Join(" ", qa));//outputs the array
            disTenth(qa);
        }



        static void convertArray(string[] atc)
        {
            int len = atc.Length;//Gets lenght of the array

            int[] intarray = Array.ConvertAll(atc, s => int.Parse(s));//Converts array of strings to array integers

 
            bubbleSort(intarray, len);//Runs the bubble sort method
            Console.WriteLine("");
            insertionSort(intarray, len);//Runs the insertion sort method
            Console.WriteLine("");
            MergeInitialise(intarray, len);//Runs the merge sort method
            Console.WriteLine("");
            QuickSortInitialise(intarray, len);//Runs the quick sort method
        }

        static string LenSelect()
        {
            Console.WriteLine("Type which lenght array you want to select( 256, 2048): ");
            string lenSelect = Console.ReadLine();//Saves lenght selection
            return lenSelect;//Returns selection
        }

        static void disTenth(int[] dta)
        {
            int[] newa = null;
            int pointCounter = 1;
            foreach (int i in dta)
            {
                if (pointCounter == 10)
                {
                    int value = dta[i];
                    pointCounter = 1;
                }
                else
                {
                    pointCounter++;
                }
                
            }
            Console.WriteLine(string.Join(" ", newa));

        }

    }
}
