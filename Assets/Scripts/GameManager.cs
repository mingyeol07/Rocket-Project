using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool boosting;
    private bool isStop;

    [SerializeField] private TMP_Text txt_distance;
    [SerializeField] private GameObject player;
    
    [Header("Stop")]
    [SerializeField] private TMP_Text txt_stopExit;
    [SerializeField] private Button btn_stop;
    [SerializeField] private Button btn_play;
    [SerializeField] private GameObject pnl_stop;

    [Header("GameOver")]
    [SerializeField] private GameObject pnl_life;
    [SerializeField] private TMP_Text txt_lifeTime;
    [SerializeField] private Button btn_life;
    [SerializeField] private GameObject pnl_gameover;

    private float travelDistance = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        btn_stop.onClick.AddListener(() => Stop());
        btn_play.onClick.AddListener(() => Stop());
        player.SetActive(true);
    }

    private void Update()
    {
        if (isStop) Time.timeScale = 0f;
        else if (boosting) Time.timeScale = 4f;
        else Time.timeScale = 1f;

        if(!isStop) travelDistance += Time.deltaTime * 10;
        txt_distance.text = ((int)travelDistance).ToString() + "km";
    }

    private void Stop()
    {
        if (isStop == false)
        {
            btn_stop.gameObject.SetActive(false);
            isStop = true;
            pnl_stop.SetActive(true);
        }
        else
        {
            if(pnl_stop.activeSelf == true)
            {
                pnl_stop.SetActive(false);
                StartCoroutine(ExitStop());
            }
        }
    }

    private IEnumerator ExitStop()
    {
        int time = 3;

        while (time > 0)
        {
            txt_stopExit.text = time.ToString();
            txt_stopExit.gameObject.GetComponent<Animator>().SetTrigger("Shot");
            yield return new WaitForSecondsRealtime(1f);
            time -= 1;
        }

        btn_stop.gameObject.SetActive(true);
        isStop = false;
    }

    public IEnumerator GameOver()
    {
        pnl_life.SetActive(true);
        int time = 10;

        while (time > 0)
        {
            txt_lifeTime.text = time.ToString();
            yield return new WaitForSecondsRealtime(1f);
            time -= 1;
        }
        pnl_life.SetActive(false);
    }
}
