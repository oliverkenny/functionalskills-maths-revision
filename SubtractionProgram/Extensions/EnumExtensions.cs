using System;
using System.Collections.Generic;
using System.Linq;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Extensions
{
	public static class EnumExtensions
	{
		public static List<Subject> SubjectToList()
		{
			return Enum.GetValues(typeof(Subject)).OfType<Subject>().ToList();
		}
	}
}
