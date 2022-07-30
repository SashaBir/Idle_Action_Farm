using System;
using UnityEngine;

namespace IdleActionFarm.Physics
{
    public interface ICollector
    {
        event Action<Transform> OnAccumulated;
    }
}