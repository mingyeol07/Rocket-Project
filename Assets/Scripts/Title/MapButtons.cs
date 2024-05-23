namespace Title {
    using UnityEngine;

    public class MapButtons : MonoBehaviour
    {
        [SerializeField] private int stageNumber;

        private void OnMouseUp()
        {
            if(!TitleManager.Instance.IsClicked())
            {
                UserInfo.Instance.StageID = stageNumber;
                TitleManager.Instance.OnMapExitButtonClicked();
                TitleManager.Instance.OnPlanetOutline(stageNumber);
            }
        }
    }
}