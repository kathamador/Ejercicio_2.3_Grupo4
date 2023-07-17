using Ejercicio2_3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_3.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            dbase.CreateTableAsync<Models.Fotos>();

        }

        public Task<int> SitioSave(Fotos sitio)
        {
            if (sitio.id != 0)
            {
                return dbase.UpdateAsync(sitio);
            }
            else
            {
                return dbase.InsertAsync(sitio);
            }

        }

        public Task<List<Fotos>> getListSitio()
        {
            return dbase.Table<Fotos>().ToListAsync();
        }

        public async Task<Fotos> getSitio(int pid)
        {
            return await dbase.Table<Fotos>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteSitio(Fotos sitio)
        {
            return await dbase.DeleteAsync(sitio);
        }
    }
}
