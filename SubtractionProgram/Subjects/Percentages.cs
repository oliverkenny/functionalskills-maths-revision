using System;
using SubtractionProgram.Problems;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Subjects
{
	public class Percentages : GenericSubject
	{
		public override object GenerateQuestion(Difficulty difficulty)
		{
			PercentageProblem problem = new PercentageProblem();
			Random rand = new Random();

			problem.Base = rand.Next(1, 10) * 10;
			problem.Percent = rand.Next(1, 10) * 10;
			problem.Amount = Percentage(problem.Percent, problem.Base);

			switch (rand.Next(3))
			{
				case 0:
					problem.MissingPart = PercentageProblemPart.Amount;
					break;
				case 1:
					problem.MissingPart = PercentageProblemPart.Percent;
					break;
				case 2:
					problem.MissingPart = PercentageProblemPart.Base;
					break;
				default:
					throw new Exception("Missing part generated was not valid.");
			}

			return problem;
		}

		public override bool IsCorrect(object problem, int answer)
		{
			PercentageProblem p = (PercentageProblem)problem;

			switch (p.MissingPart)
			{
				case PercentageProblemPart.Amount:
					return p.Amount == answer;
				case PercentageProblemPart.Percent:
					return p.Percent == answer;
				case PercentageProblemPart.Base:
					return p.Base == answer;
				default:
					return false;
			}
		}

		private int Percentage(int percentage, int @base) =>  (int)(@base* ((double)percentage / 100));
	}
}
