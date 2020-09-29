using System;

namespace ReportingModule.ValueObjects
{
    public class DiffCandidate :IEquatable<DiffCandidate>
    {
        public DiffCandidate(string left, string right)
        {
            if (string.IsNullOrWhiteSpace(left))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(left));
            if (string.IsNullOrWhiteSpace(right))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(right));
            Left = left;
            Right = right;
        }

        public static DiffCandidate Default() => new DiffCandidate("{}", "{}");
        public string Left { get; private set; }
        public string Right { get; private set; }

        public bool Equals(DiffCandidate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Left, other.Left) && string.Equals(Right, other.Right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiffCandidate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Left != null ? Left.GetHashCode() : 0) * 397) ^ (Right != null ? Right.GetHashCode() : 0);
            }
        }
    }
}
