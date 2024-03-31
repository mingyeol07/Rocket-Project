using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartCamera : MonoBehaviour
{
    [SerializeField] private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sequence mySequence = DOTween.Sequence();

            //mySequence.Append(player.DOMoveZ(3, 1));
            // mySequence.Append(player.DOMoveZ(-5, 0));
            mySequence.Append(transform.DOMove(new Vector3(0, 9, -6.5f), 1));
            mySequence.Join(transform.DORotate(new Vector3(10, 0, 0), 1));
            mySequence.Append(player.DOMoveZ(0, 2));

            mySequence.Play();
        }
        
    }
}
