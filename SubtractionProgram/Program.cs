using SubtractionProgram.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using static SubtractionProgram.Enums;

namespace SubtractionProgram
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Subtraction Program!");

			Generator generator = new Generator();
			var play = true;
			while (play)
			{
				SetSubject(generator);
				SetDifficulty(generator);
				SetQuestionCount(generator);
				switch (generator.Subject) {
					case Subject.Subtraction:
						AskSubtractionQuestions(generator);
						break;
					default:
						throw new ArgumentOutOfRangeException(paramName: nameof(generator.Subject), message:"Subject is not valid.");
				}
				play = GetPlayAgain();
			}

			Console.WriteLine("\nThank you for using the Subtraction Program!\n" +
							  "Press any key to exit...");
			Console.ReadKey();
		}

		public static void SetSubject(Generator generator)
		{
			var chosenSubject = false;
			while (!chosenSubject)
			{
				List<Subject> subjects = EnumExtensions.SubjectToList();
				Console.Write("Please select a subject:\n");
				for (int i = 0; i < subjects.Count(); i++)
				{
					Console.WriteLine($"[{i + 1}] {subjects.ElementAt(i).ToString()}");
				}
				Console.Write("Selection: ");
				try {
					var selection = Convert.ToInt32(Console.ReadLine());
					if (selection < 1 || selection > subjects.Count()) {
						throw new ArgumentOutOfRangeException(paramName: nameof(selection), message: "The option you selected doesn't exist. Please try again.");
					}
					generator.SetSubject(subjects.ElementAt(selection-1));
					chosenSubject = true;
				} catch (FormatException) {
					Console.WriteLine("The value you entered was invalid.");
				} catch (ArgumentOutOfRangeException aore) {
					Console.WriteLine(aore.Message);
				}
			}
			Console.WriteLine($"You have chosen to practice {generator.Subject.ToString().ToLower()}.\n");
		}

		public static void SetDifficulty(Generator generator)
		{
			var chosenDifficulty = false;
			while (!chosenDifficulty)
			{
				Console.Write("Difficulty [Easy=1, Medium=2, Hard=3]: ");
				var intDifficulty = Console.ReadLine();

				switch (intDifficulty)
				{
					case "1":
						generator.Difficulty = Difficulty.Easy;
						chosenDifficulty = true;
						break;
					case "2":
						generator.Difficulty = Difficulty.Medium;
						chosenDifficulty = true;
						break;
					case "3":
						generator.Difficulty = Difficulty.Hard;
						chosenDifficulty = true;
						break;
					default:
						Console.WriteLine($"{intDifficulty} is not a valid difficulty, please enter either 1, 2, or 3.");
						break;
				}
			}
			Console.WriteLine($"You chose {generator.Difficulty.ToString().ToLower()} difficulty.\n");
		}

		public static void SetQuestionCount(Generator generator)
		{
			Console.Write($"The default question count is {generator.QuestionCount}, would you like to change this? [Yes=Y, No=N]: ");
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
						generator.SetQuestionCount(questionCount);
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

				Console.WriteLine($"Question count is now set to {generator.QuestionCount}.\n");
			}
		}

		public static void AskSubtractionQuestions(Generator generator)
		{
			var questionCount = generator.QuestionCount;
			var currentQuestion = 1;

			while (currentQuestion <= questionCount)
			{
				SubtractionProblem p = generator.GetNewProblem();
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
						isCorrect = generator.IsCorrect(p, answer);
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

		public static void PrintQuestion(SubtractionProblem p, int questionNumber)
		{
			switch (p.MissingPart)
			{
				case ProblemPart.Minuend:
					Console.WriteLine($"({questionNumber}). _ - {p.Subtrahend} = {p.Difference}");
					break;
				case ProblemPart.Subtrahend:
					Console.WriteLine($"({questionNumber}). {p.Minuend} - _ = {p.Difference}");
					break;
				default:
					throw new ArgumentOutOfRangeException(paramName: nameof(p.MissingPart), message: "Error printing question.");
			}
		}
	}
}
