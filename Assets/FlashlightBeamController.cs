using Unity.VisualScripting;
using UnityEngine;

public class FlashlightBeamController : MonoBehaviour
{
    public BodyguardController bodyguard;
    private Rigidbody2D bodyguardRigidbody;

    public float rotationSpeed = 20f;
    public bool shouldRotate = true;
    public int beamMovementDegreeLimit = 30;
    public float snapRotationSpeed = 200f;
    
    private bool snapRequired = false;
    private Vector3 rotationAxis = Vector3.forward;

    void Start()
    {
        bodyguard = transform.parent.GetComponent<BodyguardController>();
        bodyguardRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldRotate) return;
        //BodyguardController.Check
        int currentAngle = (int) 360 - NormaliseAngle((int) transform.localEulerAngles.z - 180);
 
        float rotationSpeed = 20f;

        int bodyguardMovingDegree = (int) (360 + Mathf.Atan2(bodyguardRigidbody.velocity.x, bodyguardRigidbody.velocity.y) * (180 / Mathf.PI)) % 360;

        int maximumRotationAngle = NormaliseAngle(bodyguardMovingDegree + beamMovementDegreeLimit);
        
        int minimumRotationAngle = NormaliseAngle(bodyguardMovingDegree - beamMovementDegreeLimit);

        //transform.

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
        transform.RotateAround(bodyguard.transform.position, rotationAxis, rotationSpeed * Time.deltaTime);


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
