using System;
using System.IO;
using System.Collections.Generic;


namespace Assessment1
{
    class Program
    {
        static int counter;//Used as a counter to track operations

        static void Main(string[] args)
        {
            bool ec = true;//Used for error checking
            string[] selectedArray;//Stores selected array
            int[] sortedArray;//Stores sorted array
            string[] Array1_256 = System.IO.File.ReadAllLines("Net_1_256.txt");
            string[] Array2_256 = System.IO.File.ReadAllLines("Net_2_256.txt");
            string[] Array3_256 = System.IO.File.ReadAllLines("Net_3_256.txt");
            string[] Array1_2048 = System.IO.File.ReadAllLines("Net_1_2048.txt");
            string[] Array2_2048 = System.IO.File.ReadAllLines("Net_2_2048.txt");
            string[] Array3_2048 = System.IO.File.ReadAllLines("Net_3_2048.txt");//Fetches files from the debug folder
            


            while (ec == true)
            {
                Console.WriteLine("Type the number of the array you want to sort and search (1, 2, 3, 4 = merge): ");
                string numSelect = Console.ReadLine();//Takes array selection from the user

                if (numSelect == "1")//Determines if the user selected array1
                {
                    string selectedLen = LenSelect();//Runs method to select array lenght
                    if (selectedLen == "256")//Determines lenghts selection from user
                    {
                        selectedArray = Array1_256;//Selects array
                        ec = false;//Pases error checking
                        sortedArray = convertArray(selectedArray);//Converts array from strings to integers
                        chooseSort(sortedArray);//Runs the choose array method
                    }
                    else if (selectedLen == "2048")//Determines lenghts selection from user
                    {
                        selectedArray = Array1_2048;//Selects array
                        ec = false;//Pases error checking

                        sortedArray = convertArray(selectedArray);//Converts array from strings to integers
                        chooseSort(sortedArray);//Runs the choose array method
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

                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
                    }
                    else if (selectedLen == "2048")
                    {
                        selectedArray = Array3_2048;
                        ec = false;

                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
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

                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
                        ec = false;
                    }
                    else if (selectedLen == "2048")
                    {
                        selectedArray = Array3_2048;

                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
                        ec = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        ec = true;
                    }


                }
                else if (numSelect == "4")//Determines if the user selected to merge all of the arrays
                {
                    
                    string selectedLen = LenSelect();
                    if (selectedLen == "256")
                    {
                        

                        selectedArray = merge3(Array1_256,Array2_256,Array3_256);//Merges arrays

                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
                        ec = false;
                    }
                    else if (selectedLen == "2048")
                    {

                        selectedArray = merge3(Array1_2048, Array2_2048, Array3_2048);//Merges arrays
                        ec = false;
                        sortedArray = convertArray(selectedArray);
                        chooseSort(sortedArray);
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

        static void bubbleSort(int[] ba, int n, string order)
        {
            if (order == "a")//Sorting in ascending order
            {
                
                for (int i = 0; i < n - 1; i++)//Loops throgh each intger in the array 
                {
                    
                    for (int j = 0; j < n - 1 - i; j++)//Loops through each number before i in thr array
                    {
                        counter++;
                        if (ba[j + 1] < ba[j])//Checks if j is more or less than the number to its right
                        {
                            int temp = ba[j];//stores j in a temp
                            ba[j] = ba[j + 1];// swaps j and the number next to it
                            ba[j + 1] = temp;// swaps the number next to j with j stored in temp

                        }

                    }
                }
               
            }
            else if (order == "d")//Sorting in decsending order
            {
                
                for (int i = 0; i < n - 1; i++)//Loops throgh each intger in the array 
                {
                    
                    for (int j = 0; j < n - 1 - i; j++)//Loops through each number before i in thr array
                    {
                        counter++;
                        if (ba[j + 1] > ba[j])//Checks if j is more or less than the number to its right
                        {
                            int temp = ba[j];//stores j in a temp
                            ba[j] = ba[j + 1];// swaps j and the number next to it
                            ba[j + 1] = temp;// swaps the number next to j with j stored in temp

                        }

                    }
                }

            }
            Console.WriteLine("This is bubble sort: ");
            disTenth(ba, n);//Runs disTenth method

        }

        static void insertionSort(int [] ia, int n, string order)
        {
            if(order == "a")//Ascending order sort
            {
                int pointer = 1;//sets a pointer
                int index;//sets an index
                while (pointer < n)//Loops through the array
                {
                    int temp = ia[pointer];//Temp value to hold to value in pointer

                    for (index = pointer; index > 0; index--)//Loops through each value lower than the index
                    {
                        counter++;
                        if (temp < ia[index - 1])//Checks if the pointers value is less than the current index
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
            }
            else if(order == "d")//Sorts in descending order 
            {
                int pointer = 1;//sets a pointer
                int index;//sets an index
                while (pointer < n)//Loops through the array
                {
                    int temp = ia[pointer];//Temp value to hold to value in pointer

                    for (index = pointer; index > 0; index--)//Loops through each value lower than the index
                    {
                        counter++;
                        if (temp > ia[index - 1])//Checks if the pointers value is less than the current index
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
            }
            Console.WriteLine("This is inserstion sort: ");
            disTenth(ia, n);//Runs disTenth method
        }

        static void MergeInitialise(int[] ma, int n, string choice)
        {
            int[] temp = new int[n];//Sets temp to the value of n
            MergeRecurs(ma, temp, 0, n - 1, choice);//Runs a recursive sort algorithm
            Console.WriteLine("This is Merge sort: ");
            disTenth(ma, n);//Runs disTenth method
        }

        static void MergeArray(int[] ma, int[] temp, int low, int middle, int high, string choice)
        {
            if (choice == "a")//Sorting in ascending order
            {
                int resIn = low;//Stores result index
                int tempIn = low;//Stores temporary index
                int desIn = middle;//Stores destination index

                while (tempIn < middle && desIn <= high)//Merges smaller values if the list isn't empty
                {
                    counter++;
                    if (ma[desIn] < temp[tempIn])
                    {
                        ma[resIn++] = ma[desIn++];//Moves smaller values
                    }
                    else
                    {
                        ma[resIn++] = temp[tempIn++];//Moves smaller values to temp
                    }
                }
                while (tempIn < middle)
                {
                    counter++;
                    ma[resIn++] = temp[tempIn++];//Sorts values still left in temp
                }
            }
            else if (choice == "d")//Sorting in decsending order
            {
                int resIn = low;//Stores result index
                int tempIn = low;//Stores temporary index
                int desIn = middle;//Stores destination index

                while (tempIn < middle && desIn <= high)//Merges smaller values if the list isn't empty
                {
                    counter++;
                    if (ma[desIn] > temp[tempIn])
                    {
                        ma[resIn++] = ma[desIn++];//Moves smaller values
                    }
                    else
                    {
                        ma[resIn++] = temp[tempIn++];//Moves smaller values to temp
                    }
                }
                while (tempIn < middle)
                {
                    counter++;
                    ma[resIn++] = temp[tempIn++];//Sorts values still left in temp
                }
            }
        }

        static void MergeRecurs(int[] ma, int[]temp, int low, int high, string choice)
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
                counter++;
                temp[i] = ma[i];//Sets lower half of data into a temp array
            }
            MergeRecurs(temp, ma, low, middle - 1, choice );//Sorts the lower array
            MergeRecurs(ma, temp, middle, high, choice);//Sorts the higher array
            MergeArray(ma, temp, low, middle, high, choice);//Merges the array
        }

        static void QuickSort(int[] qa, int left, int right, string choice)
        {
            if (choice == "a")//Sorting in ascending order
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
                    counter++;
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

                if (left < r) QuickSort(qa, left, r, choice);//Sorts if the left value is lower than the right counter
                if (l < right) QuickSort(qa, l, right, choice);//Sorts if the left counter is lower than the right value

            }
            else if(choice == "d")//Sorting in decsending order
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
                    counter++;
                    while ((qa[l] > pivot) && (l < right)) l++;//Loops through the the array from the left side
                    while ((pivot > qa[r]) && (r > left)) r--;//Loops through the the array from the right side

                    if (l <= r)
                    {
                        temp = qa[l];//Stores the current left value in a temp
                        qa[l] = qa[r];//Swaps the current right value with left
                        qa[r] = temp;//Stores the temp value in the right location
                        l++;
                        r--;//Increments left and right counter


                    }
                } while (l <= r);

                if (left < r) QuickSort(qa, left, r, choice);//Sorts if the left value is lower than the right counter
                if (l < right) QuickSort(qa, l, right, choice);//Sorts if the left counter is lower than the right value
            }

        }

        static void QuickSortInitialise(int[] qa, int n,string choice)
        {
            QuickSort(qa, 0, n - 1, choice);//Runs a quick sort
            Console.WriteLine("This is Quick sort: ");
            disTenth(qa, n);//Runs disTenth method
        }
        static int[] QuickSortReturn(int[] qa, int n)//A sort array used to return for searching
        {
            string choice = "a";
            QuickSort(qa, 0, n - 1, choice);//Runs a quick sort
            return qa;
        }

        static void BinarySearch(int key, int[] search, int low, int high)
        {
            counter++;
            if(key > search.Length)//Checks if key is outside the bounds of the array
            {
                Console.WriteLine("");
                Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", search[high], high);//Prints closest value
                Console.WriteLine("Result found in {0} operations", counter);
            }
            else if (key < 0)//Checks if key is outside the bounds of the array
            {
                Console.WriteLine("");
                Console.WriteLine("Sub zero values not accepted, the first value in this array is {0}", search[low]);//Prints closest value
                Console.WriteLine("Result found in {0} operations", counter);
            }
            else if (low > high)//Checks if the value isnt found 
            {
                    
                int closest = comp(key, low, high, search);//Finds the closest value

                if (closest == search[low])
                {
                    Console.WriteLine("");
                    Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", closest, low);//Prints closest value
                    Console.WriteLine("Result found in {0} operations", counter);
                }
                else if (closest == search[high])
                {
                    Console.WriteLine("");
                    Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", closest, high);//Prints closest value
                    Console.WriteLine("Result found in {0} operations", counter);
                }


            }
            else
            {
                int mid = (low + high) / 2;
                if (key == search[mid])//Checks if the value has been found
                {
                    Console.WriteLine("");
                    Console.WriteLine("value {0} found in location {1} ", key, mid);//Prints the value and its location
                    Console.WriteLine("Result found in {0} operations", counter);
                    if (search[mid - 1] == key)
                    {
                       BinarySearch(key, search, low, mid - 1);//Checks for more of the same value in lower sub array
                    }
                    else
                    {
                        BinarySearch(key, search, mid + 1, high);//Checks for more of the same value in higher sub array
                    }
                }
                else if (key < search[mid])
                {
                    BinarySearch(key, search, low, mid - 1);//Searches for value in lower sub array

                }
                else
                {
                    BinarySearch(key, search, mid + 1, high);//Searches fro value in higher sub array
                }
            }
        }
        
        static void InterpolationSearch(int[] search, int high, int key, int low)
        {
            counter++;
            int index = -1;
            if (key > search[high])//Checks if key is outside the bounds of the array
            {
                Console.WriteLine("");
                Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", search[high], high);//Prints closest value
                Console.WriteLine("Result found in {0} operations", counter);
            }
            else if(key < 0)//Checks if key is outside the bounds of the array
            {
                Console.WriteLine("");
                Console.WriteLine("Sub zero values not accepted, the first value in this array is {0}", search[low]);//Prints closest value
                Console.WriteLine("Result found in {0} operations", counter);
            }
            else
            {
                if (low <= high)
                {
                    index = (int)(low + (((int)(high - low) / (search[high] - search[low])) * (key - search[low])));
                    if (search[index] == key)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("value {0} found in location {1} ", key, index);//Prints the value and its location
                        Console.WriteLine("Result found in {0} operations", counter);
                        if (search[index + 1] == key)
                        {

                            InterpolationSearch(search, high, key, index + 1);//Searches for value in lower sub array
                        }
                        else
                        {
                            InterpolationSearch(search, index - 1, key, low);//Searches for value in higher sub array
                        }


                    }
                    else
                    {
                        if (search[index] < key)
                            low = index + 1;//Moves index
                        else
                            high = index - 1;
                        InterpolationSearch(search, high, key, low);//Searches for value in higher sub array
                    }


                }
                if (index == -1)//Checks if value has been found
                {
                    int closest = comp(key, low, high, search);//Finds the closest value
                    if (closest == search[low])
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", closest, low);//Prints closest value
                        Console.WriteLine("Result found in {0} operations", counter);
                    }
                    else if (closest == search[high])
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Value not found/no more values, the nearst value is: {0} in location {1}", closest, high);//Prints closest value
                        Console.WriteLine("Result found in {0} operations", counter);
                    }
                }
            }
        }

