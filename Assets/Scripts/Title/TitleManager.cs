namespace Title
{
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    public class TitleManager : MonoBehaviour
    {
        public static TitleManager Instance;

        public SkinManager skinManager;
        [SerializeField] private Animator canvasAnimator;
        [SerializeField] private Animator RocketAnimator;

        // Buttons Animator
        private readonly int hashTitleButton_Enter = Animator.StringToHash("OtherTapEnter");
        private readonly int hashTitleButton_Exit = Animator.StringToHash("OtherTapExit");
        private readonly int hashTitleButton_Start = Animator.StringToHash("StartCanvas");
        private readonly int hashSkinButton_Enter = Animator.StringToHash("SkinTapEnter");
        private readonly int hashMapButton_Enter = Animator.StringToHash("MapTapEnter");
        
        // Rocket Animator
        private readonly int hashRocketSpin_Enter = Animator.StringToHash("SpinEnter");
        private readonly int hashRocketSpin_Exit = Animator.StringToHash("SpinExit");
        private readonly int hashRocketSmall_Enter = Animator.StringToHash("SmallEnter");
        private readonly int hashRocketSmall_Exit = Animator.StringToHash("SmallExit");
        private readonly int hashRocket_Start = Animator.StringToHash("Start");

        private float TapChangeDuration = 0.5f;

        private void Awake()
        {
            Instance = this;
        }

        public void OnGameStartLeverUp()
        {
            canvasAnimator.SetTrigger(hashTitleButton_Enter);
            canvasAnimator.SetTrigger(hashTitleButton_Start);
            RocketAnimator.SetTrigger(hashRocket_Start);

            Invoke("GameStart", 2f);
        }

        private void GameStart()
        {
            LoadingScene.LoadScene("MainGame");
        }

        public void OnSkinButtonClicked()
        {
            canvasAnimator.SetTrigger(hashTitleButton_Enter);
            canvasAnimator.SetTrigger(hashSkinButton_Enter);
            RocketAnimator.SetTrigger(hashRocketSpin_Enter);
        }

        public void OnSkinExitButtonClicked()
        {
            skinManager.SkinSelect();
            canvasAnimator.SetTrigger(hashTitleButton_Exit);
            RocketAnimator.SetTrigger(hashRocketSpin_Exit);
        }

        public void OnMapButtonClicked()
        {
            canvasAnimator.ResetTrigger(hashTitleButton_Exit);
            RocketAnimator.ResetTrigger(hashRocketSmall_Exit);

            canvasAnimator.SetTrigger(hashTitleButton_Enter);
            canvasAnimator.SetTrigger(hashMapButton_Enter);
            RocketAnimator.SetTrigger(hashRocketSmall_Enter);
        }

        public void OnMapExitButtonClicked()
        {
            canvasAnimator.SetTrigger(hashTitleButton_Exit);
            RocketAnimator.SetTrigger(hashRocketSmall_Exit);
        }
    }
}