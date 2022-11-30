namespace CodeBehind.ServicoNativo.Hosting
{
    public interface IWorkerTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
