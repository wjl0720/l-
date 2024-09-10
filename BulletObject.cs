using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create BulletAsset")]
public class BulletObject : ScriptableObject
{
    [Header("子弹的初始配置")]
    //生命周期
    public float LifeCycle = 5;
    //线速度
    public float LinearVelocity = 0;
    //线加速度
    public float Acceleration = 0;
    //角速度
    public float AngularVelocity = 0;
    //角加速度
    public float AngularAcceleration = 0;
    //最大速度
    public float MaxVelocity = int.MaxValue;

    [Header("发射器初始配置")]

    //初始旋转角度
    public float InitRotation = 0;
    //发射器角速度
    public float SenderAngularVelocity = 0;
    public float SenderMaxAngularVelocity=int.MaxValue;
    public float SenderAcceleration=0;
    //子弹线数量和夹角
    public int Count = 0;
    public float LineAngle = 30;
    //发射间隔
    public float SenderInterval = 0.1f;
    [Header("预制体")]
    public GameObject prefabs;

}
