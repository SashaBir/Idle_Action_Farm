using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class BlockDistributor
    {
        [SerializeField] [Min(0)] private float _duration;

        public async UniTaskVoid MoveAlongTrajectory(Transform transform, Transform position, Vector3 offset)
        {
            Vector3 initial = transform.position;
            float expandedTime = 0;

            do
            {
                await UniTask.Yield();  
                    
                float lerpRation = expandedTime / _duration;
                transform.position = Vector3.Lerp(initial, position.position + offset, lerpRation);
                
                expandedTime += Time.deltaTime;
            } 
            while (expandedTime < _duration);
        }
    }
}