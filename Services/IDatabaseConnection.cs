namespace recipe_tracker.services
{
    public interface IDatabaseConnection
    {
        static bool Save(object data);
        static object Get(string id);
        static bool Delete(string id);
    }
}