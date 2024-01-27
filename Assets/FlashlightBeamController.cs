using Unity.VisualScripting;
using UnityEngine;

public class FlashlightBeamController : MonoBehaviour
{
    public BouncerController bouncer;
    private Rigidbody2D bouncerRigidbody;

    [Header("Beam Properties")]
    public bool shouldRotate = true;
    public int beamMovementDegreeLimit = 30;
    public float regularRotationSpeed = 20f;
    public float snapRotationSpeed = 200f;


    private bool snapRequired = false;
    private Vector3 rotationAxis = Vector3.forward;

    void Start()
    {
        bouncer = transform.parent.GetComponent<BouncerController>();
        bouncerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldRotate) return;

        int currentAngle = (int) 360 - NormaliseAngle((int) transform.localEulerAngles.z - 180);
 
        float rotationSpeed = regularRotationSpeed;

        int bouncerMovingDegree = (int) (360 + Mathf.Atan2(bouncerRigidbody.velocity.x, bouncerRigidbody.velocity.y) * (180 / Mathf.PI)) % 360;

        int maximumRotationAngle = NormaliseAngle(bouncerMovingDegree + beamMovementDegreeLimit);
        int minimumRotationAngle = NormaliseAngle(bouncerMovingDegree - beamMovementDegreeLimit);


        if (!IsAngleInRange(currentAngle, minimumRotationAngle, maximumRotationAngle))
        {
            snapRequired = true;
            if (Mathf.Abs(minimumRotationAngle - currentAngle) < Mathf.Abs(maximumRotationAngle - currentAngle))
            {

                 rotationAxis = Vector3.back;

            }
            else
            {
                 rotationAxis = Vector3.forward;

            }
        }
        else
        {
            snapRequired = false;
        }

        
        if (snapRequired)
        {
            rotationSpeed = snapRotationSpeed;
        }

        transform.RotateAround(bouncer.transform.position, rotationAxis, rotationSpeed * Time.deltaTime);
    }
    private bool IsAngleInRange(int angle, int lower, int upper)
    {
        return mod((angle - lower), 360) <= mod((upper - lower), 360);
    }
    private int NormaliseAngle(int angle)
    {
        // force it to be the positive remainder, so that 0 <= angle < 360  
        return ((angle % 360 )+ 360) % 360;
    }
   
    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}
