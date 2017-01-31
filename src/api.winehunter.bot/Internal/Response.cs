using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winetracker.bot.connector.Internal
{
    internal static class Responses
    {
        public const string Features =
            "* I can take a picture of the wine bottle and add it your collection: Try 'Take a picture'\n\n"
            + "* I can scan the barcode and try to locate the wine information and add it to your collection: Try 'Scan barcode'\n\n"
            + "* I can ask you 5 questions about the wine you're drinking: Try 'Ask me about the wine'\n\n"
            + "* Send feedback to help improve my capabilites: Try 'I want to send a feedback'\n\n";

        public const string WelcomeMessage =
            "Hi there\n\n"
            + "I am your personal wine bot. Designed to help you catalog all of the wine you drank.  \n"
            + "Currently I can do the following  \n"
            + Features
            + "You can type 'Help' to get this information again";

        public const string HelpMessage =
            "I can do the following   \n"
            + Features
            + "What would you like me to do?";
    }
}
