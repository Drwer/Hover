using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EHLib.Utils
{
    public class PathMover : MonoBehaviour
    {
        // Enums the two different types of loop for the path follower.
        public enum PlatformPathType
        {
            LOOP,
            PINGPONG
        }

        public Transform[] pathPoints;
        public float movingSpeed;
        public float stopRadiusSqr;
        public PlatformPathType loopType;
        //private AudioSource jingleToPlay;

        // Internal properties
        private int currentTarget = 1;
        private int currentTargetIncrement = 1;

        void Start()
        {
            // at start sets the initial position to the first node. 
            // does nothing if the array is empty
            if (pathPoints.Length == 0)
                return;
            transform.position = pathPoints[0].position;
            //jingleToPlay = GetComponent<AudioSource>();

        }

        // Update is called once per frame
        void Update()
        {
            // gather basic informations about the trajectory
            Vector3 target = pathPoints[currentTarget].position;
            Vector3 direction = target - transform.position;
            // using squared distance because it's  more efficient
            float sqrDistance = direction.sqrMagnitude;

            // Am I inside the stop radius?
            if (sqrDistance <= stopRadiusSqr)
            {
                //jingleToPlay.Play();
                switch (loopType)
                {
                    // if I'm looping
                    case PlatformPathType.LOOP:
                        currentTarget = (currentTarget + currentTargetIncrement) % pathPoints.Length;
                        break;
                    // if I have to bounce back
                    case PlatformPathType.PINGPONG:
                        if (currentTarget == 0 || currentTarget == pathPoints.Length - 1)
                            currentTargetIncrement = -currentTargetIncrement;
                        currentTarget = currentTarget + currentTargetIncrement;
                        break;
                }

            }

            // computes the new position
            transform.position = transform.position + direction.normalized * movingSpeed * Time.deltaTime;
        }

        #region gizmos

        // helper functions to visualize the path
        private void OnDrawGizmos()
        {
            for (int i = 0; i < pathPoints.Length - 1; i++)
            {
                if (pathPoints[i] == null || pathPoints[i + 1] == null)
                    continue;
                DrawPathPointGizmo(i);
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
            }

            DrawPathPointGizmo(pathPoints.Length - 1);
        }

        private void DrawPathPointGizmo(int i)
        {
            if (pathPoints[i] == null)
                return;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(pathPoints[i].position, 0.2f);
        }

        #endregion
    }
}
