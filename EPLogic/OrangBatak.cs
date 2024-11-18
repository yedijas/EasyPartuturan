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
        private OrangBatak? bapak;
        private OrangBatak? mamak;
        private OrangBatak? pasangan;
        private OrangBatak? abang;
        private OrangBatak? kakak;
        private List<OrangBatak>? anak;
        private List<OrangBatak>? boru;
        private string panggilan;
        private Gender jenisKelamin;
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
        public List<OrangBatak> Anak { get { return anak; } set { anak = value; } }
        public List<OrangBatak> Boru { get { return boru; } set { boru = value; } }
        public string Panggilan { get { return panggilan; } set { panggilan = value; } }
        public Gender JenisKelamin { get { return jenisKelamin; } set { jenisKelamin = value; } }
        #endregion

        #region constructor
        public OrangBatak()
        {
            nama = "";
            marga = "";
            id = Guid.NewGuid();
            panggilan = "";
            jenisKelamin = Gender.Male;
            mamak = null;
            bapak = null;
            pasangan = null;
            abang = null;
            kakak = null;
            anak = null;
            boru = null;
        }

        public OrangBatak(String _nama, String _marga, String _panggilan)
        {
            id = Guid.NewGuid();
            nama = _nama;
            marga = _marga;
            panggilan = _panggilan;
            jenisKelamin = Gender.Male;
            mamak = null;
            bapak = null;
            pasangan = null;
            abang = null;
            kakak = null;
            anak = null;
            boru = null;
        }

        public OrangBatak(String _nama, String _marga, Gender _jeniskelamin)
        {
            id = Guid.NewGuid();
            nama = _nama;
            marga = _marga;
            panggilan = "";
            jenisKelamin = _jeniskelamin;
            mamak = null;
            bapak = null;
            pasangan = null;
            abang = null;
            kakak = null;
            anak = null;
            boru = null;
        }

        public OrangBatak(String _nama, String _marga, Gender _jeniskelamin, String _panggilan)
        {
            id = Guid.NewGuid();
            nama = _nama;
            marga = _marga;
            panggilan = _panggilan;
            jenisKelamin = _jeniskelamin;
            mamak = null;
            bapak = null;
            pasangan = null;
            abang = null;
            kakak = null;
            anak = null;
            boru = null;
        }
        #endregion

        #region IOrangBatak impl
        private bool ValidateChildAgainst(OrangBatak _parent)
        {
            try
            {
                if (_parent == null)
                {
                    throw new InvalidOperationException("yakalik ortu lu hampa!");
                }
                if (_parent.Equals(this))
                {
                    throw new InvalidOperationException("malah belah diri.");
                }
                if (_parent.Anak != null && (this.JenisKelamin.Equals(Gender.Male) && _parent.Anak.Contains(this)))
                {
                    throw new InvalidOperationException("anaknya dua kali ketambah.");
                }
                if (_parent.Boru != null && (this.JenisKelamin.Equals(Gender.Male) && _parent.Boru.Contains(this)))
                {
                    throw new InvalidOperationException("borunya dua kali ketambah.");
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool ValidateParentAgainst(OrangBatak _child)
        {
            try
            {
                if (_child == null)
                {
                    throw new InvalidOperationException("yakalik anaknya hampa!");
                }
                if (_child.Equals(this))
                {
                    throw new InvalidOperationException("malah belah diri.");
                }
                if (this.jenisKelamin.Equals(Gender.Male)) // special family name checking for bapak
                {
                    if (!this.marga.Equals(_child.Marga))
                    {
                        throw new InvalidOperationException("anak harus semarga sama bapaknya");
                    }
                }

                if ((this.jenisKelamin.Equals(Gender.Male) && _child.Mamak is not null && _child.Mamak.Id.Equals(this.Id))
                    || (this.jenisKelamin.Equals(Gender.Female) && _child.Bapak is not null && _child.Bapak.Id.Equals(this.Id)))
                {
                    throw new InvalidOperationException("jadi kau cw atau cw?! mau jadi mamak sama bapak bah!");
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool SetAsChildOf(OrangBatak _parent, bool _overrideMarga = true)
        {
            try
            {
                // always follow family name from father's side
                if (!_overrideMarga
                    && _parent.JenisKelamin.Equals(Gender.Male)
                    && !_parent.Marga.Equals(this.marga))
                {
                    throw new InvalidDataException("Child's family name and parent's family name should be the same if override family name is disabled");
                }
                // set last name
                if (_overrideMarga && _parent.JenisKelamin.Equals(Gender.Male)) //ngikut marga bokap
                {
                    this.marga = _parent.Marga;
                }
                // add into child list
                if (this.jenisKelamin.Equals(Gender.Male)) // anak
                {
                    if (_parent.Anak == null)
                    {
                        _parent.Anak = [this];
                    }
                    else
                    {
                        if (!_parent.Anak.Contains(this))
                        {
                            _parent.Anak.Add(this);
                        }
                    }
                }
                else // boru
                {
                    if (_parent.Boru == null)
                    {
                        _parent.Boru = [this];
                    }
                    else
                    {
                        if (!_parent.Boru.Contains(this))
                        {
                            _parent.Boru.Add(this);
                        }
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool SetAsParentOf(OrangBatak _child)
        {
            try
            {
                // set parent
                if (this.JenisKelamin.Equals(Gender.Male))
                {
                    _child.bapak = this;
                }
                else if (this.JenisKelamin.Equals(Gender.Female))
                {
                    _child.mamak = this;
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool AnaknyaSi(OrangBatak kawanIni)
        {
            bool retval = false;
            try
            {
                if (this.jenisKelamin.Equals(Gender.Female))
                {
                    throw new InvalidOperationException("Cewe jadi boru yaa...");
                }

                if (ValidateChildAgainst(kawanIni))
                {
                    retval = kawanIni.SetAsParentOf(this) &&
                        this.SetAsChildOf(kawanIni);

                    return retval;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool BorunyaSi(OrangBatak _kawanIni)
        {
            bool retval = false;
            try
            {
                if (this.jenisKelamin.Equals(Gender.Male))
                {
                    throw new InvalidOperationException("Cowo jadi anak yaa...");
                }

                if (ValidateChildAgainst(_kawanIni))
                {
                    retval = _kawanIni.SetAsParentOf(this)
                        && this.SetAsChildOf(_kawanIni);
                    return retval;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool BapaknyaSi(OrangBatak _kawanIni)
        {
            bool retVal = false;
            try
            {
                if (this.jenisKelamin.Equals(Gender.Female))
                {
                    throw new InvalidOperationException("Cewe jadi mamak yaa...");
                }

                if (this.ValidateParentAgainst(_kawanIni))
                {
                    retVal = this.SetAsParentOf(_kawanIni) &&
                        _kawanIni.SetAsChildOf(this);
                }

                return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool MamaknyaSi(OrangBatak _kawanIni)
        {
            bool retVal = false;
            try
            {
                if (this.jenisKelamin.Equals(Gender.Male))
                {
                    throw new InvalidOperationException("Cowo jadi bapak yaa...");
                }

                if (this.ValidateParentAgainst(_kawanIni))
                {
                    retVal = this.SetAsParentOf(_kawanIni) &&
                        _kawanIni.SetAsChildOf(this);
                }

                return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool KawinSama(OrangBatak kawanIni)
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
