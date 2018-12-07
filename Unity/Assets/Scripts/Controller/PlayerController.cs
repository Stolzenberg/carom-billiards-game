using System;
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
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;
        [Header("Variables")]
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
                    pressedTime = 0;
                }
            }

            pressedTimeReference.Value = pressedTime;
        }
    }
}
