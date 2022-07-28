using System;
using EzySlice;
using UnityEngine;

namespace IdleActionFarm.GameplayObjects
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Collider))]
    public class Grass : MonoBehaviour
    {
        private Material _material;
        private SlicedHull _slicedHull;

        private void Awake() => _material = GetComponent<MeshRenderer>().material;

        public void Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection)
        {
            _slicedHull = gameObject.Slice(planeWorldPosition, planeWorldDirection, _material);
            if (_slicedHull is null)
                return;

            CreateGrassPart();
            CreateHull();

            Destroy(gameObject);
        }

        
        private void CreateGrassPart()
        {
            GameObject grass = CreateHull();
            grass.AddComponent<GrassPart>();
        }

        private GameObject CreateHull()
        {
            GameObject hull = _slicedHull.CreateLowerHull(gameObject, _material);
            
            MeshCollider meshCollider = hull.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            
            MoveToInitialPosition(hull.transform);

            return hull;
        }
        
        private void MoveToInitialPosition(Transform hull) => hull.position = transform.position;
    }
}