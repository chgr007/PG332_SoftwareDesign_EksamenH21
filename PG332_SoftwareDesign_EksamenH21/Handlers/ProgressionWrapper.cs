using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionWrapper
    {
        public double PublishedPercent;
        public double FinishedPercent;

        public ProgressionWrapper(double publishedPercent, double finishedPercent)
        {
            PublishedPercent = publishedPercent;
            FinishedPercent = finishedPercent;
        }

        public static ProgressionWrapper operator + (ProgressionWrapper a, ProgressionWrapper b)
        {
            ProgressionWrapper s = new(a.PublishedPercent, a.FinishedPercent);
            s.PublishedPercent = Math.Round(s.PublishedPercent + b.PublishedPercent, 2, MidpointRounding.ToZero);
            s.FinishedPercent = Math.Round(s.FinishedPercent + b.FinishedPercent, 2, MidpointRounding.ToZero);
            return s;
        }

        public static ProgressionWrapper operator / (ProgressionWrapper a, int b)
        {
            ProgressionWrapper q = new(a.PublishedPercent, a.FinishedPercent);
            q.PublishedPercent = Math.Round(q.PublishedPercent / b, 2, MidpointRounding.ToZero);
            q.FinishedPercent = Math.Round(q.FinishedPercent / b, 2, MidpointRounding.ToZero);
            return q;
        }

        protected bool Equals(ProgressionWrapper other)
        {
            return PublishedPercent.Equals(other.PublishedPercent) && FinishedPercent.Equals(other.FinishedPercent);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProgressionWrapper)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PublishedPercent, FinishedPercent);
        }

        public static bool operator ==(ProgressionWrapper left, ProgressionWrapper right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProgressionWrapper left, ProgressionWrapper right)
        {
            return !Equals(left, right);
        }
    }
}
