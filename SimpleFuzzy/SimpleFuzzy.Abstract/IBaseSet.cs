namespace SimpleFuzzy.Abstract
{
    public interface IBaseSet : INameable
    {
        void ToFirst();
        void ToNext();
        bool IsEnd();
        object Get();
    }
}