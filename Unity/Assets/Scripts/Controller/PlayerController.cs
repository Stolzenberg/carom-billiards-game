using System;
using CaromBilliardsGame.Stolzenberg.Events;
using CaromBilliardsGame.Stolzenberg.Models;
using CaromBilliardsGame.Stolzenberg.Variables;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private PlayerModel playerModel;
        [Header("Controllers")]
        [SerializeField] private CameraController cameraController;
        [SerializeField] private BallController ballController;
        [SerializeField] private AudioController audioController;
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;
        [Header("Events")]
        [SerializeField] private GameEvent playerSwingQueue;
        [Header("References")]
        [SerializeField] private FloatReference pressedTimeReference;

        private void Update()
        {
            GetPressedTime();
            ApplyForceToBall();
            RotateBallWithCamera();
        }

        private void RotateBallWithCamera()
        {
            if (!ballController.IsMoving)
            {
                Vector3 rotation = cameraController.transform.eulerAngles;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation.y, transform.eulerAngles.z);
            }
        }

        private void GetPressedTime()
        {
            float pressedTime = pressedTimeReference.Value;

            if (Input.GetKey(KeyCode.Space))
            {
                if (!ballController.IsMoving)
                {
                    if (pressedTime <= 1)
                    {
                        pressedTime += playerModel.TimeToFullPower * Time.deltaTime;
                    }
                }

            }
            else
            {
                if (pressedTime >= 0)
                {
                    pressedTime -= playerModel.TimeToFullPower * Time.deltaTime;
                }
            }

            pressedTime = Mathf.Clamp(pressedTime, 0, 1);

            pressedTimeReference.Value = pressedTime;
        }
         
        private void ApplyForceToBall()
        {
            float pressedTime = pressedTimeReference.Value;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!ballController.IsMoving)
                {
                    ballController.ApplyForceToBall(transform.forward, playerModel.Force * pressedTime);
                    playerSwingQueue.Raise();
                    audioController.PlaySwingQueueClip();
                    pressedTime = 0;
                }
            }

            pressedTimeReference.Value = pressedTime;
        }
    }
}
