using CaromBilliardsGame.Stolzenberg.Models;
using System.Collections.Generic;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        private List<BallModel.BallTypeEnum> hittenBallsList = new List<BallModel.BallTypeEnum>();

        private void OnCollisionEnter(Collision collision)
        {
            GameObject hitObj = collision.gameObject;

            if (hitObj.CompareTag("Ball"))
            {
                BallController ballController = hitObj.GetComponent<BallController>();

                if (!hittenBallsList.Contains(ballController.BallModel.BallType))
                {
                    hittenBallsList.Add(ballController.BallModel.BallType);
                }

                if (hittenBallsList.Contains(BallModel.BallTypeEnum.Red) && hittenBallsList.Contains(BallModel.BallTypeEnum.Yellow))
                {
                    print("Ja moin");
                }
            }
        }

        public void ResetHittenBallsList()
        {
            hittenBallsList.Clear();
        }
    }
}