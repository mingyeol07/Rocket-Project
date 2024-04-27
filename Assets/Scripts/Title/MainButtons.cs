namespace Title
{
    using UnityEngine;

    public class MainButtons : MonoBehaviour
    {
        private enum ButtonName { Skin, Map }
        [SerializeField] private ButtonName buttonName;

        private void OnMouseUp()
        {
            if (buttonName == ButtonName.Skin) TitleManager.Instance.OnSkinButtonClicked();
            else if (buttonName == ButtonName.Map) TitleManager.Instance.OnMapButtonClicked();
        }
    }
}