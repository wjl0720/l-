using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletBehaviour : MonoBehaviour
{ 
    public float LinearVelocity = 0;
    public float Acceleration = 0;
    public float AngularVelocity = 0；
    public float AngularAcceleration = 0;
    public float MaxVelocity= int.MaxValue;
    public float LifeTime = 5f;

    private void FixedUpdate()
    {
        LinearVelocity = Mathf.Clamp(LinearVelocity+Acceleration * Time.fixedDeltaTime,-MaxVelocity,MaxVelocity);
        AngularVelocity += AngularAcceleration * Time.fixedDeltaTime;
        
        transform.Translate(LinearVelocity * Vector2.right * Time.fixedDeltaTime,Space.Self);

        transform.rotation*=Quaternion.Euler(new Vector3(0,0,1)*AngularVelocity*Time.fixedDeltaTime);

        LifeTime-=Time.fixedDeltaTime;
        
        if (LifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

}
