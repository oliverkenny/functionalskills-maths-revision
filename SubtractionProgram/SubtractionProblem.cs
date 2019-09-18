using static SubtractionProgram.Enums;

namespace SubtractionProgram
{
	public class SubtractionProblem
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }
		public int Difference { get; set; }
		public ProblemPart MissingPart { get; set; }
	}
}
