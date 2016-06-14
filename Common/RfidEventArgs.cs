namespace Nocturne.Common
{
    public class RfidEventArgs
    {
        public ulong Uid { get; private set; }

        public RfidEventArgs(ulong uid)
        {
            Uid = uid;
        }
    }
}
