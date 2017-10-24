using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PinSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject pinSet;
    [SerializeField]
    private float distanceToRaise = 50f;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.TIDY)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.RESET || action == ActionMaster.Action.END_TURN)
        {
            animator.SetTrigger("resetTrigger");
        }
        else
        {
            throw new UnityException("Not sure what action to perform");
        }
    }

    // called by animation event
    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Raise(distanceToRaise);
        }
    }

    // called by animation event
    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower(distanceToRaise);
        }
    }

    // called by animation event
    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, distanceToRaise, 1829), Quaternion.identity);
        GameManager.Instance.PinCounter.Reset();
        
        // after instantiating need disable gravity, otherwise position/rotation of pins will change
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            Rigidbody rig = pin.GetComponent<Rigidbody>();
            rig.useGravity = false;
            rig.isKinematic = true;
        }
    }
}