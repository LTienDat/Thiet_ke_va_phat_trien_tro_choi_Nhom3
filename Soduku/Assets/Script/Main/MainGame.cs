using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public GameObject MainPenal;
    public GameObject SodukuFiledPenal;
    public GameObject FieldPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 81; i++){
           GameObject.Instantiate(FieldPrefabs, SodukuFiledPenal.transform);  
        }
    }
}
 