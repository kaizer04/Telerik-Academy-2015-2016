namespace DesignPattern_Mediator
{
    public interface IColleague<T>
    {
        void SendMessage(IMediator<T> mediator, T message);

        void ReceiveMessage(T message);
    }
}