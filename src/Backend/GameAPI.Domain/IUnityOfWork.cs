namespace GameAPI.Domain
{
    public interface IUnityOfWork
    {
        public Task Commit();
    }
}
