using System;
using UnityEngine;

namespace IdleActionFarm.Physics
{
    public interface IDirection
    {
        Vector2 Direction { get; }

        event Action OnStartedDirection;

        event Action OnEndedDirection;
    }
}