using System;
using IdleActionFarm.GameplayObjects;

namespace IdleActionFarm.Physics
{
    public interface ICollector
    {
        event Action<IBlock> OnAccumulated;

        void Clear();
    }
}