using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public float MoveSpeed;
    public float CastSpeed;
    public float MaxWidth;
    public Transform Hook;
    public Transform Line;
    public float HookPosition;
    private float xPos;
    public float CastLength;
    public AudioSource Audio;
    public AudioClip CollectSound;

    private float hookStartPos;
    public enum FishState
    {
        Idle,
        Casting,
        Pulling
    }
    public FishState State;
    // Start is called before the first frame update
    void Start()
    {
        hookStartPos = Hook.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(State == FishState.Idle)
        {
            xPos += Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
            xPos = Mathf.Clamp(xPos, -MaxWidth, MaxWidth);
            transform.position = new Vector2(xPos, transform.position.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = FishState.Casting;
                HookPosition = CastLength;
            }
        }
        if(State == FishState.Casting)
        {
            if(Hook.position.y > HookPosition + 0.1f)
            {
                Hook.position = Vector3.Lerp(Hook.position, new Vector3(Hook.position.x, HookPosition, 0), CastSpeed * Time.deltaTime);
            }
            else
            {
                State = FishState.Pulling;
            }
        }
        if(State == FishState.Pulling)
        {
            if (Hook.position.y < hookStartPos - 0.1f)
            {
                Hook.position = Vector3.Lerp(Hook.position, new Vector3(Hook.position.x, hookStartPos, 0), CastSpeed * Time.deltaTime);
            }
            else
            {
                State = FishState.Idle;
            }
        }

        
        var hookDist = Vector3.Distance(transform.position, new Vector3(transform.position.x, Hook.position.y, transform.position.z));
        Line.localScale = new Vector3(1, hookDist * 1.55f, 1);
        Line.position = new Vector3(Hook.position.x, (transform.position.y + Hook.transform.position.y) / 2, 0);


    }
}
