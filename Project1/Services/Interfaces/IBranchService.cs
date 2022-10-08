using Project1.Models;

namespace Project1.Services.Interfaces
{
    public interface IBranchService : IBankService<Branch>
    {
        bool HireEmployee(string employeeFullName, string branchName);
        int GetProfit(string branchName);
        Branch TransferMoney(string currentBranchName, string transferedBranchName, int amount);
        Branch TransferEmployee(string employeeFullName, string currentBranchName, string transferedBranchName);
    }
}
