using System;

namespace DesignPattern_Mediator
{
    public class ConcreteColleague<T> : IColleague<T>
    {
        private string name;

        public ConcreteColleague(string name)
        {
            this.name = name;
        }

        void IColleague<T>.SendMessage(IMediator<T> mediator, T message)
        {
            mediator.DistributeMessage(this, message);
        }

        void IColleague<T>.ReceiveMessage(T message)
        {
            Console.WriteLine(this.name + " received " + message.ToString());
        }
    }
}