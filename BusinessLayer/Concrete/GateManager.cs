using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GateManager : IGateService
    {
        IGateDal _gateDal;
        public GateManager(IGateDal gateDal)
        {
            _gateDal = gateDal;
        }
        public void GateAdd(Gate gate)
        {
            _gateDal.Insert(gate);
        }

        public void GateDelete(Gate gate)
        {
            _gateDal.Delete(gate);
        }

        public Gate GateGetById(int id)
        {
            return _gateDal.Get(x => x.GateId == id);
        }

        public void GateUpdate(Gate gate)
        {
            _gateDal.Update(gate);
                
        }

        public List<Gate> GetList()
        {
           return _gateDal.List();
        }
    }
}
