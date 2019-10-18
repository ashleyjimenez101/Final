using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Ore myOre;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnMouseDown()
    {
        Destroy(gameObject);

        GameControllerObjectPart4.ProcessClickedCube(myOre);
    }
}
        
           
