using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandGiveBoards : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GiveBoards()
    {
        for(int i = gameObject.transform.childCount; i < gameObject.transform.childCount - 3; i--)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponentInChildren<ChairÑreationMovements>().IsGo = true;
        }
    }
}
