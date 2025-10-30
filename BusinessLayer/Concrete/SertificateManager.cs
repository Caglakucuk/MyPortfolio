using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SertificateManager : ISertificateService
{
    ISertificateDal _sertificateDal;

    public SertificateManager(ISertificateDal sertificateDal)
    {
        _sertificateDal = sertificateDal;
    }
    public void TAdd(Sertificate t)
    {
        _sertificateDal.Insert(t);
    }

    public void TDelete(Sertificate t)
    {
        _sertificateDal.Delete(t);
    }

    public void TUpdate(Sertificate t)
    {
        _sertificateDal.Update(t);
    }

    public List<Sertificate> TGetList()
    {
        return _sertificateDal.GetList();
    }

    public Sertificate TGetById(int id)
    {
        return _sertificateDal.GetById(id);
    }
}