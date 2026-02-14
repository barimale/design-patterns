using System;
using System.Collections.Generic;
using System.Text;

namespace EventVisitator.Events
{
    public class UserRegisteredEvent : IEvent
    {
        public string Email { get; }
        public string UserName { get; }

        public UserRegisteredEvent(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }

        public void Accept(IEventVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
