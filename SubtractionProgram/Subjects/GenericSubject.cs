using SubtractionProgram.Problems;
using static SubtractionProgram.Enums;

namespace SubtractionProgram.Subjects
{
	public abstract class GenericSubject
	{
		public abstract object GenerateQuestion(Difficulty difficulty);
		public abstract bool IsCorrect(SubtractionProblem problem, int answer);
	}
}
