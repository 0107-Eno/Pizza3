using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject _Vcam0;
    [SerializeField] private GameObject _Vcam1;
    [SerializeField] private GameObject _Vcam2;
    int nm = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.A) || Input.GetButtonDown("Fire1"))
        {
            switch (nm)
            {
                case 0:
                    _Vcam0.SetActive(false);
                    nm = 1;
                    break;
                case 1:
                    _Vcam1.SetActive(false);
                    nm = 2;
                    break;
                case 2:
                    _Vcam2.SetActive(false);
                    nm = 3;
                    break;
            }
        }
    }
}
