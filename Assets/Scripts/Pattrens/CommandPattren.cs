using UnityEngine;

public class CommandPattern : ICommand
{
    private GameObject prefab;
    private Vector2 position;
    private GameObject placedObject;

    public CommandPattern(GameObject prefab, Vector2 position)
    {
        this.prefab = prefab;
        this.position = position;
    }

    public void Execute()
    {
        placedObject = GameObject.Instantiate(prefab, position, Quaternion.identity);
        Debug.Log($"Marker Placed {prefab.name} / {position}");
    }

    public void Undo()
    {
        if (placedObject != null)
        {
            GameObject.Destroy(placedObject);
            Debug.Log($"Undo {placedObject.name}");
        }
    }
}
