using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishKing : MonoBehaviour
{
    public Transform Boat;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        yPos += Time.deltaTime * 5;
        transform.position = new Vector3(Boat.position.x, yPos, 0);
        if(transform.position.y > 3.75f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
