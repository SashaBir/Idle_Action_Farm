namespace IdleActionFarm.GameplayObjects
{
    public interface ISliceable
    {
        bool AlreadySliced { get; }
        
        void Slice();
    }
}