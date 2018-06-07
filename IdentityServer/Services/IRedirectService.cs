namespace HexMaster.Parcheesi.IdentityServer.Services
{
    public interface IRedirectService
    {
        string ExtractRedirectUriFromReturnUrl(string url);
    }
}
