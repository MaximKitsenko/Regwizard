﻿using System;
using System.Runtime.Serialization;

namespace Regwiz.Accounts.Business.Exceptions
{
    [Serializable]
    public class QueryHandlerNotFoundException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public QueryHandlerNotFoundException()
        {
        }

        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }

        public QueryHandlerNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected QueryHandlerNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}