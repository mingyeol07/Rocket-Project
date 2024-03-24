using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

// 점수, 부활, 게임오버, 게임스타트, 게임시간
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool boosting;
    private bool isStop;
    public bool isLife; // 부활할건지 물어보는 중일때 true
    private bool isOver;

    [SerializeField] private TMP_Text txt_distance;
    [SerializeField] private GameObject player;
    [SerializeField] private Material playerMaterial;

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
    private float lifeTime;

    private float travelDistance = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        btn_stop.onClick.AddListener(() => Stop());
        btn_play.onClick.AddListener(() => Stop());
        btn_life.onClick .AddListener(() => StartCoroutine("GetLife"));
        player.SetActive(true);
    }

    private void Update()
    {
        if (isStop) Time.timeScale = 0f;
        else if (boosting) Time.timeScale = 2f;
        else Time.timeScale = 1f;

        if(!isStop && !isOver) travelDistance += Time.deltaTime * 10;
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
        txt_stopExit.gameObject.SetActive(true);

        while (time > 0)
        {
            txt_stopExit.text = time.ToString();
            txt_stopExit.gameObject.GetComponent<Animator>().SetTrigger("Shot");
            yield return new WaitForSecondsRealtime(1f);
            time -= 1;
        }

        txt_stopExit.gameObject.SetActive(false);
        btn_stop.gameObject.SetActive(true);
        isStop = false;
    }

    public IEnumerator GameOver()
    {
        isOver = true;
        pnl_life.SetActive(true);
        lifeTime = 10;

        while (lifeTime > 0)
        {
            txt_lifeTime.text = Mathf.CeilToInt(lifeTime).ToString();
            lifeTime -= Time.unscaledDeltaTime;

            if (isLife == true) yield break;
            yield return null;
        }

        isOver = false;
        pnl_life.SetActive(false);
    }

    private IEnumerator GetLife()
    {
        if (isOver)
        {
            isLife = true;
            isOver = false;
            pnl_life.SetActive(false);
            player.SetActive(true);

            float timer = 0f;
            float time = 0f;
            float changeSpeed = 3f;
            Color color = playerMaterial.color;
            bool change = false;

            while (true)
            {
                if (change)
                {
                    timer -= 1;

                    if (timer <= 0)
                    {
                        change = false;
                    }
                }
                else
                {
                    timer += 1;

                    if (timer >= changeSpeed)
                    {
                        change = true;
                    }
                }

                playerMaterial.color = new Color(color.r, color.g, color.b, timer / changeSpeed);

                yield return new WaitForSeconds(0.1f);
                time += 0.1f;

                if(time > 3)
                {
                    isLife = false;
                    playerMaterial.color = new Color(color.r, color.g, color.b, 1);
                    yield break;
                }
            }
        }
    }
}
