using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToContinue : MonoBehaviour
{
    public GameObject Enable;
    public GameObject Disable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Enable.SetActive(true);
            Disable.SetActive(false);
        }
    }
}
