using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class CommandException : Exception
    {
        String message;

        public CommandException(String message)
        {
            this.message= message;
        }

        public override string Message => message;

        public override IDictionary Data => base.Data;

        public override string StackTrace => base.StackTrace;

        public override string HelpLink { get => base.HelpLink; set => base.HelpLink = value; }
        public override string Source { get => base.Source; set => base.Source = value; }


    }
}
