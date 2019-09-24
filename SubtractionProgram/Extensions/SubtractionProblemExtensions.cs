using SubtractionProgram.Problems;
using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Extensions
{
	public static class SubtractionProblemExtensions
	{
		public static void PrintQuestion(this SubtractionProblem sp, int questionNumber)
		{
			switch (sp.MissingPart)
			{
				case ProblemPart.Minuend:
					Console.WriteLine($"({questionNumber}) _ - {sp.Subtrahend} = {sp.Difference}");
					break;
				case ProblemPart.Subtrahend:
					Console.WriteLine($"({questionNumber}) {sp.Minuend} - _ = {sp.Difference}");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(sp.MissingPart), message: $"Missing Part is '{sp.MissingPart}'.");
			}
		}
	}
}
