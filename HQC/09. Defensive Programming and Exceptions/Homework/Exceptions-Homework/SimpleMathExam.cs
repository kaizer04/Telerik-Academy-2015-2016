using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Problems solved can not be less than 0!");
            }

            // Check method shows that you can only have solved 0 1 or 2 problems
            if (value > 2)
            {
                throw new ArgumentException("Problems solved can not be more than 2!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult examResultToReturn = null;

        switch (this.ProblemsSolved)
        {
            case 0: examResultToReturn = new ExamResult(2, 2, 6, "Bad result: nothing done.");
                break;
            case 1: examResultToReturn = new ExamResult(4, 2, 6, "Average result: half done.");
                break;
            case 2: examResultToReturn = new ExamResult(6, 2, 6, "Excellent result: everything done.");
                break;
            default: break;
        }

        return examResultToReturn;
    }
}
