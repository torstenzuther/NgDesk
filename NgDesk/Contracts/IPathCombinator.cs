namespace NgDesk.Contracts;

public interface IPathCombinator
{
    FilePath Combine(FilePath root, FilePath path);
}