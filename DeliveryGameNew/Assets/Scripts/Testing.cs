using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Utils;

public class Testing : MonoBehaviour
{
    private Grid grid;
    
    void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20,0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Utils.GetMouseWorldPosition(), 56);
        }
    }


}
