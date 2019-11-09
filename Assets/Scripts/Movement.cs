using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 4f;
    Rigidbody2D rbody;
    Animator anim;
    Vector2 lookDir = new Vector2(1,0);
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(hori, verti);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)){
            lookDir.Set(move.x, move.y);
            lookDir.Normalize();
        }

        anim.SetFloat("Move X", lookDir.x);
        anim.SetFloat("Move Y", lookDir.y);
        //anim.setFloat("Speed", move.magnitude);

        Vector2 position = rbody.position;
        position = position + speed * move * Time.deltaTime;
        /*
        position.x = position.x + speed * hori * Time.deltaTime;
        position.y = position.y + speed * verti * Time.deltaTime;
         */
        rbody.MovePosition(position);
    }
}
