namespace EPLogic
{
    public interface IOrangBatak
    {
        public bool MamaknyaSi(IOrangBatak kawanIni);
        public bool BapaknyaSi(IOrangBatak kawanIni);
        public bool AnaknyaSi(IOrangBatak kawanIni);
        public bool BorunyaSi(IOrangBatak kawanIni);
        public bool KawinSama(IOrangBatak kawanIni);
        public bool NamanyaSi(IOrangBatak kawanIni, string nama);
        public bool MarganyaSi(IOrangBatak kawanIni, string marga);
        public string Dipanggil();
    }
}
