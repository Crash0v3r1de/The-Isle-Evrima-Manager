using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Tools
{
    public class UpdateChecker : IDisposable
    {
        // To detect redundant calls
        private bool _disposedValue;
        // Instantiate a SafeHandle instance.
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public bool ManagerUpdate() {
            var client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("the-isle-evrima-manager"));
            var releases = client.Repository.Release.GetAll("Crash0v3r1de", "the-isle-evrima-manager");
            var latest = releases.Result[0];
            Console.WriteLine(
                "The latest release is tagged at {0} and is named {1}",
                latest.TagName,
                latest.Name);

            return false;
        }
        public bool EVIRMAUpdate() {
            // https://steamcommunity.com/app/346110/discussions/0/530646715636738547/
            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }
}
