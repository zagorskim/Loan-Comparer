using BankAPI.FileManager;
using BankAPI.Models;

namespace BankAPI.OfferCreator
{
    public static class OfferCreator
    {
        public static Offer GetOffer(Inquiry inquiry, IFileManager fileManager)
        {
            //add default file to blob (and pass its link to the offer)
            fileManager.UploadTextFile(inquiry);

            decimal requestedValue = inquiry.MoneyAmount;
            int requestedPeriodInMonth = inquiry.InstallmentsCount;
            int percentage = inquiry.IncomeLevel >= 5000 ? 5 : 10;
            int status = 1; //ok

            string url = fileManager.GetUrl(inquiry.Id + "defaultfile.txt");

            decimal monthlyInstallment = requestedValue*(decimal)(double)percentage/100*(decimal)Math.Pow((1+ (double)percentage / 100),requestedPeriodInMonth)/(decimal)(Math.Pow(1+ (double)percentage / 100, requestedPeriodInMonth)-1);

            return new Offer(Guid.NewGuid(), percentage, monthlyInstallment, requestedValue, requestedPeriodInMonth, status, "ok",
                inquiry.Id, DateTime.Now, DateTime.Now, url, DateTime.MaxValue);
        }

    }
}
