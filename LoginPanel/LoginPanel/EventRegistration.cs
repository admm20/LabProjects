using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanel
{
    class EventRegistration
    {
        public int eventRegistrationId; // id zapisu na wydarzenie
        public int accountId; // id konta
        public string foodType; // np. Wegetarianskie
        public int eventId; // id eventu
        public string confirmation; // yes, no, none
        public string type; // np. sponsor, sluchacz

        public EventRegistration()
        {

        }
    }
}
