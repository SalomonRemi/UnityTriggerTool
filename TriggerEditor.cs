using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Trigger))]
public class TriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Trigger _script = (Trigger)target; //get the right class for the editor custom 

        EditorGUILayout.Space(); // add a small space between ui text
        GUIContent _detectionTypeGUI = new GUIContent("Detection Type"); //initialize the new GUI stuff
        _script.detectionTypeIndex = EditorGUILayout.Popup(_detectionTypeGUI, _script.detectionTypeIndex, _script.detectionType.ToArray());

        EditorGUILayout.Space(); // add a small space between ui text

        GUIContent _entitySelectionGUI = new GUIContent("Entity Selection"); //initialize the new GUI stuff 
        _script.entitySelectionIndex = EditorGUILayout.Popup(_entitySelectionGUI, _script.entitySelectionIndex, _script.entitySelection.ToArray()); //create the dropdown list
        if (_script.entitySelectionIndex == 0) // if it is the first index in this list
        {
            _script.tagString = EditorGUILayout.TextField("Tag Name",_script.tagString); //create a text field which is editable from inspector
        }
        else if (_script.entitySelectionIndex == 1)
        {
            _script.nameString = EditorGUILayout.TextField("Objects Name", _script.nameString);
        }
        else if (_script.entitySelectionIndex == 2)
        {
            _script.specificObject = (GameObject) EditorGUILayout.ObjectField("Specific Object", _script.specificObject, typeof(GameObject), true); //create a gameobject field which is editable from inspector
        }

        EditorGUILayout.Space(); // add a small space between ui text

        GUIContent _triggeredEventGUI = new GUIContent("Triggered Event"); //initialize the new GUI stuff
        _script.triggeredEventIndex = EditorGUILayout.Popup(_triggeredEventGUI, _script.triggeredEventIndex, _script.triggeredEvent.ToArray());
        if (_script.triggeredEventIndex == 0)
        {
            _script.sound = (AudioClip)EditorGUILayout.ObjectField("Sound Clip", _script.sound, typeof(AudioClip), true); // EditorGUILayout.ObjectField can basically be used for any type of variable/classes 
            _script.soundSource = (AudioSource)EditorGUILayout.ObjectField("Sound Source", _script.soundSource, typeof(AudioSource), true);
        }
        else if (_script.triggeredEventIndex == 1)
        {
            _script.animator = (Animator)EditorGUILayout.ObjectField("Animator", _script.animator, typeof(Animator), true);
            _script.animatorTrigger = EditorGUILayout.TextField("Animator Trigger Name", _script.animatorTrigger);
        }
        else if (_script.triggeredEventIndex == 2)
        {
            _script.methodScript = (MonoBehaviour)EditorGUILayout.ObjectField("Method Script", _script.methodScript, typeof(MonoBehaviour), true);
            _script.methodName = EditorGUILayout.TextField("Method Name", _script.methodName);
        }
        else if (_script.triggeredEventIndex == 3)
        {
            _script.className = EditorGUILayout.TextField("Class Name", _script.className);
            _script.internMethodName = EditorGUILayout.TextField("Method Name", _script.internMethodName);
        }
    }
}
