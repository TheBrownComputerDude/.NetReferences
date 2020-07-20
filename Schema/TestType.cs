namespace backend.Schema
{
    using backend.Dtos;
    using GraphQL.Types;

    public class TestType : ObjectGraphType<TestDto>
    {
       public TestType()
       {
           this.Name = "My test type";

           this.Field(t => t.Val1).Description("The first value.");
           this.Field(t => t.Val2).Description("The second value.");
       } 
    }
}