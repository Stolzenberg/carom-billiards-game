using System.Collections.Generic;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class RewindController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody rigid;

        private List<PointInTime> pointsInTime;

        [System.Serializable]
        private struct PointInTime
        {
            public Vector3 Position { get; set; }
            public Quaternion Rotation { get; set; }
        }

        private bool isRewinding;

        private void Start()
        {
            pointsInTime = new List<PointInTime>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                StartRewind();
            }
            else
            {
                StopRewind();
            }
        }

        private void FixedUpdate()
        {
            if (isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        internal void StartRewind()
        {
            isRewinding = true;
            rigid.isKinematic = true;
        }

        internal void StopRewind()
        {
            isRewinding = false;
            rigid.isKinematic = false;
        }

        private void Record()
        {
            PointInTime newPointInTime = new PointInTime
            {
                Position = transform.position,
                Rotation = transform.rotation
            };

            pointsInTime.Insert(0, newPointInTime);
        }

        private void Rewind()
        {
            if (pointsInTime.Count > 0)
            {
                transform.position = pointsInTime[0].Position;
                transform.rotation = pointsInTime[0].Rotation;

                pointsInTime.RemoveAt(0);
            }
            else
            {
                StopRewind();
            }
        }
    }
}
