using ModelValidation.Models;
using static ModelValidation.Models.Models;

namespace ModelValidation
{
    public class Program
    {
        record Some
        {
            public string Value { get; }

            private Some(string value)
            {
                Value = value;
            }

            public static Some From(string value) 
            {
                return new Some(value);
            }


            //protected SomeList(SomeList original)
            //{
            //    length = original.length;
            //    list = new List<string>(original.list);
            //}
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                       

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}