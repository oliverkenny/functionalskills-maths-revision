using System;
using SubtractionProgram.Problems;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Subjects
{
	class Subtract : GenericSubject
	{
		public override object GenerateQuestion(Difficulty difficulty)
		{
			SubtractionProblem problem = new SubtractionProblem();
			Random rand = new Random();
			int[] easy = { 1, 15 };
			int[] medium = { 15, 50 };
			int[] hard = { 50, 1000 };

			switch (difficulty)
			{
				case Difficulty.Easy:
					problem.Minuend = rand.Next(easy[0], easy[1]);
					problem.Subtrahend = rand.Next(easy[0], problem.Minuend);
					problem.Difference = problem.Minuend - problem.Subtrahend;
					break;
				case Difficulty.Medium:
					problem.Minuend = rand.Next(medium[0], medium[1]);
					problem.Subtrahend = rand.Next(medium[0], problem.Minuend);
					problem.Difference = problem.Minuend - problem.Subtrahend;
					break;
				case Difficulty.Hard:
					problem.Minuend = rand.Next(hard[0], hard[1]);
					problem.Subtrahend = rand.Next(hard[0], problem.Minuend);
					problem.Difference = problem.Minuend - problem.Subtrahend;
					break;
			}

			switch (rand.Next(2))
			{
				case 0:
					problem.MissingPart = SubtractionProblemPart.Minuend;
					break;
				case 1:
					problem.MissingPart = SubtractionProblemPart.Subtrahend;
					break;
				default:
					throw new Exception("Missing part generated was not valid.");
			}

			return problem;
		}

		public override bool IsCorrect(object problem, int answer)
		{
			SubtractionProblem p = (SubtractionProblem)problem;	

			switch (p.MissingPart)
			{
				case SubtractionProblemPart.Minuend:
					return p.Minuend == answer;
				case SubtractionProblemPart.Subtrahend:
					return p.Subtrahend == answer;
				case SubtractionProblemPart.Difference:
					return p.Difference == answer;
				default:
					return false;
			}
		}
	}
}
