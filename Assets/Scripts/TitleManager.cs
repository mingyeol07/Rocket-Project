using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Button btn_play;
    [SerializeField] private Button btn_skin;
    [SerializeField] private Button btn_setting;

    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private Transform pos_mainCam;
    [SerializeField] private Transform pos_player;

    private void Start()
    {
        btn_play.onClick.AddListener(() => OnPlayButtonClicked());
        btn_skin.onClick.AddListener(() => OnSkinButtonClicked());
        btn_setting.onClick.AddListener(() => OnMapButtonClicked());
    }

    private void Update()
    {
        
    }

    private void OnPlayButtonClicked()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(pos_mainCam.transform.DOMove(new Vector3(0, 9, -6.5f), 2));
        mySequence.Join(pos_mainCam.transform.DORotate(new Vector3(10, 0, 0), 1));
        mySequence.Append(pos_player.DOMoveZ(0, 2));

        mySequence.Play();
    }

    private void OnSkinButtonClicked()
    {

    }

    private void OnMapButtonClicked()
    {

    }
}
