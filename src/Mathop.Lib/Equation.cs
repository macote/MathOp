namespace Mathop.Lib
{
    using System.Text;

    public class Equation
    {
        public int? Variable1 { get; private set; }
        public int? Variable2 { get; private set; }
        public int? Variable3 { get; private set; }

        public Operation Operation { get; private set; }

        public Equation(int? variable1, int? variable2, int? variable3, Operation operation)
        {
            Variable1 = variable1;
            Variable2 = variable2;
            Variable3 = variable3;
            Operation = operation;
        }

        public bool TrySolve(int value)
        {
            return Operation.Apply(Variable1 ?? value, Variable2 ?? value) == (Variable3 ?? value);
        }

        public int? Solve()
        {
            switch (Operation.Type)
            {
                case Operation.OperationType.Add:
                    if (!Variable3.HasValue)
                    {
                        return Variable1.Value + Variable2.Value;
                    }

                    break;
                case Operation.OperationType.Substract:
                    if (!Variable3.HasValue)
                    {
                        return Variable1.Value - Variable2.Value;
                    }

                    break;
                case Operation.OperationType.Multiply:
                    if (!Variable3.HasValue)
                    {
                        return Variable1.Value * Variable2.Value;
                    }

                    break;
                case Operation.OperationType.Divide:
                    if (!Variable3.HasValue)
                    {
                        return Variable1.Value / Variable2.Value;
                    }

                    break;
                default:
                    break;
            }

            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Variable1.HasValue)
            {
                sb.Append(Variable1.ToString());
            }
            else
            {
                sb.Append("_");
            }

            sb.Append(" " + Operation.ToString() + " ");

            if (Variable2.HasValue)
            {
                sb.Append(Variable2.ToString());
            }
            else
            {
                sb.Append("_");
            }

            sb.Append(" = ");

            if (Variable3.HasValue)
            {
                sb.Append(Variable3.ToString());
            }
            else
            {
                sb.Append("_");
            }

            return sb.ToString();
        }
    }
}
