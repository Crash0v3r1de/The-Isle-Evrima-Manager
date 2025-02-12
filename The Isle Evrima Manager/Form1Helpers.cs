using The_Isle_Evrima_Manager.Enums;

namespace The_Isle_Evrima_Manager
{
    internal static class Form1Helpers
    {
        public static void UpdateManagerStatus(ManagerStatus status)
        {
            switch (status)
            {
                case ManagerStatus.idle:
                    break;
                case ManagerStatus.downloadingSteamCMD:
                    break;
                case ManagerStatus.downloadingServerFiles:
                    break;
                case ManagerStatus.startingServer:
                    break;
                case ManagerStatus.stoppingServer:
                    break;
                case ManagerStatus.error:
                    break;
            }
        }
    }
}