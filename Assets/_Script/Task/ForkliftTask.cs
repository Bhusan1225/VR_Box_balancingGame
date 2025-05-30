using UnityEngine;

[CreateAssetMenu(fileName = "NewForkliftTask", menuName = "Forklift/Task")]
public class ForkliftTask : ScriptableObject
{
    public string taskName;
    [TextArea] public string taskInstruction;
}
