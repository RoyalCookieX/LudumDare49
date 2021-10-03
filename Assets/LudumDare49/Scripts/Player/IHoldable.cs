using UnityEngine;

public interface IHoldable
{
    public void Hold();
    public void Release(Vector2 startPos, Vector2 throwDir, float releaseOffset);
}