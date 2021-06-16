namespace NgDesk.Contracts
{
    public interface IBinaryLoader<in T>
    {
        byte[] Load(T path);
    }
}