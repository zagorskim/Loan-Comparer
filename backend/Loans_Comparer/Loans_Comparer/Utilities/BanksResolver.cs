using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Utilities.BankHandlers;

namespace Loans_Comparer.Utilities
{
    public interface IBanksResolver
    {
        IBankHandler Resolve(string bank);
    }

    public class BanksResolver : IBanksResolver
    {
        private readonly IEnumerable<IBankHandler> _bankHandlers;

        public BanksResolver(IEnumerable<IBankHandler> bankHandlers)
        {
            _bankHandlers = bankHandlers;
        }
        public IBankHandler Resolve(string bank)
        {
            var bankEnum = (BankNames)Enum.Parse(typeof(BankNames), bank);
            var bankHandler = _bankHandlers.Where(x => x.BankName == bankEnum);

            if (bankHandler.Count() != 1)
                throw new Exception($"Only one bank with type {bank} should be found");

            return bankHandler.Single();
        }
    }
}
