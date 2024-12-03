using RepairMan.DataClasses.Common;
using System.Security.Principal;

namespace RepairMan.Business.Common
{
    public interface IUserControlLogic
    {
        User Create(User user);
        User GetUserByCredentials(UserCredentials credentials);
        User GetUserByIdentity(IIdentity identity);
        User UpdateUser(User user);
    }
}