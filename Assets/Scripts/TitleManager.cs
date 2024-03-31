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

    [SerializeField] private GameObject[] cylinder;

    private void Start()
    {
        btn_play.onClick.AddListener(() => Play());
    }

    private void Play()
    {
        canvasAnimator.SetBool("IsGame", true);
        GameManager.instance.GameStart();

        Sequence mySequence = DOTween.Sequence();

        // mySequence.Append(player.DOMoveZ(3, 1));
        // mySequence.Append(player.DOMoveZ(-5, 0));
        mySequence.Append(pos_mainCam.transform.DOMove(new Vector3(0, 9, -6.5f), 2));
        mySequence.Join(pos_mainCam.transform.DORotate(new Vector3(10, 0, 0), 1));
        mySequence.Append(pos_player.DOMoveZ(0, 2));

        mySequence.Play();

        cylinder[0].SetActive(true);
        cylinder[1].SetActive(true);
    }
}
