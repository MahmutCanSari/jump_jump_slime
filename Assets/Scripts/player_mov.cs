using Unity.Mathematics;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 touch_s = Vector2.zero;
    private Vector2 touch_e = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private Vector2 max = Vector2.zero;
    private Vector2 ideal_screen = new Vector2(1080,1920);
    private Vector2 screen_div = Vector2.zero;
    public float div = 20;


    void Start()
    {
        screen_div.x = ideal_screen.x / Screen.width;
        screen_div.y = ideal_screen.y / Screen.height;
        max.x = (Screen.width/4) / div * screen_div.x;
        max.y = (Screen.height/4) / div * screen_div.y;
    }

    void Update()
    {
        if (body.linearVelocityY == 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touch_s = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    touch_e = touch.position;

                    end.x = (touch_e.x - touch_s.x) / div * screen_div.x;                 
                    end.y = (touch_e.y - touch_s.y)  / div * screen_div.y;
                    Debug.Log(end);

                    if (end.x > max.x) 
                    {
                        end.x = max.x;
                    }
                    if (end.y > max.y)
                    {
                        end.y = max.y;
                    }
                    Debug.Log(end);
                    Debug.Log(max);


                    body.linearVelocity = end;
                }
            }
        }
    }
}
