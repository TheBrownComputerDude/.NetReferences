namespace backend.Test
{
    public class Test : ITest
    {
        public Test(string s) {
            this.x = 12321;
            this.s = s;
        }
        public int x { get; set; }

        public string s { get; set; }
    }
}