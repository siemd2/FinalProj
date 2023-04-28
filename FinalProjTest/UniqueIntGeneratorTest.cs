using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProj.Data.Controllers;

namespace FinalProjTest
{
	[TestFixture]
	public class UniqueIntGeneratorTests
	{
		private string _filePath;

		[SetUp]
		public void SetUp()
		{
			// Get the file path for test unique IDs storage
		_filePath = @"C:\Users\siem3\OneDrive\Desktop\FinalProj\FinalProj\Resources\Assets\TestUniqueIDs.txt";
			UniqueIntGenerator.FilePath = _filePath;

			// Ensure the test file is empty before each test
			File.WriteAllText(_filePath, string.Empty);
		}

		[Test]
		public void GenerateUniqueInt_GeneratesUniqueIntegers()
		{
			// Arrange
			var uniqueId1 = UniqueIntGenerator.GenerateUniqueInt();
			var uniqueId2 = UniqueIntGenerator.GenerateUniqueInt();

			// Act
			bool areUnique = uniqueId1 != uniqueId2;

			// Assert
			Assert.IsTrue(areUnique);
		}

		[Test]
		public void GenerateUniqueInt_PersistsIntegersToDisk()
		{
			// Arrange
			var uniqueId1 = UniqueIntGenerator.GenerateUniqueInt();
			var uniqueId2 = UniqueIntGenerator.GenerateUniqueInt();

			// Act
			var savedIntegers = File.ReadAllLines(_filePath);

			// Assert
			Assert.Contains(uniqueId1.ToString(), savedIntegers);
			Assert.Contains(uniqueId2.ToString(), savedIntegers);
		}

		[Test]
		public void LoadHashSet_RetrievesSavedIntegers()
		{
			// Arrange
			var uniqueId1 = UniqueIntGenerator.GenerateUniqueInt();
			var uniqueId2 = UniqueIntGenerator.GenerateUniqueInt();

			// Act
			UniqueIntGenerator.LoadHashSet();

			// Assert
			Assert.IsTrue(UniqueIntGenerator.UniqueIntegers.Contains(uniqueId1));
			Assert.IsTrue(UniqueIntGenerator.UniqueIntegers.Contains(uniqueId2));
		}
	}
}
