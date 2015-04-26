using SQLite;

namespace SQLite_net_PCL_Demo.Core
{
    public class Entity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
