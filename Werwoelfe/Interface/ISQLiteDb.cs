using SQLite;

namespace Werwoelfe
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

