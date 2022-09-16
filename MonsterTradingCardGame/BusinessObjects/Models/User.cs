using BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    internal class User : Interfaces.IUser
    {
        public ICredentials Credentials { get; }

        public User(ICredentials credentials)
        {
            Credentials = credentials;
        }
    }
}
