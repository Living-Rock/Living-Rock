using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicNode : MonoBehaviour
{
    [SerializeField] private bool[] condition = { false };
    [SerializeField] private UnityEvent sortieActivee;
    [SerializeField] private UnityEvent sortieDesactivee;

    private bool previousOutput = false;
    private bool[] currentlyEnabled;

    private void Awake()
    {
        currentlyEnabled = new bool[condition.Length];

        previousOutput = true;
        for (int i = 0; i < condition.Length; i++)
        {
            previousOutput &= (condition[i] == currentlyEnabled[i]);
        }
    }

    public void EnableCondition(int condition_index)
    {
        currentlyEnabled[condition_index] = true;
        ChooseOuput();
    }

    public void DisableCondition(int condition_index)
    {
        currentlyEnabled[condition_index] = false;
        ChooseOuput();
    }

    private void ChooseOuput()
    {
        bool newOutput = true;
        for(int i = 0; i < condition.Length; i++)
        {
            newOutput &= (condition[i] == currentlyEnabled[i]);
        }

        if(newOutput && !previousOutput)
        {
            sortieActivee.Invoke();
        }

        else if(!newOutput && previousOutput)
        {
            sortieDesactivee.Invoke();
        }

        previousOutput = newOutput;
    }
}
