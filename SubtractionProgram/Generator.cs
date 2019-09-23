using SubtractionProgram.Problems;
using System;
using static SubtractionProgram.Enums;

namespace SubtractionProgram
{
	public class Generator
	{
		public Difficulty Difficulty { get; set; }
		public int QuestionCount { get; set; }
		public Subject Subject { get; private set; }

		public Generator(Difficulty difficulty = Difficulty.Medium, int questionCount = 10)
		{
			this.Difficulty = difficulty;
			this.QuestionCount = questionCount;
		}

		public void SetSubject(Subject subject)
		{
			this.Subject = subject;
		}

		public void SetQuestionCount(int qc)
		{
			this.QuestionCount = qc;
		}
	}
}
