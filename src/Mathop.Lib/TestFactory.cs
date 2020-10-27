namespace Mathop.Lib
{
    using System;
    using System.Linq;

    public class TestFactory
    {
        const int MaxIteration = 1000;

        public static Test CreateSimpleTest()
        {
            var test = new Test();
            test.AddEquation(new Equation(1, 1, null, new Operation(Operation.OperationType.Add)));
            test.AddEquation(new Equation(2, 2, null, new Operation(Operation.OperationType.Add)));
            test.AddEquation(new Equation(4, 4, null, new Operation(Operation.OperationType.Multiply)));
            test.AddEquation(new Equation(12, null, 144, new Operation(Operation.OperationType.Multiply)));
            return test;
        }

        public static Test CreateTest(
            Operation operation,
            int variable1Minimum, int variable1Maximum,
            int variable2Minimum, int variable2Maximum,
            int equationCount)
        {
            var test = new Test();
            var random = new Random();
            for (var i = 0; i < equationCount; i++)
            {
                var variable1 = random.Next(variable1Minimum, variable1Maximum + 1);
                var variable2 = random.Next(variable2Minimum, variable2Maximum + 1);
                test.AddEquation(new Equation(variable1, variable2, null, operation));
            }

            return test;
        }

        public static Test CreateTest2(
            Operation operation,
            int variable1Minimum, int variable1Maximum,
            int variable2Minimum, int variable2Maximum,
            Func<int, int, bool> variableRule,
            int equationCount)
        {
            var test = new Test();
            var random = new Random();
            for (var i = 0; i < equationCount; i++)
            {
                var iteration = 0;
                var variable1 = random.Next(variable1Minimum, variable1Maximum + 1);
                var variable2 = random.Next(variable2Minimum, variable2Maximum + 1);
                while (!variableRule(variable1, variable2) && iteration < MaxIteration)
                {
                    ++iteration;
                    variable1 = random.Next(variable1Minimum, variable1Maximum + 1);
                    variable2 = random.Next(variable2Minimum, variable2Maximum + 1);
                }

                test.AddEquation(new Equation(variable1, variable2, null, operation));
            }

            return test;
        }

        public static Test CreateTest3(
            Operation[] operations,
            int variable1Minimum, int variable1Maximum,
            int variable2Minimum, int variable2Maximum,
            Func<int, int, bool> variableRule,
            int equationCount)
        {
            var test = new Test();
            var random = new Random();
            for (var i = 0; i < equationCount; i++)
            {
                var iteration = 0;
                var variable1 = random.Next(variable1Minimum, variable1Maximum + 1);
                var variable2 = random.Next(variable2Minimum, variable2Maximum + 1);
                while (!variableRule(variable1, variable2) && iteration < MaxIteration)
                {
                    ++iteration;
                    variable1 = random.Next(variable1Minimum, variable1Maximum + 1);
                    variable2 = random.Next(variable2Minimum, variable2Maximum + 1);
                }

                test.AddEquation(new Equation(variable1, variable2, null, operations[random.Next(0, operations.Count())]));
            }

            return test;
        }
    }
}
