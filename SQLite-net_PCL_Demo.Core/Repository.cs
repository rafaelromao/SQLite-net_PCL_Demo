using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace SQLite_net_PCL_Demo.Core.Repositories
{
    public class Repository
    {
        public static string DbName = "SQLite_net_PCL_Demo.sqlite";
        public static string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);

        public void Initialize()
        {
            if (!DatabaseExists())
            {
                using (var db = new SQLiteConnection(DbPath))
                {
                    db.CreateTable<Entity>();
                }
            }
        }

        public static bool DatabaseExists()
        {
            return FileExists(DbName).Result;
        }

        private static async Task<bool> FileExists(string fileName)
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save(Entity item)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                db.RunInTransaction(()=>
                {
                    var existingEntity = GetById(item.Id);
                    if (existingEntity != null)
                    {
                        existingEntity.Name = item.Name;
                        db.Update(existingEntity);
                    }
                    else
                    {
                        db.Insert(item);
                    }
                });
            }
        }

        public Entity GetById(int id)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                return db.Find<Entity>(id);
            }
        }

        public void Remove(Entity item)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                db.RunInTransaction(() =>
                {
                    var existingEntity = GetById(item.Id);
                    if (existingEntity != null)
                        db.Delete(existingEntity);
                });
            }
        }
    }
}
