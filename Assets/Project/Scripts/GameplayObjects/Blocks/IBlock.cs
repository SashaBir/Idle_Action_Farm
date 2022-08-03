using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    public interface IBlock : ICollectable
    {
        Transform Self { get; }
        
        int Price { get; }
    }
}