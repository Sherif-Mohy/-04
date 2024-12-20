using System;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {

		#region 1
		static void ChangeValue(int x)
		{
			x = 10; // Changes only the local copy
		}

		static void ChangeReference(ref int x)
		{
			x = 10; // Changes the actual variable
		}

		#endregion

		#region 2
		static void ChangeContent(Person p)
		{
			p.Name = "John"; // Changes the content of the object
		}

		static void ChangeReference(ref Person p)
		{
			p = new Person() { Name = "Doe" }; // Changes the reference
		}

		//I have searched for it
		class Person
		{
			public string Name { get; set; }
		}
		#endregion

		#region 3
		static void Calculate(int a, int b, int c, int d, out int summation, out int subtraction)
		{
			summation = a + b + c + d;
			subtraction = a - b - c - d;
		}
		#endregion

		#region 4
		static int SumOfDigits(int number)
		{
			int sum = 0;
			while (number > 0)
			{
				sum += number % 10;
				number /= 10;
			}
			return sum;
		}
		#endregion

		#region 5
		static bool IsPrime(int number)
		{
			if (number <= 1) return false;
			for (int i = 2; i <= Math.Sqrt(number); i++)
				if (number % i == 0) return false;
			return true;
		}
		#endregion

		#region 6
		static void MinMaxArray(int[] array, out int min, out int max)
		{
			min = array[0];
			max = array[0];
			foreach (var num in array)
			{
				if (num < min) min = num;
				if (num > max) max = num;
			}
		}
		#endregion

		#region 7
		static int Factorial(int number)
		{
			int result = 1;
			for (int i = 1; i <= number; i++)
				result *= i;
			return result;
		}
		#endregion

		#region 8
		static string ChangeChar(string str, int position, char newChar)
		{
			char[] chars = str.ToCharArray();
			chars[position] = newChar;
			return new string(chars);
		}
		#endregion

		#region 9
		static void PrintIdentityMatrix(int size)
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
					Console.Write(i == j ? "1 " : "0 ");
				Console.WriteLine();
			}
		}
		#endregion

		#region 10
		static int SumOfArray(int[] array)
		{
			int sum = 0;
			foreach (var num in array)
				sum += num;
			return sum;
		}
		#endregion

		#region 11
		public static void MergeSortedArrays(int[] arr1, int[] arr2, int[] result)
		{
			int i = 0, j = 0, k = 0;
			while (i < arr1.Length && j < arr2.Length)
			{
				if (arr1[i] < arr2[j])
					result[k++] = arr1[i++];
				else
					result[k++] = arr2[j++];
			}

			while (i < arr1.Length)
				result[k++] = arr1[i++];

			while (j < arr2.Length)
				result[k++] = arr2[j++];
		}
		#endregion

		#region 12
		public static void CountFrequency(int[] arr)
		{
			int[] frequency = new int[50];

			foreach (var num in arr)
			{
				frequency[num]++;
			}

			for (int i = 0; i < frequency.Length; i++)
			{
				if (frequency[i] > 0)
				{
					Console.WriteLine($"Element {i} occurs {frequency[i]} times");
				}
			}
		}
		#endregion

		#region 13
		public static void FindMaxMin(int[] arr, out int max, out int min)
		{
			max = arr[0];
			min = arr[0];

			foreach (var num in arr)
			{
				if (num > max)
					max = num;
				if (num < min)
					min = num;
			}
		}
		#endregion

		#region 14
		public static int FindSecondLargest(int[] arr)
		{
			int max1 = int.MinValue, max2 = int.MinValue;

			foreach (var num in arr)
			{
				if (num > max1)
				{
					max2 = max1;
					max1 = num;
				}
				else if (num > max2 && num != max1)
					max2 = num;
			}

			return max2;
		}
		#endregion

		#region 15
		public static int FindLongestDistance(int[] arr)
		{
			var map = new Dictionary<int, int>();
			int maxDistance = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				if (map.ContainsKey(arr[i]))
				{
					maxDistance = Math.Max(maxDistance, i - map[arr[i]]);
				}
				else
				{
					map[arr[i]] = i;
				}
			}

			return maxDistance;
		}
		#endregion

		#region 17
		public static string ReverseWords(string sentence)
		{
			string[] words = sentence.Split(' ');
			string reversedSentence = "";

			for (int i = words.Length - 1; i >= 0; i--)
			{
				if (!string.IsNullOrEmpty(words[i]))
				{
					if (reversedSentence.Length > 0)
					{
						reversedSentence += " ";
					}
					reversedSentence += words[i];
				}
			}

			return reversedSentence;
		}
		#endregion

		#region 18
		public static void CopyAndPrintArray(int[,] source, int[,] destination)
		{
			for (int i = 0; i < source.GetLength(0); i++)
			{
				for (int j = 0; j < source.GetLength(1); j++)
				{
					destination[i, j] = source[i, j];
				}
			}

			for (int i = 0; i < destination.GetLength(0); i++)
			{
				for (int j = 0; j < destination.GetLength(1); j++)
				{
					Console.Write(destination[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
		#endregion

		#region 19
		public static void PrintArrayInReverse(int[] arr)
		{
			for (int i = arr.Length - 1; i >= 0; i--)
			{
				Console.Write(arr[i] + " ");
			}
		}
		#endregion

		static void Main(string[] args)
		{
			#region 1
			//When passing by value, a copy of the variable is passed to the function.
			//When passing by reference, the function works with the original variable.

			int a = 5;
			ChangeValue(a);
			Console.WriteLine(a); // Output: 5

			ChangeReference(ref a);
			Console.WriteLine(a); // Output: 10
			#endregion

			#region 2
			//Passing reference type by value allows modifying the object’s content but not its reference.
			//Passing reference type by reference allows modifying both.
			Person person = new Person { Name = "Alice" };
			ChangeContent(person);
			Console.WriteLine(person.Name); // Output: John

			ChangeReference(ref person);
			Console.WriteLine(person.Name); // Output: Doe
			#endregion

			#region 3
			// Input 4 numbers from the user
			Console.Write("Enter first number: ");
			int num1 = int.Parse(Console.ReadLine());

			Console.Write("Enter second number: ");
			int num2 = int.Parse(Console.ReadLine());

			Console.Write("Enter third number: ");
			int num3 = int.Parse(Console.ReadLine());

			Console.Write("Enter fourth number: ");
			int num4 = int.Parse(Console.ReadLine());

			// Call the Calculate method
			Calculate(num1, num2, num3, num4, out int sum, out int sub);

			// Display the results
			Console.WriteLine($"Summation: {sum}");
			Console.WriteLine($"Subtraction: {sub}");
			#endregion

			#region 4
			Console.WriteLine(SumOfDigits(23));
			#endregion

			#region 5
			IsPrime(13);
			#endregion

			#region 6
			int[] numbers = { 5, 2, 8, 1, 9 };
			MinMaxArray(numbers, out int minValue, out int maxValue);
			Console.WriteLine($"Minimum: {minValue}, Maximum: {maxValue}");
			#endregion

			#region 7
			Console.Write("Enter a number to calculate factorial: ");
			int number = int.Parse(Console.ReadLine());
			int fact = Factorial(number);
			Console.WriteLine($"Factorial of {number} is: {fact}");
			#endregion

			#region 8
			Console.Write("Enter a string: ");
			string inputStr = Console.ReadLine();
			Console.Write("Enter the position to change (0-based index): ");
			int pos = int.Parse(Console.ReadLine());
			Console.Write("Enter the new character: ");
			char newChar = Console.ReadKey().KeyChar;

			string updatedStr = ChangeChar(inputStr, pos, newChar);
			Console.WriteLine($"\nUpdated String: {updatedStr}");
			#endregion

			#region 9
			Console.Write("Enter the size of the identity matrix: ");
			int matrixSize = int.Parse(Console.ReadLine());
			PrintIdentityMatrix(matrixSize);
			#endregion

			#region 10
			int[] array = { 3, 6, 9, 12, 15 };
			int arraySum = SumOfArray(array);
			Console.WriteLine($"Sum of array elements: {arraySum}");
			#endregion

			#region 11
			int[] arr1 = { 1, 3, 5, 7 };
			int[] arr2 = { 2, 4, 6, 8 };
			int[] result = new int[arr1.Length + arr2.Length];

			MergeSortedArrays(arr1, arr2, result);

			Console.WriteLine("Merged Array: " + string.Join(", ", result));
			#endregion

			#region 12
			int[] arr = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
			CountFrequency(arr);
			#endregion

			#region 13
			int[] arrr = { 3, 5, 7, 2, 8, -1, 4 };
			FindMaxMin(arrr, out int max, out int min);

			Console.WriteLine($"Max: {max}, Min: {min}");
			#endregion

			#region 14
			int[] arrrr = { 3, 5, 7, 2, 8, 7, 9 };
			int secondLargest = FindSecondLargest(arr);

			Console.WriteLine($"Second Largest: {secondLargest}");
			#endregion

			#region 15
			int[] a_rr = { 7, 0, 0, 0, 0, 5, 6, 7, 5, 0, 7, 5, 3 };
			int longestDistance = FindLongestDistance(a_rr);

			Console.WriteLine($"Longest Distance: {longestDistance}");
			#endregion

			#region 17
			string sentence = "this is a test";
			string reversedSentence = ReverseWords(sentence);

			Console.WriteLine(reversedSentence);
			#endregion

			#region 18
			int[,] array1 = new int[2, 2];
			int[,] array2 = new int[2, 2];

			Console.WriteLine("Enter values for the first array:");
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					Console.Write($"Element [{i},{j}]: ");
					array1[i, j] = int.Parse(Console.ReadLine());
				}
			}

			CopyAndPrintArray(array1, array2);
			#endregion

			#region 19
			int[] aarr = { 1, 2, 3, 4, 5 };
			PrintArrayInReverse(aarr);
			#endregion

		}
	}
}
