namespace Title {
    using UnityEngine;

    public class MapButtons : MonoBehaviour
    {
        [SerializeField] private int stageNumber;

        private void OnMouseUp()
        {
            switch (stageNumber) {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:

                    break;
            }

            UserInfo.Instance.StageID = stageNumber;
            TitleManager.Instance.OnMapExitButtonClicked();
        }
    }
}