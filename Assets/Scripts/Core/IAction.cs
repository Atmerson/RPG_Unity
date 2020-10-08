namespace RPG.Core
{
    public interface IAction
    {
        void Cancel(); //must be implemented in other classes
    }
    //interfaces can get rid of unwanted dependencies
    
    //in this case, creates a one way dependency. No more fighter depends on mover, mover depends on fighter. 
}