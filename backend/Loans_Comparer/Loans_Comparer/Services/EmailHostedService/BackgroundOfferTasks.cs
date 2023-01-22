using Loans_Comparer.Requests;
using Loans_Comparer.Utilities.BankHandlers;

namespace Loans_Comparer.Services.EmailHostedService
{
    public interface IBackgroundOfferTasks
    {
        public void Enqueue(EmailTask offer);
        public EmailTask Dequeue();
    }
    public class BackgroundOfferTasks : IBackgroundOfferTasks
    {
        public BackgroundOfferTasks()
        {
            Offers = new Queue<EmailTask>();
        }
        private readonly Queue<EmailTask> Offers;

        public void Enqueue(EmailTask offer)
        {
            if(!Offers.Contains(offer))
                Offers.Enqueue(offer);
        }

        public EmailTask Dequeue()
        {
            if(Offers.Count != 0)
                return Offers.Dequeue();
            return null;
        }
    }
}
