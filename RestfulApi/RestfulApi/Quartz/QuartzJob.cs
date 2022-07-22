using Quartz;

namespace RestfulApi.Quartz
{
    public class QuartzJob : IJob
    {

        private readonly ILogger<QuartzJob> _logger;

        public QuartzJob(ILogger<QuartzJob> logger)
        {
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation("QuartzJob啟動.......................");
                _logger.LogInformation("QuartzJob結束.......................");
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("Exception Caught!");
                _logger.LogError("Message :{0} ", e.Message);
            }
        }
    }
}
