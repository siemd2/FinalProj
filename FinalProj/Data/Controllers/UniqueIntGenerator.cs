using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Data.Controllers
{

	/*
	SUMMARY:
	The UniqueIntGenerator class is created to generate random unique integers of a length=5 which will be used in various parts of the program. 
	The class saves a list of all previously generated IDs and ensures that any newly generated integer is not a duplicate. 
	The class uses a HashSet to store the previously generated integers and saves the list to a text file on disk whenever a new integer is generated. 
	The class also loads the list from the text file when the program starts up, ensuring previously generated integers persist when the program exits.
	*/
	internal class UniqueIntGenerator
	{
		// declare new random, new hashset, min and max values, and filepath for txt storage
		private static readonly Random Random = new Random();
		private static readonly HashSet<int> UniqueIntegers = new HashSet<int>();
		private const int MinValue = 10000;
		private const int MaxValue = 100000;
		private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Data\\UniqueIDs.txt");

		// populate the HashSet with any previously generated id's from txt storage
		static UniqueIntGenerator()
		{
			LoadHashSet();
		}

		// Generate a unique integer and add it to the HashSet
		public static int GenerateUniqueInt()
		{
			int uniqueInt;

			do
			{
				uniqueInt = Random.Next(MinValue, MaxValue);
			}
			while (!UniqueIntegers.Add(uniqueInt));

			SaveHashSet();
			return uniqueInt;
		}

		// Load integers from the text file into the HashSet
		private static void LoadHashSet()
		{
			// Read the text file and populate the HashSet with the integers
			string[] lines = File.ReadAllLines(FilePath);
			foreach (string line in lines)
			{
				if (int.TryParse(line, out int id))
				{
					UniqueIntegers.Add(id);
				}
			}
		}

		// Save unique integers from the HashSet to the text file
		private static void SaveHashSet()
		{
			File.WriteAllLines(FilePath, UniqueIntegers.ToStringArray());
		}
	}

	// Extension method for converting HashSet<int> to a string array
	public static class HashSetExtensions
	{
		public static string[] ToStringArray(this HashSet<int> hashSet)
		{
			string[] result = new string[hashSet.Count];
			int index = 0;
			foreach (int value in hashSet)
			{
				result[index++] = value.ToString();
			}
			return result;
		}
	}
}
