using static SubtractionProgram.Enums;

namespace SubtractionProgram.Problems
{
	public class SubtractionProblem
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }
		public int Difference { get; set; }
		public SubtractionProblemPart MissingPart { get; set; }
	}
}
