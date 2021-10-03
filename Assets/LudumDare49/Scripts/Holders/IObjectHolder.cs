using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectHolder<T> where T : IHoldable
{
    public T Holdable { get; }
    
    public void HoldObject(T holdable);
    public void Release(Vector2 startPos, Vector2 throwDir, float releaseOffset);
}
