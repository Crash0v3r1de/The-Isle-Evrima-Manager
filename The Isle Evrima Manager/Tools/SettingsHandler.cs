using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Tools
{
    public class SettingsHandler : IDisposable
    {
        private bool disposed = false;


        

        #region Dispose methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                }

                // Dispose unmanaged resources here

                disposed = true;
            }
        }

        // Destructor to ensure resources are released
        ~SettingsHandler()
        {
            Dispose(false);
        }
        #endregion
    }
}
