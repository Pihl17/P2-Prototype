
using UnityEngine;

public class CamraOrbit : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance =0.5f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;


    // Use this for initialization
    void Start()
    {
       
        this._XForm_Camera = this.transform;
        //GetComponentInParent<Transform>(); made the whole thing work
        this._XForm_Parent = this.GetComponentInParent<Transform>();
      //  _LocalRotation= new Vector3(1, 1, 0);
    }


    void LateUpdate()
    {
        Movement m = GetComponentInParent<Movement>();
        // disable camera controlls left shift key buttom
        if (Input.GetKeyDown(KeyCode.LeftShift))
            // swicthes between camera working and not, per click on left shift
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
            // If the camera is not disable work
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
               
            {
                // Rotate camera view related to the mouse x and y positin times the valuable mouseSensitevity
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;
                // Calls the function "move" from the movement class/script
                m.move(transform);
                //Clamp the Y rotation to horizontal and not flipping over at the top

                // This works as the constrain function in processing(value, minValue,maxValue)
                // Clamp the y rotatetion to horizon and not  flipping over the top
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, 0f, 90f);

                // The function above does the same as the function under (that is commented out)
                /* if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 90f)
                    _LocalRotation.y = 90 = 90f;*/

                //Zooming Input from our Mouse Scroll Wheel
                if (Input.GetAxis("Mouse ScrollWheel") != 0f)
                {
                    float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;
                   
                    // Makes the camra zoom faster the further away it is from the target
                    ScrollAmount *= (this._CameraDistance * 0.3f);

                    this._CameraDistance += ScrollAmount * -1f;
                    // This works as the constrain function in processing(value, minValue,maxValue)
                    // This functions does taht the furthes you scroll away is 100 meters and the closes you can scroll to the obejct is 1.5 meters
                    this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
                }
            }

            //Actual Camera Rig Transformations

            /* This part is the reason for why the function is called lateUpdate, anything before this function could be in a normal update function
            // Quaternion can be used to calculate an angle and is very simalar to a Vector3, the defference is that a Vector3 is a position of and object where a Quaternion
            // calculates the angle, this would also mean that you can use a Quaternion to make a character rotate do to and another object  movement. or to make a object move and rotate in a orbit.
            Quaternion has 4 values normally called (x,y,z,w), all rotations in unity (see input magneer) are calculated with Quaternion*/

            // the valuable below:  Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis. Unity - ScriptReference
            Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
            // As I understand it, this clamps(constrains) the quaternion function values, this.XF... value, QT=minValue, Time.deltaTime * OrbitDampening = MaxValue
            this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);
            
            
            //The last part only matter if we want to scroll zoom in program.
           /* if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
            {
                this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
            }*/

        }
    }
}
    
