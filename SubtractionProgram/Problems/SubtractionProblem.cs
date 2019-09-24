using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Problems
{
	public class SubtractionProblem
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }
		public int Difference { get; set; }
		public ProblemPart MissingPart { get; set; }

		public void PrintQuestion(int questionNumber)
		{
			switch (this.MissingPart)
			{
				case ProblemPart.Minuend:
					Console.WriteLine($"({questionNumber}) _ - {this.Subtrahend} = {this.Difference}");
					break;
				case ProblemPart.Subtrahend:
					Console.WriteLine($"({questionNumber}) {this.Minuend} - _ = {this.Difference}");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(this.MissingPart), message: $"Missing Part is '{this.MissingPart}'.");
			}
		}
	}
}
