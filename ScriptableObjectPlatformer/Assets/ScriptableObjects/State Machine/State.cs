using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State",menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitons;
    public void UpdateState (StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }
    void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }
    void CheckTransitions(StateController controller)
    {
        for(int i = 0; i < transitons.Length;i++)
        {
            bool decisionSucceeded = transitons[i].decision.Decide(controller);

            if(decisionSucceeded)
            {
                controller.TransitionToState(transitons[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitons[i].falseState);
            }
        }
    }
}
