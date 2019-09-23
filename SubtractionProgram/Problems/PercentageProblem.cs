using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Problems
{
	public class PercentageProblem
	{
		public int Amount { get; set; }
		public int Percent { get; set; }
		public int Base { get; set; }
		public PercentageProblemPart MissingPart { get; set; }

		public void PrintQuestion(int questionNumber)
		{
			switch (this.MissingPart)
			{
				case PercentageProblemPart.Amount:
					Console.WriteLine($"({questionNumber}) _ is {this.Percent}% of {this.Base}");
					break;
				case PercentageProblemPart.Percent:
					Console.WriteLine($"({questionNumber}) {this.Amount} is _% of {this.Base}");
					break;
				case PercentageProblemPart.Base:
					Console.WriteLine($"({questionNumber}) {this.Amount} is {this.Percent}% of _");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(this.MissingPart), message: "Error printing question.");
			}
		}
	}
}
