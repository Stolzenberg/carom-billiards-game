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
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;

        private float pressedTime;
        private bool moveBall;

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


            Vector3 rotation = cameraController.transform.eulerAngles;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation.y, transform.eulerAngles.z);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, Vector3.forward * 5);
        }

        private void GetPressedTime()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (pressedTime <= 1)
                {
                    pressedTime += playerModel.TimeToFullPower * Time.deltaTime;
                }
                moveBall = false;

            }
            else
            {
                if (pressedTime >= 0)
                {
                    pressedTime -= playerModel.TimeToFullPower * Time.deltaTime;
                }
                moveBall = true;

            }
        }
         
        private void ApplyForceToBall()
        {
            if (moveBall)
            {
                transform.Translate(Vector3.forward * (playerModel.Force * pressedTime));
            }
        }
    }
}
