using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnplayButton()
    {
        GF.LoadScence(GData.SCENE_NAME_PLAY);
    }       // OnPlayButton()
}
