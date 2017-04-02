namespace CameraBzaar.Services.Data.Contracts
{
    public interface IIdentifierProvider
    {
        string EncodeId(int id);

        int DecodeId(string id);
    }
}