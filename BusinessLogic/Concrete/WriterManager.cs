using BusinessLogic.Abstract;
using BusinessLogic.Controls;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        private readonly IValidator<Writer> _validator;

        public WriterManager(IWriterDal writerDal, IValidator<Writer> validator)
        {
            _writerDal = writerDal;
            _validator = validator;
        }

        public void Add(Writer writer)
        {
            DataControl.ControlNullData(writer);
            if (_validator.Validate(writer).IsValid)
            {
                _writerDal.Add(writer);
            }
        }

        public void Delete(Writer writer)
        {
            DataControl.ControlNullData(writer);
            _writerDal.Delete(writer);
        }

        public Writer Get(int id)
        {
            DataControl.ControlNullData(id);
            var data = _writerDal.Get(p => p.WriterId.Equals(id));
            DataControl.ControlFoundData(data);
            return data;
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll().ToList();
        }

        public Writer GetWriterByUsername(string username)
        {
            DataControl.ControlNullData(username);

            return _writerDal.GetWriterByUsername(username);
        }

        public void Update(Writer writer)
        {
            DataControl.ControlNullData(writer);
            _writerDal.Update(writer);
        }
    }
}
