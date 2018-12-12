using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Helpers
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}