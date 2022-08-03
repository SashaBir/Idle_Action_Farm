using System;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class ActivatorSlicer
    {
        [SerializeField] private Slicer _slicer;

        public void Activate() => _slicer.gameObject.SetActive(true);
        
        public void Disactivate() => _slicer.gameObject.SetActive(false);
    }
}