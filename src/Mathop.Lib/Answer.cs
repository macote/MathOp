namespace Mathop.Lib
{
    public class Answer
    {
        public Equation Equation { get; private set; }
        public int AnswerValue { get; private set; }

        public Answer(Equation equation, int answerValue)
        {
            Equation = equation;
            AnswerValue = answerValue;
        }

        public bool IsCorrect()
        {
            return Equation.TrySolve(AnswerValue);
        }
    }
}
