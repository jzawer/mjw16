using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected bool status = false;
    public abstract void DoAction();
}