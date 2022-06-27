using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFade : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        LoadSceneEvent.eventsBeforeChangeScene += startTransition;
    }
    public void startTransition() 
    {
        anim.SetTrigger("transition");
    }
}
