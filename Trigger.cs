using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class Trigger : MonoBehaviour
{
    [SerializeField] // make a private vatriable accessible in inspector, still private
    private bool canBeTriggeredMultipleTimes;
    private bool hasBeenTriggered;

    [HideInInspector] // hide a public variable in inspector (even hide in inspector debug mode)
    public int detectionTypeIndex = 0;
    [HideInInspector]
    public List<string> detectionType = new List<string>(new string[] { "On Enter", "On Exit" });


    [HideInInspector]
    public int entitySelectionIndex = 0; // to track list index
    [HideInInspector]
    public List<string> entitySelection = new List<string>(new string[] { "By Tag", "By Name", "Specific" }); //list of selection type (availble for dropdown list in editor script)
    [HideInInspector]
    public string tagString;
    [HideInInspector]
    public string nameString;
    [HideInInspector]
    public GameObject specificObject;

    
    [HideInInspector]
    public int triggeredEventIndex = 0;
    [HideInInspector]
    public List<string> triggeredEvent = new List<string>(new string[] { "Play Sound", "Play Animation", "Play Method from External", "Play Method from Other" }); //Play Method from Other was previously Play Method from Internal
    [HideInInspector]
    public AudioClip sound;
    [HideInInspector]
    public AudioSource soundSource;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public string animatorTrigger;
    [HideInInspector]
    public MonoBehaviour methodScript;
    [HideInInspector]
    public string methodName;
    [HideInInspector]
    public string className;
    [HideInInspector]
    public string internMethodName;



    private void OnTriggerEnter(Collider other)
    {
        if(canBeTriggeredMultipleTimes)
        {
            if (detectionTypeIndex == 0) //0=enter / 1=exit / 2=stay
            {
                if (entitySelectionIndex == 0 && other.gameObject.CompareTag(tagString))//by tag
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound); // play the sound
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger); // the the animation
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f); // invoke method
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>(); //grab list of every monobehavior in other, then check if one of them name's is similar to our variable name

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if(s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f); // if similar, invoke method 
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 1 && other.gameObject.name == nameString) //by name
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 2 && other.gameObject == specificObject) //specific
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
            }
        }
        else if (!canBeTriggeredMultipleTimes && !hasBeenTriggered)
        {
            if (detectionTypeIndex == 0) //0=enter / 1=exit / 2=stay
            {
                if (entitySelectionIndex == 0 && other.gameObject.CompareTag(tagString))//by tag
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 1 && other.gameObject.name == nameString) //by name
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 2 && other.gameObject == specificObject) //specific
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }

                hasBeenTriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canBeTriggeredMultipleTimes)
        {
            if (detectionTypeIndex == 1) //0=enter / 1=exit / 2=stay
            {
                if (entitySelectionIndex == 0 && other.gameObject.CompareTag(tagString))//by tag
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 1 && other.gameObject.name == nameString) //by name
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 2 && other.gameObject == specificObject) //specific
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
            }
        }
        else if (!canBeTriggeredMultipleTimes && !hasBeenTriggered)
        {
            if (detectionTypeIndex == 1) //0=enter / 1=exit / 2=stay
            {
                if (entitySelectionIndex == 0 && other.gameObject.CompareTag(tagString))//by tag
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 1 && other.gameObject.name == nameString) //by name
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }
                else if (entitySelectionIndex == 2 && other.gameObject == specificObject) //specific
                {
                    if (triggeredEventIndex == 0)
                    {
                        soundSource.PlayOneShot(sound);
                    }
                    else if (triggeredEventIndex == 1)
                    {
                        animator.SetTrigger(animatorTrigger);
                    }
                    else if (triggeredEventIndex == 2)
                    {
                        methodScript.Invoke(methodName, 0f);
                    }
                    else if (triggeredEventIndex == 3)
                    {
                        MonoBehaviour[] _scripts = other.GetComponents<MonoBehaviour>();

                        foreach (MonoBehaviour s in _scripts)
                        {
                            if (s.GetType().Name == className)
                            {
                                s.Invoke(internMethodName, 0f);
                            }
                        }
                    }
                }

                hasBeenTriggered = true;
            }
        }
    }
}
