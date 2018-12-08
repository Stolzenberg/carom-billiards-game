using CaromBilliardsGame.Stolzenberg.Models;
using System.Collections.Generic;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class AIController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private AIModel aiModel;
        [Header("Controllers")]
        [SerializeField] private BallController ballController;
        [SerializeField] private AudioController audioController;
        [Header("References")]
        [SerializeField] private List<Transform> ballsTransformList;

        private void Update()
        {
            FindTarget();
            ApplyForceToBall();
        }

        private void FindTarget()
        {
            if (!ballController.IsMoving)
            {
                Vector3 randPos = Random.insideUnitCircle * aiModel.Inaccuracy;
                Vector3 targetVector = ballsTransformList[Random.Range(0, ballsTransformList.Count)].position + randPos;

                transform.LookAt(targetVector);
            }
        }

        private void ApplyForceToBall()
        {
            if (!ballController.IsMoving)
            {
                ballController.ApplyForceToBall(transform.forward, aiModel.Force * Random.Range(0.0f, 1.0f));
            }
        }
    }
}
