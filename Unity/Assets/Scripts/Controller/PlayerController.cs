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

        private void Update()
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

            if (Input.GetKeyUp(KeyCode.Space))
            {

            }

            if (pressedTime > 1)
            {
                pressedTime = 1;
            }
            if (pressedTime < 0)
            {
                pressedTime = 0;
            }

            print(pressedTime);
        }
    }
}
