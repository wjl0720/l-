using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create BulletAsset")]
public class BulletObject : ScriptableObject
{
    [Header("�ӵ��ĳ�ʼ����")]
    //��������
    public float LifeCycle = 5;
    //���ٶ�
    public float LinearVelocity = 0;
    //�߼��ٶ�
    public float Acceleration = 0;
    //���ٶ�
    public float AngularVelocity = 0;
    //�Ǽ��ٶ�
    public float AngularAcceleration = 0;
    //����ٶ�
    public float MaxVelocity = int.MaxValue;

    [Header("��������ʼ����")]

    //��ʼ��ת�Ƕ�
    public float InitRotation = 0;
    //���������ٶ�
    public float SenderAngularVelocity = 0;
    public float SenderMaxAngularVelocity=int.MaxValue;
    public float SenderAcceleration=0;
    //�ӵ��������ͼн�
    public int Count = 0;
    public float LineAngle = 30;
    //������
    public float SenderInterval = 0.1f;
    [Header("Ԥ����")]
    public GameObject prefabs;

}
