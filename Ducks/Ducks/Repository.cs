using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ducks
{
    public static class Repository
    {
        private static Dictionary<string, Duck> _ducks;
        public static Dictionary<string, Duck> Ducks
        {
            get
            {
                if (_ducks == null)
                {
                    _ducks = new Dictionary<string, Duck>();
                }

                return _ducks;
            }
        }

        private static Dictionary<Guid, Duck> _requests;
        public static Dictionary<Guid, Duck> RequestsDucks
        {
            get
            {
                if (_requests == null)
                {
                    _requests = new Dictionary<Guid, Duck>();
                }

                return _requests;
            }
        }
    }
}