using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPLogic
{
    public class OrangBatak
    {
        #region variables
        private string nama;
        private string marga;
        private Guid id;
        private OrangBatak bapak;
        private OrangBatak mamak;
        private OrangBatak pasangan;
        private OrangBatak abang;
        private OrangBatak kakak;
        private OrangBatak anak;
        private OrangBatak boru;
        private string panggilan;
        #endregion

        #region getter setter
        public string Nama { get { return nama; } set { nama = value; } }
        public string Marga { get { return marga; } set { marga = value; } }
        public Guid Id { get { return id; } set { id = value; } }
        public OrangBatak Bapak { get { return bapak; } set { bapak = value; } }
        public OrangBatak Mamak { get { return mamak; } set { mamak = value; } }
        public OrangBatak Pasangan { get { return pasangan; } set { pasangan = value; } }
        public OrangBatak Abang { get { return abang; } set { abang = value; } }
        public OrangBatak Kakak { get { return kakak; } set { kakak = value; } }
        public OrangBatak Anak { get { return anak; } set { anak = value; } }
        public OrangBatak Boru { get { return boru; } set { boru = value; } }
        public string Panggilan { get { return panggilan; } set { panggilan = value; } }
        #endregion

        #region constructor
        public OrangBatak()
        {
            nama = "";
            marga = "";
            id = Guid.NewGuid();
            mamak = null; bapak = null; pasangan = null; abang = null; kakak = null; anak = null; boru = null;
        }

        public OrangBatak(string _panggilan)
        {
            nama = "";
            marga = "";
            id = Guid.NewGuid();
            panggilan = _panggilan;
            mamak = null; bapak = null; pasangan = null; abang = null; kakak = null; anak = null; boru = null;
        }
        #endregion

        #region IOrangBatak impl
        public bool AnaknyaSi(OrangBatak kawanIni)
        {
            try
            {
                if (kawanIni == null ||
                    kawanIni.Equals(this))
                {
                    throw new InvalidOperationException("yakalik bapaknya hampa!");
                }
                if (kawanIni.Boru.Equals(this))
                {
                    throw new InvalidOperationException("jadi kau cw atau cw?! mau jadi anak sama boru bah!");
                }
                this.bapak = kawanIni;
                if (kawanIni.Anak == null ||
                    !kawanIni.Anak.Equals(this))
                {
                    kawanIni.BapaknyaSi(this);
                }
                else
                {
                    throw new InvalidOperationException("anak yatim lu!");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool BorunyaSi(OrangBatak kawanIni)
        {
            try
            {
                if (kawanIni == null ||
                    kawanIni.Equals(this))
                {
                    throw new InvalidOperationException("yakalik bapaknya hampa!");
                }
                if (kawanIni.Anak.Equals(this))
                {
                    throw new InvalidOperationException("jadi kau cw atau cw?! mau jadi anak sama boru bah!");
                }
                this.bapak = kawanIni;
                if (kawanIni.Boru == null ||
                    !kawanIni.Boru.Equals(this))
                {
                    kawanIni.BapaknyaSi(this);
                }
                else
                {
                    throw new InvalidOperationException("anak yatim lu!");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool BapaknyaSi(OrangBatak kawanIni)
        {
            throw new NotImplementedException();
        }

        public bool KawinSama(OrangBatak kawanIni)
        {
            throw new NotImplementedException();
        }

        public bool MamaknyaSi(OrangBatak kawanIni)
        {
            throw new NotImplementedException();
        }

        public bool MarganyaSi(OrangBatak kawanIni, string marga)
        {
            throw new NotImplementedException();
        }

        public bool NamanyaSi(OrangBatak kawanIni, string nama)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region overrides

        #endregion
    }
}
