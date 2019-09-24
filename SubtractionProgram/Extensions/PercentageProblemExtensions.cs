using SubtractionProgram.Problems;
using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Extensions
{
	public static class PercentageProblemExtensions
	{
		public static void PrintQuestion(this PercentageProblem pp, int questionNumber)
		{
			switch (pp.MissingPart)
			{
				case PercentageProblemPart.Amount:
					Console.WriteLine($"({questionNumber}) _ is {pp.Percent}% of {pp.Base}");
					break;
				case PercentageProblemPart.Percent:
					Console.WriteLine($"({questionNumber}) {pp.Amount} is _% of {pp.Base}");
					break;
				case PercentageProblemPart.Base:
					Console.WriteLine($"({questionNumber}) {pp.Amount} is {pp.Percent}% of _");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(pp.MissingPart), message: $"Missing Part is '{pp.MissingPart}'.");
			}
		}
	}
}
