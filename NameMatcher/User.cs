using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NameMatcher
{
    public class User
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
    }

    public class UserNameEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals([AllowNull] User x, [AllowNull] User y)
        {
            return x.First == y.First && x.Last == y.Last;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + obj.First.GetHashCode();
                hash = hash * 23 + obj.Last.GetHashCode();
                return hash;
            }
        }
    }
}
