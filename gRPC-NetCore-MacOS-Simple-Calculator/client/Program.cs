using System;
using System.Threading.Tasks;
using Calculate;
using Grpc.Net.Client;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("http://127.0.0.1:5000");
            var client =  new Calculator.CalculatorClient(channel);

            var reply1 = await client.AdditionAsync(
                              new CommonRequest { Val1 = 38, Val2 = 96 });
            Console.WriteLine("Addition: " + reply1);

            Calculate.CommonResponse reply2 = await client.SubtractionAsync(
                              new CommonRequest { Val1 = 88, Val2 = 33 });
            Console.WriteLine("Subtraction: " + reply2);

            Calculate.CommonResponse reply3 = await client.MultiplicationAsync(
                              new CommonRequest { Val1 = 77, Val2 = 5 });
            Console.WriteLine("Multiplication: " + reply3);

            Calculate.CommonResponse reply4 = await client.DivisionAsync(
                              new CommonRequest { Val1 = 385, Val2 = 5 });
            Console.WriteLine("Division: " + reply4);
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
