namespace Rationals.Extensions
{
    //Nice.
    internal class Math
    {
        internal static int FindGcd(int arg1, int arg2)
        {
            return arg2 == 0 ? arg1 : FindGcd(arg2, arg1%arg2);
        }
    }
}
