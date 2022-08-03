namespace IdleActionFarm.GameplayObjects
{
    public interface ICollectable
    {
        bool IsCollected { get; }
        
        void Collect();
    }
}