        static int[] convertArray(string[] atc)
        {

            int[] intarray = Array.ConvertAll(atc, s => int.Parse(s));//Converts array of strings to array integers

            return intarray;//returns converted array to the program
            
        }


        static void chooseSort(int[] array)
        {
            int len = array.Length;//Gets lenght of the array
            bool ec2 = true;//Used for error checking
            var watch = new System.Diagnostics.Stopwatch();//Sets up a timer to time algorithms 
            while (ec2 == true)
            {
                ec2 = false;
                Console.WriteLine("Choose a sort or algorithm (b = Bubble sort, i = Insertion sort, m = Merge sort, q = Quick sort, s = search algorithms):  ");
                string sortSelect = Console.ReadLine();//Asks user to choose a sort
                if (sortSelect == "s" || sortSelect == "S") ChooseSearch(array, len);//Runs search methods

                else
                {
                    Console.WriteLine("Choose to have the list acending or decending (a = ascending, d = descending)- only applies to sort algorithms: ");
                    string AorD = Console.ReadLine();//Ask user to choose how to display the array

                    if (sortSelect == "b" || sortSelect == "B")
                    {
                        if (AorD == "a" || AorD == "A")
                        {
                            
                            ec2 = false;
                            watch.Start();//Starts timer
                            bubbleSort(array, len, "a");//Runs the bubble sort method
                            watch.Stop();//Snds timer
                        }
                        else if (AorD == "d" || AorD == "D")
                        {

                            ec2 = false;
                            watch.Start();
                            bubbleSort(array, len, "d");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else
                        {
                            ec2 = true;
                        }
                    }
                    else if (sortSelect == "i" || sortSelect == "I")
                    {
                        if (AorD == "a" || AorD == "A")
                        {
                            ec2 = false;
                            watch.Start();
                            insertionSort(array, len, "a");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else if (AorD == "d" || AorD == "D")
                        {
                            ec2 = false;
                            watch.Start();
                            insertionSort(array, len, "d");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else
                        {
                            ec2 = true;
                        }

                    }
                    else if (sortSelect == "m" || sortSelect == "M")
                    {
                        if (AorD == "a" || AorD == "A")
                        {
                            ec2 = false;
                            watch.Start();
                            MergeInitialise(array, len, "a");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else if (AorD == "d" || AorD == "D")
                        {
                            ec2 = false;
                            watch.Start();
                            MergeInitialise(array, len, "d");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else
                        {
                            ec2 = true;
                        }

                    }
                    else if (sortSelect == "q" || sortSelect == "Q")
                    {
                        if (AorD == "a" || AorD == "A")
                        {
                            ec2 = false;
                            watch.Start();
                            QuickSortInitialise(array, len, "a");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else if (AorD == "d" || AorD == "D")
                        {
                            ec2 = false;
                            watch.Start();
                            QuickSortInitialise(array, len, "d");//Runs the bubble sort method
                            watch.Stop();
                        }
                        else
                        {
                            ec2 = true;
                        }

                    }

                    
                    else
                    {
                        ec2 = true;
                        Console.WriteLine("Invalid input.");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("This algorithm was executed in {0} Milliseconds", watch.ElapsedMilliseconds);

                }

            }
            
        }

        static void ChooseSearch(int[] searchArray, int len)
        {
            Console.WriteLine("Choose a search algorithm ( b = Binary search, i = Interpolation search): ");
            string choice = Console.ReadLine();//Asks user to choose a search algorithm
            Console.WriteLine("Enter the number you would like to search: ");
            string searchstr = Console.ReadLine();//Asks user to choose a number to search
            int searchNum = Convert.ToInt32(searchstr);//Asks user to choose a number to search
            bool ec3 = true;//Used for error checking
            var watch2 = new System.Diagnostics.Stopwatch();//Sets up a timer to time algorithms

            while (ec3 == true)
            {

                if(choice == "b" || choice == "B")
                {
                    ec3 = false;
                    searchArray = QuickSortReturn(searchArray, len);//Sorts array
                    counter = 0;
                    watch2.Start();//Starts timer
                    BinarySearch(searchNum, searchArray, 0, len - 1);//Runs binary search
                    watch2.Stop();//Ends timer

                }
                else if(choice == "i" || choice == "I")
                {
                    ec3 = false;
                    searchArray = QuickSortReturn(searchArray, len);//Sorts array
                    counter = 0;
                    watch2.Start();
                    InterpolationSearch(searchArray, len - 1, searchNum, 0);//Runs interpolation search
                    watch2.Stop();

                }

            }
            Console.WriteLine("");
            Console.WriteLine("This algorithm was executed in {0} Milliseconds", watch2.ElapsedMilliseconds);

        }

        static string LenSelect()
        {
            Console.WriteLine("Type which lenght array you want to select( 256, 2048): ");
            string lenSelect = Console.ReadLine();//Saves lenght selection
            return lenSelect;//Returns selection
        }

        static void disTenth(int[] dta, int n)
        {
            List<int> newa = new List<int>();//Creates a list to store 
            int pointCounter = 1;//Creates a counter
            
            

            foreach (int i in dta)//Loops through list
            {
                if (n == 256)//Checks the lenght of the array
                {
                    if (pointCounter == 10)
                    {
                        int value = i;
                        newa.Add(i);//Adds 10th value to the list
                        pointCounter = 1;//resets counter

                    }
                    else
                    {
                        pointCounter++;//increments counter
                    }
                }
                else
                {
                    if (pointCounter == 50)
                    {
                        int value = i;
                        newa.Add(i);//Adds 50th value to the list
                        pointCounter = 1;

                    }
                    else
                    {
                        pointCounter++;
                    }
                }
                
            }
            Console.WriteLine("");
            Console.WriteLine(string.Join(" ", newa));//Outputs list
            Console.WriteLine("This operation was complete in {0} operations", counter);

        }


        static int comp(int key, int comp1, int comp2, int[] Compare)
        {
            if (comp1 < 0)//Checks if value is outside the bounds of the array
            {
                return Compare[comp2];
            }
            if(comp2 < 0)//Checks if value is outside the bounds of the array
            {
               
                return Compare[comp1];
            }

            comp1 = Compare[comp1];
            comp2 = Compare[comp2];//Grabs the values from the array for each nuner
            int Newcomp1;
            int Newcomp2;
            if (comp1 > key)
            {
                  Newcomp1 = comp1 - key;//Get the value diiference between the value and key
            }
            else
            {
                 Newcomp1 = key - comp1;//Get the value diiference between the value and key
            }


            if (comp2 > key)
            {
                Newcomp2 = comp2 - key;
            }
            else
            {
                Newcomp2 = key - comp2;
            }


            if (Newcomp1 > Newcomp2)//Check to see which value is closer to the key
            {
                return comp2;
            }
            else
            {
                return comp1;
            }
        }

        static string[] merge3(string[] a1, string[] a2, string[] a3)
        {
            List<string> merge = new List<string>();//Creates a list to store arrays
            merge.AddRange(a1);
            merge.AddRange(a2);
            merge.AddRange(a3);//Adds arrays to the list
            string[] finalMerge = merge.ToArray();//Coverts list to array
            
            return finalMerge;
        }
    }
}
