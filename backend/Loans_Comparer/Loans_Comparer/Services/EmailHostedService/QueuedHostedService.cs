using Azure.Core;
using Loans_Comparer.Data;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Services.EmailService;
using Loans_Comparer.Utilities;
using Loans_Comparer.Utilities.BankHandlers;

namespace Loans_Comparer.Services.EmailHostedService
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly ILogger<QueuedHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private LoanComparerDbContext _dbContext;
        public IBackgroundOfferTasks _offers;
        private IBanksResolver _banksResolver;
        private ISendGridEmail _emailService;

        public QueuedHostedService(ILogger<QueuedHostedService> logger, IServiceProvider serviceProvider, IBackgroundOfferTasks offers)
        {
            //TaskQueue = taskQueue;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _offers = offers;
        }

        //public IBackgroundTaskQueue TaskQueue { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"Queued Hosted Service is running.{Environment.NewLine}");

            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _dbContext = scope.ServiceProvider.GetRequiredService<LoanComparerDbContext>();
                _banksResolver = scope.ServiceProvider.GetRequiredService<IBanksResolver>();
                _emailService = scope.ServiceProvider.GetRequiredService<ISendGridEmail>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                    _logger.LogInformation("Emails have been sent");

                    var offer = _offers.Dequeue();


                    if (offer != null)
                    {
                        var oldOffer = _dbContext.Offers.FirstOrDefault(o => o.Id == offer.Id);
                        var bankHandler = _banksResolver.Resolve(Enum.GetName(typeof(BankNames), offer.BankId));
                        var newOffer = bankHandler.GetExistingOffer(offer.ExternalOfferId);
                        if (oldOffer.Status != newOffer.statusDescription)
                        {
                            oldOffer.Status = newOffer.statusDescription;
                            var emailDto = new SendGridDto()
                            {
                                Subject = $"{newOffer.statusDescription} inquiry",
                                To = offer.email,
                                TextContent = $"Inquiry {offer.inquiryId} to bank {Enum.GetName(typeof(BankNames), offer.BankId)} was {newOffer.statusDescription}."
                            };
                            await _emailService.SendEmailAsync(emailDto);
                            _dbContext.SaveChanges();
                        }
                        if (oldOffer.Status != "Completed")
                        {
                            _offers.Enqueue(offer);
                        }
                    }

                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
