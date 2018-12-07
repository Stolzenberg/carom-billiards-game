using System;
using CaromBilliardsGame.Stolzenberg.Models;
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

        private float pressedTime;

        private void Update()
        {
            GetPressedTime();

            if (pressedTime > 1)
            {
                pressedTime = 1;
            }
            if (pressedTime < 0)
            {
                pressedTime = 0;
            }

            ApplyForceToBall();
            RotateBallWithCamera();
        }

        private void RotateBallWithCamera()
        {
            Vector3 rotation = cameraController.transform.eulerAngles;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation.y, transform.eulerAngles.z);
        }

        private void GetPressedTime()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (pressedTime <= 1)
                {
                    pressedTime += playerModel.TimeToFullPower * Time.deltaTime;
                }

            }
            else
            {
                if (pressedTime >= 0)
                {
                    pressedTime -= playerModel.TimeToFullPower * Time.deltaTime;
                }
            }
        }
         
        private void ApplyForceToBall()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ballController.ApplyForceToBall(transform.forward, playerModel.Force * pressedTime);
            }
        }
    }
}
