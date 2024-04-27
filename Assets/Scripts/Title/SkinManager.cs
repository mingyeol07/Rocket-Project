namespace Title {
    using DG.Tweening;
    using UnityEngine;

    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private Transform skinsParentTransform;
        private int[] skinPositionX = { 0, 5, 10, 15 };
        private int currentSkinID = 0;
        private const float duration = 0.5f;

        public void SkinChangeLeft()
        {
            if (currentSkinID > 0) currentSkinID--;
            skinsParentTransform.DOMoveX(skinPositionX[currentSkinID], duration);
        }

        public void SkinChangeRight()
        {
            if (currentSkinID < skinPositionX.Length - 1) currentSkinID++;
            skinsParentTransform.DOMoveX(skinPositionX[currentSkinID], duration);
        }

        public void SkinSelect()
        {
            UserInfo.Instance.MapID = currentSkinID;
        }
    }
}