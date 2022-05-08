using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using PathCreation.Examples;

public class RandomPathPlacer : PathSceneTool
{
    public GameObject prefab;
        public GameObject holder;
        public float spacing = 3;

        const float minSpacing = .001f;

        public float VerticalRandomDistance = 2;
        public float HorizontalRandomDistance = 0.2f;
        Vector3 randomOffsets;

        void Generate () {
            if (pathCreator != null && prefab != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    Transform newObj = Instantiate (prefab, point, rot, holder.transform).GetComponent<Transform>();

                    randomOffsets.x = Random.Range(-VerticalRandomDistance,-VerticalRandomDistance);
                    randomOffsets.y = Random.Range(-HorizontalRandomDistance,HorizontalRandomDistance);
                    newObj.position = newObj.TransformPoint(randomOffsets);

                    dst += spacing;
                }
            }
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate ();
            }
        }
    }
