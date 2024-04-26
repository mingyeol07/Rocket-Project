using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    [SerializeField] private Transform pos_Lever;
    [SerializeField] private Button btn_skin;
    [SerializeField] private Button btn_setting;

    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private Transform pos_mainCam;
    [SerializeField] private Transform pos_player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        btn_skin.onClick.AddListener(() => OnSkinButtonClicked());
        btn_setting.onClick.AddListener(() => OnMapButtonClicked());
    }

    private void Update()
    {
        
    }

    public void OnGameStartLever()
    {
        Debug.Log("dd");
    }

    private void OnSkinButtonClicked()
    {

    }

    private void OnMapButtonClicked()
    {

    }
}