using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Sorting : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // Flip Y because lower Y should render in front
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
}
