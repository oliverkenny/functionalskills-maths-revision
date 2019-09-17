using System;

namespace SubtractionProgram
{
	class Program
	{
		public static Generator Generator { get; set; }

		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Subtraction Program!");

			var play = true;
			while (play)
			{
				SetDifficulty();
				SetQuestionCount();
				AskQuestions();
				play = GetPlayAgain();
			}

			Console.WriteLine("Thank you for using the Subtraction Program!");
		}

		public static void SetDifficulty()
		{
			var chosenDifficulty = false;
			while (!chosenDifficulty)
			{
				Console.Write("Difficulty [Easy=1, Medium=2, Hard=3]: ");
				var intDifficulty = Console.ReadLine();

				switch (intDifficulty)
				{
					case "1":
						Generator = new Generator(Difficulty.Easy);
						chosenDifficulty = true;
						break;
					case "2":
						Generator = new Generator(Difficulty.Medium);
						chosenDifficulty = true;
						break;
					case "3":
						Generator = new Generator(Difficulty.Hard);
						chosenDifficulty = true;
						break;
					default:
						Console.WriteLine($"{intDifficulty} is not a valid difficulty, please enter either 1, 2, or 3.");
						break;
				}
			}
			Console.WriteLine($"You chose {Generator.Difficulty.ToString().ToLower()} difficulty.\n");
		}

		public static void SetQuestionCount()
		{
			Console.Write($"The default question count is {Generator.QuestionCount}, would you like to change this? [Yes=Y, No=N]: ");
			var changeQuestionCount = Console.ReadLine();
			if (changeQuestionCount.ToLower() == "y" || changeQuestionCount.ToLower() == "yes")
			{
				var hasChangedQuestionCount = false;
				while (!hasChangedQuestionCount)
				{
					Console.Write("New question count [Min 1, Max 99]: ");
					var tempQuestionCount = Console.ReadLine();
					try
					{
						var questionCount = Convert.ToInt32(tempQuestionCount);
						if (questionCount < 1 || questionCount > 99)
						{
							throw new ArgumentOutOfRangeException(paramName: nameof(questionCount), message: "Your question count was not within 1 and 99. Please try again.");
						}
						Generator.SetQuestionCount(questionCount);
						hasChangedQuestionCount = true;
					}
					catch (FormatException ice)
					{
						Console.WriteLine("The value you entered was invalid. Please try again.");
					}
					catch (ArgumentOutOfRangeException aore)
					{
						Console.WriteLine(aore.Message);
					}
				}

				Console.WriteLine($"Question count is now set to {Generator.QuestionCount}.\n");
			}
		}

		public static void AskQuestions()
		{
			var questionCount = Generator.QuestionCount;
			var currentQuestion = 1;

			while (currentQuestion <= questionCount)
			{
				Problem p = Generator.GetNewProblem();
				var isCorrect = false;
				while (!isCorrect)
				{
					// Ask question
					PrintQuestion(p, currentQuestion);

					// Get answer
					Console.Write("Answer: ");
					int answer = 0;
					bool validAnswer = true;
					try
					{
						answer = Convert.ToInt32(Console.ReadLine());
					}
					catch (Exception)
					{
						validAnswer = false;
					}

					// Work out if answer is correct
					if (validAnswer)
					{
						isCorrect = Generator.IsCorrect(p, answer);
						Console.WriteLine(isCorrect ? "Correct!" : "Not quite right. Try again.");
					}
				}

				currentQuestion++;
			}
		}

		public static bool GetPlayAgain()
		{
			Console.Write("Would you like to play again? [Yes=Y, No=N]: ");
			var playAgain = Console.ReadLine();
			if (playAgain.ToLower() == "yes" || playAgain.ToLower() == "y") return true;
			return false;
		}

		public static void PrintQuestion(Problem p, int questionNumber)
		{
			switch (p.MissingPart)
			{
				case ProblemPart.Minuend:
					Console.WriteLine($"({questionNumber}). _ - {p.Subtrahend} = {p.Difference}");
					break;
				case ProblemPart.Subtrahend:
					Console.WriteLine($"({questionNumber}). {p.Minuend} - _ = {p.Difference}");
					break;
				case ProblemPart.Difference:
					Console.WriteLine($"({questionNumber}). {p.Minuend} - {p.Subtrahend} = _");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(p.MissingPart), message: "Error printing question.");
			}
		}
	}

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
				case 2:
					problem.MissingPart = ProblemPart.Difference;
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

	public class Problem
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }
		public int Difference { get; set; }
		public ProblemPart MissingPart { get; set; }
	}

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
}
