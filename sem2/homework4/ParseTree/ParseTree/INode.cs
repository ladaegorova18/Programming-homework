namespace ParseTree
{
    /// <summary>
    /// Node of tree: operand or operation
    /// </summary>
    public interface INode
    {
        int Count();

        Operation AddChild(char value, Operation current);
    }
}
