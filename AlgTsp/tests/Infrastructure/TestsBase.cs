namespace tests.Infrastructure
{
    public class TestsBase
    {
        public TestsBase()
        {
            this.Container = new Container();
        }

        protected Container Container { private set; get; }
    }
}
