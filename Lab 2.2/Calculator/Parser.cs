﻿using System.Text.RegularExpressions;

namespace Calculator
{
    internal static class Parser
    {
        //Regex, cool!
        private const string Pattern = @"\s*\(?\s*([-+]?\d+\.?\d*)\s*\)?\s*([-+*/])\s*\(?\s*([-+]?\d+\.?\d*)\s*\)?\s*";

        //I don't like the static method and class in this class. It would be better to create an interface and a class for this
        internal static bool TryParseExpression(string expression, out double leftOperand, out double rightOperand, out char @operator)
        {
            var match = Regex.Match(expression, Pattern);
            var leftOperandIsParsed = double.TryParse(match.Groups[1].Value, out leftOperand);
            var rightOperandIsParsed = double.TryParse(match.Groups[3].Value, out rightOperand);
            var operatorIsParsed = char.TryParse(match.Groups[2].Value, out @operator);
            return leftOperandIsParsed & rightOperandIsParsed & operatorIsParsed;
        }
    }
}
