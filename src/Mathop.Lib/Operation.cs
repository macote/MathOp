namespace Mathop.Lib
{
    using System;

    public class Operation
    {
        public enum OperationType
        {
            Add,
            Substract,
            Multiply,
            Divide
        }

        public OperationType Type { get; private set; }

        public Operation(OperationType type)
        {
            Type = type;
        }

        public int Apply(int variable1, int variable2)
        {
            switch (Type)
            {
                case OperationType.Add:
                    return variable1 + variable2;
                case OperationType.Substract:
                    return variable1 - variable2;
                case OperationType.Multiply:
                    return variable1 * variable2;
                case OperationType.Divide:
                    return variable1 / variable2;
                default:
                    throw new ApplicationException("Operation not defined.");
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case OperationType.Add:
                    return "+";
                case OperationType.Substract:
                    return "-";
                case OperationType.Multiply:
                    return "x";
                case OperationType.Divide:
                    return "÷";
                default:
                    throw new ApplicationException("Operation not defined.");
            }
        }
    }
}
