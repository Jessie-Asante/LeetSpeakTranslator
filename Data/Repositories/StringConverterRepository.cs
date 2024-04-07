using Microsoft.EntityFrameworkCore;
using StringConverter.Data.Interfaces;
using StringConverter.Models.Domain;

namespace StringConverter.Data.Repositories
{
    public class StringConverterRepository:IStringConverterRepository
    {
        private readonly StringConverterDbContext _context;
        public StringConverterRepository(StringConverterDbContext context)=> _context = context;

        public TblConvertString Add(TblConvertString add)
        {
            _context.TblConvertStrings.Add(add);
            _context.SaveChanges();
            return add;
        }
         
        public bool? Delete(Guid Id)
        {
            var del = _context.TblConvertStrings.Find(Id);
            if (del != null)
            {
                _context.TblConvertStrings.Remove(del);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        
        public IEnumerable<TblConvertString> GetAll()
        {
            return _context.TblConvertStrings;
        }

        public async Task<IEnumerable<TblConvertString>> GetAllAsync(FormattableString query)
        {
            return await _context.Set<TblConvertString>().FromSqlInterpolated(query).ToListAsync();
        }
        public TblConvertString Get (int id)
        {
            return _context.TblConvertStrings.Find(id);
        }

        public TblConvertString Update(TblConvertString update)
        {
            var translate = _context.TblConvertStrings.Attach(update);
            translate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

       
    }
}
