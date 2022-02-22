using System.Threading.Tasks;

namespace FootballApp.Helpers.Forms.Pages
{
    public interface IPages
    {
        void OpenLogin();
        void OpenMain();
        Task OpenSignup();
    }
}
