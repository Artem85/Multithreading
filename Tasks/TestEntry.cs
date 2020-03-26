using System;

namespace Tasks
{
    public class TestEntry
    {
        static void Main(string[] args)
        {
            int a = 8;
            int b = 17;

            A.Test(a, b);
            B.Test(a, b);
            C.Test(a, b);
            D.Test();
            E.Test();
            F.Test();
            G.Test();
        }
    }
}
