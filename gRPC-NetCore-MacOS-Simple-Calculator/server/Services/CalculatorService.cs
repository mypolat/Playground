using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Calculate;

namespace server
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        public override Task<CommonResponse> Addition(CommonRequest request, ServerCallContext context)
        {
            _logger.LogDebug("girdi");
            return Task.FromResult(new CommonResponse
            {
                Result = request.Val1 + request.Val2
            });
        }
        
        public override Task<CommonResponse> Subtraction(CommonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CommonResponse
            {
                Result = request.Val1 - request.Val2
            });
        }

        public override Task<CommonResponse> Multiplication(CommonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CommonResponse
            {
                Result = request.Val1 * request.Val2
            });
        }

        public override Task<CommonResponse> Division(CommonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CommonResponse
            {
                Result = request.Val1 / request.Val2
            });
        }
    }
}
