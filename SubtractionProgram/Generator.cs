using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram
{
	public class Generator
	{
		public Difficulty Difficulty { get; set; }
		public int QuestionCount { get; set; }

		public Generator(Difficulty difficulty = Difficulty.Medium, int questionCount = 10)
		{
			this.Difficulty = difficulty;
			this.QuestionCount = questionCount;
		}

		public void SetQuestionCount(int qc)
		{
			this.QuestionCount = qc;
		}

		public Problem GetNewProblem()
		{
			Problem problem = new Problem();
			Random rand = new Random();
			int[] easy = { 1, 15 };
			int[] medium = { 15, 50 };
			int[] hard = { 50, 1000 };

			switch (Difficulty)
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
					problem.MissingPart = ProblemPart.Minuend;
					break;
				case 1:
					problem.MissingPart = ProblemPart.Subtrahend;
					break;
				default:
					throw new Exception("Missing part generated was not valid.");
			}

			return problem;
		}

		public bool IsCorrect(Problem p, int answer)
		{
			switch (p.MissingPart)
			{
				case ProblemPart.Minuend:
					return p.Minuend == answer;
				case ProblemPart.Subtrahend:
					return p.Subtrahend == answer;
				case ProblemPart.Difference:
					return p.Difference == answer;
				default:
					return false;
			}
		}
	}
}
