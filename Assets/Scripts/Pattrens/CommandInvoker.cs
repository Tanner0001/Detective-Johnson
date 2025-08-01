using UnityEngine;


// the invoker is used to undo and do a command excuted in a my trigger script. 


public class CommandInvoker : MonoBehaviour
{

    private ICommand lastCommand;
    public static CommandInvoker Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public void ExecuteCommand(ICommand command)
    {
       // Debug.Log("Placed Marker");
        command.Execute();  
        lastCommand = command; 
    }


    public void UndoLastCommand()
    {
      //  Debug.Log("Undo Marker");
        if (lastCommand != null)
        {
            lastCommand.Undo();
            lastCommand = null;
        }
    }

}
