using System;
using System.Collections.Generic;
using System.Linq;

namespace SubtractionProgram
{
	public class Enums
	{
		public enum Difficulty
		{
			Easy,
			Medium,
			Hard
		}

		public enum ProblemPart
		{
			Minuend,
			Subtrahend,
			Difference
		}

		public enum Subject
		{
			Subtraction,
			//Percentages
		}

		public static List<T> EnumToList<T>()
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("Type must be an enum.");
			}
			return Enum.GetValues(typeof(T)).OfType<T>().ToList();
		}
	}
}
