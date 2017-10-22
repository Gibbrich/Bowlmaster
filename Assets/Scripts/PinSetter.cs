using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PinSetter : MonoBehaviour
{
    public Text PinsCounter;
    public GameObject PinSet;

    [SerializeField]
    private float DistanceToRaise = 50f;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    
    private ActionMaster actionMaster;
    
    private Ball ball;
    private Animator animator;

    public PinSetter()
    {
        IsBallOutOfPlay = false;
    }

    public bool IsBallOutOfPlay { get; set; }

    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PinsCounter.text = CountStanding().ToString();

        if (IsBallOutOfPlay)
        {
            UpdateStandingCount();
            PinsCounter.color = Color.red;
        }
    }

    private void UpdateStandingCount()
    {
        // update the lastStandingCount
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastStandingCount = currentStanding;
            lastChangeTime = Time.time;
            return;
        }

        float settleTime = 3f; // how long to wait to consider pins settled
        // call PinsHaveSettled() when they have
        if (Time.time - lastChangeTime >= settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        int pinFall = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();
        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        if (action == ActionMaster.Action.TIDY)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.RESET || action == ActionMaster.Action.END_TURN)
        {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        }

        IsBallOutOfPlay = false;
        ball.Reset();
        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        PinsCounter.color = Color.green;
    }

    private int CountStanding()
    {
        int standingCount = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingCount++;
            }
        }
        return standingCount;
    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.GetComponent<Ball>())
//        {
//            BallExitedBox = true;
//            PinsCounter.color = Color.red;
//        }
//    }

    // called by animation event
    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Raise(DistanceToRaise);
        }
    }

    // called by animation event
    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower(DistanceToRaise);
        }
    }

    // called by animation event
    public void RenewPins()
    {
        Instantiate(PinSet, new Vector3(0, DistanceToRaise, 1829), Quaternion.identity);
        
        // after instantiating need disable gravity, otherwise position/rotation of pins will change
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            Rigidbody rig = pin.GetComponent<Rigidbody>();
            rig.useGravity = false;
            rig.isKinematic = true;
        }
    }
}