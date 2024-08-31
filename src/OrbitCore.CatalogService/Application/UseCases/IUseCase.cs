namespace OrbitCore.CatalogService.Application.UseCases
{
    public interface IUseCase <IInput, IOutput>
    {
        Task<IOutput> HandleAsync(IInput input, CancellationToken cancellationToken);
    }
}
