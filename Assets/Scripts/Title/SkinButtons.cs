namespace Title
{
    using UnityEngine;

    public class SkinButtons : MonoBehaviour
    {
        private enum ButtonName { Left, Right, Check }
        [SerializeField] private ButtonName buttonName;

        private void OnMouseUp()
        {
            if(buttonName == ButtonName.Left)
            {
                TitleManager.Instance.skinManager.SkinChangeLeft();
            }
            else if (buttonName == ButtonName.Right)
            {
                TitleManager.Instance.skinManager.SkinChangeRight();
            }
            else if (buttonName == ButtonName.Check)
            {
                TitleManager.Instance.OnSkinExitButtonClicked();
            }
        }
    }
}