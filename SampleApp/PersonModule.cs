using SampleApp.Objects;
using SlimXUnitDb.App.IDb;

namespace SampleApp
{
    public static class PersonModule
    {
        public static bool SavePerson(IDb conn, AppPerson p)
        {
            conn.Transact("Some query for inserting person.");
            return true;
        }

        public static bool UpdateName(IDb conn, AppPerson p, string newNname)
        {
            conn.Transact("Some query for updating person name.");
            return true;
        }
    }
}
