using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public float WorldSize = 5000;
    public float ObjectLimit = 2000;
    public List<GameObject> Objects;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < ObjectLimit; i++)
        {
            var xPos = Random.Range(-WorldSize, WorldSize);
            var yPos = Random.Range(-WorldSize, WorldSize);
            Vector3 newPos = new Vector3(xPos, yPos, 0);
            var objectPicker = Random.Range(0, Objects.Count);
            Instantiate(Objects[objectPicker], newPos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
