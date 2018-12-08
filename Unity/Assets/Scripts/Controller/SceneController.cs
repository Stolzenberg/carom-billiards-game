using UnityEngine;
using UnityEngine.SceneManagement;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class SceneController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator animator;

        private int sceneIndexToLoad;
        
        public void FadeToScene(int sceneIndex)
        {
            animator.SetTrigger("FadeOut");
            sceneIndexToLoad = sceneIndex;
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}