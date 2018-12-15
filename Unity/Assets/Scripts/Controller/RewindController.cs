using CaromBilliardsGame.Stolzenberg.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class RewindController : MonoBehaviour
    {
        public bool IsRewinding { get; private set; }
        
        [Header("Components")]
        [SerializeField] private Rigidbody rigid;
        [Header("Controllers")]
        [SerializeField] private BallController ballController;

        [SerializeField] private RingBuffer<PointInTime> pointsInTime;

        [System.Serializable]
        private struct PointInTime
        {
            public Vector3 Position { get; set; }
            public Quaternion Rotation { get; set; }
        }

        private List<PointInTime> getLastPoints;
        private bool isRecording;
        private bool checkIfMoving;

        private void Start()
        {
            pointsInTime = new RingBuffer<PointInTime>(5000);
        }

        private void FixedUpdate()
        {
            if (IsRewinding)
            {
                Rewind();
            }
            if (isRecording)
            {
                Record();
            }
        }

        public void StartRecording()
        {
            isRecording = true;
            ballController.BallModel.IsMoving = true;

            Invoke("CheckIfStillMoving", 3f);

        }

        public void StartRewind()
        {
            IsRewinding = true;

            getLastPoints = pointsInTime.GetList();

            rigid.isKinematic = true;
        }

        private void StopRewind()
        {
            IsRewinding = false;
            
            rigid.isKinematic = false;
        }

        private void StopRecording()
        {
            isRecording = false;
            checkIfMoving = false;
        }

        private void Record()
        {
            PointInTime newPointInTime = new PointInTime();

            newPointInTime = new PointInTime
            {
                Position = rigid.transform.position,
                Rotation = rigid.transform.rotation
            };

            pointsInTime.Add(newPointInTime);

            if (checkIfMoving)
            {
                if (!ballController.BallModel.IsMoving)
                {
                    StopRecording();
                }
            }
        }

        private void Rewind()
        {
            if (getLastPoints.Count > 0)
            {
                transform.position = getLastPoints[0].Position;
                transform.rotation = getLastPoints[0].Rotation;

                getLastPoints.RemoveAt(0);
            }
            else
            {
                StopRewind();
            }
        }

        private void CheckIfStillMoving()
        {
            checkIfMoving = true;
        }
    }
}
