using Unity.Mathematics;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 touch_s = Vector2.zero;
    private Vector2 touch_e = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private float com_div = Screen.width / 20;


    void Start()
    {
        
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

                    end.x = (touch_e.x - touch_s.x) / com_div;
                    end.y = (touch_e.y - touch_s.y) / com_div;

                    Debug.Log(math.sqrt(math.pow(end.x, 2) + math.pow(end.y, 2)));
                    body.linearVelocity = end;
                }
            }
        }


        
    }
}
