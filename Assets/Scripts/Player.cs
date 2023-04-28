using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
      Rigidbody2D myRig;
      Animator myanim;
      public bool Ground;
      AudioSource _AudioPlayer;
      public AudioClip Sound_jump;
      public GameObject Menu;
      bool Go_Left, Go_Right;



    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent <Rigidbody2D> ();
        myanim = GetComponent <Animator> ();
        _AudioPlayer = GetComponent <AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Go_Left)
        {
        transform.Translate(new Vector2(-3* Time.deltaTime, 0));
            transform.localScale = new Vector3 (-1f, transform.localScale.y, transform.localScale.z);
            myanim.SetBool("Run", true);
        }

        if(Go_Right)
        {
        transform.Translate(new Vector2(3* Time.deltaTime, 0));
           transform.localScale = new Vector3 (1f, transform.localScale.y, transform.localScale.z);
           myanim.SetBool("Run", true);
        }



        if(Input.GetKey(KeyCode.D))
        {
           transform.Translate(new Vector2(3* Time.deltaTime, 0));
           transform.localScale = new Vector3 (1f, transform.localScale.y, transform.localScale.z);
           myanim.SetBool("Run", true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-3* Time.deltaTime, 0));
            transform.localScale = new Vector3 (-1f, transform.localScale.y, transform.localScale.z);
            myanim.SetBool("Run", true);

        }


        if((!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.A)) && Go_Left == false && Go_Right == false)
        {
        myanim.SetBool("Run", false);
        }


        if(Input.GetKeyDown(KeyCode.Space) && Ground)
        {
          myRig.velocity = new Vector2(myRig.velocity.x, 7);
          myanim.Play("jump");
        _AudioPlayer.PlayOneShot(Sound_jump);
        }


        if(transform.position.y < -5)
        {
        Menu.SetActive(true);
        Destroy(gameObject);
        }



    }

    void OnCollisionEnter2D(Collision2D tagsplayer)
    {
      if (tagsplayer.gameObject.tag == "Ground")
      {
        Ground = true;
      }
    }

    void OnCollisionExit2D(Collision2D tagsplayer)
    {
      if (tagsplayer.gameObject.tag == "Ground")
      {
        Ground = false;
      }
    }

    public void Click_Down_Right()
    {
    Go_Right = true;
    
    }

    public void Click_Up_Right()
    {
     Go_Right = false;
    
    }


     public void Click_Down_Left()
    {
    Go_Left = true;
    }

    public void Click_Up_Left()
    {
    Go_Left = false;
    }

    public void Click_Jump()
    {
        if(Ground)
      {
           myRig.velocity = new Vector2(myRig.velocity.x, 7);
           myanim.Play("jump");
          _AudioPlayer.PlayOneShot(Sound_jump);
       }
    }




}
