namespace Title {
    using UnityEngine;

    public class MapButtons : MonoBehaviour
    {
        private enum ButtonName { Planet0, Planet1, Planet2, Planet3 }
        [SerializeField] private ButtonName buttonName;

        private void OnMouseUp()
        {
            if (buttonName == ButtonName.Planet0)
            {
                
            }
            else if (buttonName == ButtonName.Planet1)
            {

            }
            else if (buttonName == ButtonName.Planet2)
            {

            }
            else if (buttonName == ButtonName.Planet3)
            {

            }

            UserInfo.Instance.MapID = (int)buttonName;
            TitleManager.Instance.OnMapExitButtonClicked();
        }
    }
}