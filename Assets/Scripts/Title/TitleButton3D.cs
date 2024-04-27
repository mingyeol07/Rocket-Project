namespace Title
{
    using DG.Tweening;
    using UnityEngine;

    public class TitleButton3D : MonoBehaviour
    {
        private const int clickScale = 35;
        private const int returnScale = 300;
        private const float changeSpeed = 0.1f;

        private void OnMouseDown()
        {
            transform.DOScaleZ(clickScale, changeSpeed);
        }

        private void OnMouseUp()
        {
            transform.DOScaleZ(returnScale, changeSpeed);
        }
    }
}