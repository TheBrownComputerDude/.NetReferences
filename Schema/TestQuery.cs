namespace backend.Schema
{
    using backend.Dtos;
    using GraphQL.Types;

    public class TestQuery : ObjectGraphType
    {
        public TestQuery()
        {
            this.Field<TestType>(
                "Test",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>
                    {
                        Name = "firstArg",
                        Description = "First query  argument for the test type."
                    }
                ),
                resolve: context => 
                {
                    return new TestDto() {
                        Val1 = 1234,
                        Val2 = "Did this work?"
                    };
                }
            );
        }
    }
}