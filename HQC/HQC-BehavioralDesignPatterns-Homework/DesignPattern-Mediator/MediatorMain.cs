using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Mediator
{
    public class MediatorMain
    {
        static void Main(string[] args)
        {
            //list of participants
            IColleague<string> colleagueA = new ConcreteColleague<string>("ColleagueA");
            IColleague<string> colleagueB = new ConcreteColleague<string>("ColleagueB");
            IColleague<string> colleagueC = new ConcreteColleague<string>("ColleagueC");
            IColleague<string> colleagueD = new ConcreteColleague<string>("ColleagueD");

            //first mediator
            IMediator<string> mediator1 = new ConcreteMediator<string>();
            //participants registers to the mediator
            mediator1.Register(colleagueA);
            mediator1.Register(colleagueB);
            mediator1.Register(colleagueC);
            //participantA sends out a message
            colleagueA.SendMessage(mediator1, "Message A from ColleagueA");

            //second mediator
            IMediator<string> mediator2 = new ConcreteMediator<string>();
            //participants registers to the mediator
            mediator2.Register(colleagueB);
            mediator2.Register(colleagueD);
            //participantB sends out a message
            colleagueB.SendMessage(mediator2, "Message B from ColleagueB");
        }
    }

}
