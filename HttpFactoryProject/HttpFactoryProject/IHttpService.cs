namespace HttpFactoryProject
{
    public interface IHttpService
    {
        System.Threading.Tasks.Task<string> CallAPIAsync();
    }
}