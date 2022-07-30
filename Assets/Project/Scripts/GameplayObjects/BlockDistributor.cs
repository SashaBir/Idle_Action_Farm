using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [Serializable]
    public class BlockDistributor
    {
        [SerializeField] [Min(0)] private float _height; 
        [SerializeField] [Min(0)] private float _duration;

        public async UniTaskVoid MoveAlongTrajectory(Transform transform, Func<Vector3> actualPosition)
        {
            Vector3 initial = transform.position;
            float expandedTime = 0;

            do
            {
                await UniTask.Yield();  
                    
                float lerpRation = expandedTime / _duration;
                transform.position = Vector3.Lerp(initial, actualPosition.Invoke(), lerpRation);
                
                expandedTime += Time.deltaTime;
            } 
            while (expandedTime < _duration);
        }
    }
}