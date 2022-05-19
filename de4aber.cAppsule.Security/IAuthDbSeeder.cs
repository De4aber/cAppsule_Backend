namespace de4aber.cAppsule.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}