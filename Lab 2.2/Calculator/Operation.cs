using System;

namespace Calculator
{
    //Nice idea
    internal class Operation
    {
        private double LeftOperand { get; }
        private double RightOperand { get; }
        private char Operator { get; }
        private double Result { get; set; }
        private bool Valid { get; set; }

        internal Operation()
        {
            Valid = false;
        }

        internal Operation(string expression)
        {
            double leftOperand;
            double rightOperand;
            char @operator;
            Valid = Parser.TryParseExpression(expression, out leftOperand, out rightOperand, out @operator);
            if (!Valid)
            {
                return;
            }
            if (Math.Abs(leftOperand) >= double.Epsilon && Math.Abs(rightOperand) < double.Epsilon && @operator == '/')
            {
                IO.WriteDivideByZero();
                Valid = false;
                return;
            }
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operator = @operator;
        }

        internal bool IsValid()
        {
            return Valid;
        }

        internal double Calculate()
        {
            switch (Operator)
            {
                case '+':
                    Result = LeftOperand + RightOperand;
                    break;
                case '-':
                    Result = LeftOperand - RightOperand;
                    break;
                case '*':
                    Result = LeftOperand*RightOperand;
                    break;
                case '/':
                    Result = Math.Abs(RightOperand) >= double.Epsilon ? LeftOperand/RightOperand : 0;
                    break;
            }
            if (!double.IsInfinity(Result))
            {
                return Result;
            }
            IO.WriteLimitsViolation();
            Valid = false;
            return 0;
        }
    }
}
