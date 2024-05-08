using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Player;
    public Transform playerbody;
    public Rigidbody2D pointer;
    [SerializeField] public float force = 1;
    float time = 1;
    bool canjump = true;
    bool check = false;
    public float jumptime = 0;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        canjump = true;
    }





    private void Update()
    { 

        jumptime += Time.deltaTime;
        Camera w = Camera.main;
        Vector3 x = (w.ScreenToWorldPoint(Input.mousePosition) - Player.transform.position).normalized;
        float angle = Mathf.Atan2(x.y, x.x) * Mathf.Rad2Deg - 90;
        pointer.rotation = angle;
        pointer.position = Player.position + new Vector2(x.x, x.y).normalized * 1;
        x = new Vector2((x.x), (x.y)).normalized; 
        time += (Time.deltaTime * 200);
        if(check)
            playerbody.transform.localScale = new Vector2(.5f, (.5f / (time / 200))); 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (Player.velocityY != 0)
                canjump = false;
            float start = Time.fixedTime;
            time = 200f;
            check = true;
        }
        if ((Input.GetKeyUp(KeyCode.Space) == true) || (Input.GetKeyUp(KeyCode.Mouse0) == true))
        {
            if (time >= 500f)
                time = 500f;
            if (canjump && jumptime >= 1)
            {
                Player.AddForce((x) * (time * 1.5f * force));
                jumptime = 0;
                canjump = false;
            }
            playerbody.transform.localScale = new Vector2(.5f, .5f);
            check = false;
        }
    }


}

