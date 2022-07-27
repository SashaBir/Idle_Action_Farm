using System;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Rigidbody))]
    public class GrassPart : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        
        public Material Material { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Material = GetComponent<MeshRenderer>().material;
        }
    }
}