using CaromBilliardsGame.Stolzenberg.Events;
using CaromBilliardsGame.Stolzenberg.Models;
using CaromBilliardsGame.Stolzenberg.Variables;
using System.Collections.Generic;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        private const int pointsToWin = 3;

        [Header("Controllers")]
        [SerializeField] private AudioController audioController;
        [Header("Events")]
        [SerializeField] private GameEvent playerScored;
        [SerializeField] private GameEvent onGameOver;
        [Header("References")]
        [SerializeField] private IntReference shotsReference;
        [SerializeField] private IntReference pointsReference;
        [SerializeField] private FloatReference playTimeReference;

        private List<BallModel.BallTypeEnum> hittenBallsList = new List<BallModel.BallTypeEnum>();
        private float startTime;

        private void Awake()
        {
            pointsReference.Value = 0;
            playTimeReference.Value = 0;
            
            startTime = Time.time;
        }

        private void Update()
        {
            playTimeReference.Value = Time.time - startTime;
        }

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
                    OnPlayerScored();
                    playerScored.Raise();
                    audioController.PlayerEarnPointClip();
                }
            }
        }

        public void ResetHittenBallsList()
        {
            hittenBallsList.Clear();
        }
        
        private void OnPlayerScored()
        {
            pointsReference.Value++;

            ResetHittenBallsList();

            if (pointsReference.Value == pointsToWin)
            {
                onGameOver.Raise();
                audioController.GameOverSoundClip();

                SaveGameData newSaveData = new SaveGameData()
                {
                    Shots = shotsReference.Value,
                    Points = pointsReference.Value,
                    Time = playTimeReference.Value,
                };

                SaveGameController.SaveGame(newSaveData);
            }
        }
    }
}