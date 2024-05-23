using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Obstacle_TransParent : Obstacle
{
    [SerializeField] private Material material;

    protected override void Start()
    {
        base.Start();

        material = GetComponent<MeshRenderer>().material;
        material.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
        StartCoroutine(TransParent());
    }

    private IEnumerator TransParent()
    {
        float timer = 0f;
        float time = 0f;
        float changeSpeed = 10f;
        bool changeFlag = false;
        Color color = material.color;
      
        while (true)
        {
            if (changeFlag)
            {
                timer -= 1;

                if (timer <= 0)
                {
                    changeFlag = false;
                }
            }
            else
            {
                timer += 1;

                if (timer >= changeSpeed)
                {
                    changeFlag = true;
                }
            }

            material.color = new Color(color.r, color.g, color.b, timer / changeSpeed);

            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
        }
    }
}
